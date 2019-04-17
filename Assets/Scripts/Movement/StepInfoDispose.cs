using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepInfoDispose : MonoBehaviour {


    public int index { get; set; }
    float frameTime = 0;
    float theChangeDistance = 0;
    float speed;

    public Strategy strategy { get; set; }
    public static StepInfoDispose Instance;
    void Awake()
    {
        Instance = this;
        theChangeDistance = 1;
        speed = 10;

       
    }

    public void reLive()
    {
        this.gameObject.SetActive(true);
        index = 0;
    
    }

    public void insChest()
    {

        Debug.Log("生成策略！！！！！！！！！！！！！！！");
        GameObject insChest = GameObject.Instantiate(ResourcesManager.prefabDic["chest"]);

        insChest.transform.position = StepController.preChestDefaultVec;
        StepController.preChest = insChest;
        Robots.Instance.Box.SetActive(false);
        
    }

    public void releaseChestEvent() {

        Robots.Instance.Box.SetActive(false);
        GameObject insBox = GameObject.Instantiate(Robots.Instance.Box, Robots.Instance.Box.transform);
        insBox.transform.localPosition = new Vector3();
        insBox.transform.SetParent(null); 

        insBox.AddComponent<ChestStop>(); 
        insBox.SetActive(true);

       

    }
    public void catchChestEvent()
    {
        Destroy(StepController.preChest);
        Robots.Instance.Box.SetActive(true);
    }

    
    void Update()
    {


        if (strategy != null)
        {

            strategy.doSomthing();
        }

        if (index <
             StepInfoLoader.stepInfoList.Count
            &&strategy == null
            )
        {

            switch (StepInfoLoader.stepInfoList[index].type)
            {
                case 0:

                    this.strategy = new RobotAMovement(this, StepInfoLoader.stepInfoList[index],this.theChangeDistance,this.speed);


                    break;

                case 1:

                     this.strategy = new InsChestStrategy(this);
                    break;

                case 2:
                     this.strategy = new CatchInsChestStrategy(this);

                    break;

                case 3:
                     this.strategy = new ReleaseChestStrategy(this);
                    break;
                default:

                    break;

            }



        }
   //                           
   //  if (index < 
   //       StepInfoLoader.stepInfoList.Count)
   //  {
   //
   //
   //      Debug.Log("当前状态：" + StepInfoLoader.stepInfoList[index].type);
   //
   //
   //      switch (StepInfoLoader.stepInfoList[index].type)
   //      {
   //
   //          case 0:
   //
   //              Robots.Instance.point_1.transform.rotation = Quaternion.LerpUnclamped(Robots.Instance.point_1.transform.rotation, Quaternion.Euler(StepInfoLoader.stepInfoList[index].toP1Euler()), Time.deltaTime * speed);
   //              Robots.Instance.point_2.transform.rotation = Quaternion.LerpUnclamped(Robots.Instance.point_2.transform.rotation, Quaternion.Euler(StepInfoLoader.stepInfoList[index].toP2Euler()), Time.deltaTime * speed);
   //              Robots.Instance.point_3.transform.rotation = Quaternion.LerpUnclamped(Robots.Instance.point_3.transform.rotation, Quaternion.Euler(StepInfoLoader.stepInfoList[index].toP3Euler()), Time.deltaTime * speed);
   //              float d1 = Vector3.Distance(Robots.Instance.point_1.transform.eulerAngles, StepInfoLoader.stepInfoList[index].toP1Euler());
   //              float d2 = Vector3.Distance(Robots.Instance.point_2.transform.eulerAngles, StepInfoLoader.stepInfoList[index].toP2Euler());
   //              float d3 = Vector3.Distance(Robots.Instance.point_3.transform.eulerAngles, StepInfoLoader.stepInfoList[index].toP3Euler());
   //
   //              Debug.Log(d1 + "--" + d2 + "--" + d3);
   //              if ((d1 < theChangeDistance || Mathf.Abs(d1 - 360) < theChangeDistance) && (d2 < theChangeDistance || Mathf.Abs(d2 - 360) < theChangeDistance)
   //
   //                  && (d3 < theChangeDistance || Mathf.Abs(d3 - 360) < theChangeDistance))
   //              {
   //                  
   //                  index++;
   //              }
   //
   //              break;
   //
   //          case 1:
   //              insChest();
   //              index++;
   //              
   //
   //              break;
   //
   //          case 2:
   //              catchChestEvent();
   //              index++;
   //              break;
   //
   //          case 3:
   //              releaseChestEvent();
   //              index++;
   //              break;
   //
   //          default:
   //
   //              break;
   //
   //      }
   //    
   //  }
   //
   //
      


    }
}
