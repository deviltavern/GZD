using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryEvent : ViewerTemplate {
    public static MemoryEvent Instance;
    public List<TrainStepMemory> stepList = new List<TrainStepMemory>();


    void Awake()
    {
        Instance = this;
       

    }

    void Start()
    {
        stepList.Add(new TrainStepMemory(RobotA.Instance));
    }
    void Update()
    {

        if (Input.GetKey(KeyCode.LeftAlt))
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                recover();
            }
        }
    
    
    }
    public override void update(ViewInfo info)
    {
        switch (info.code)
        {
            case MemoryClickItem.down:


                break;


            case MemoryClickItem.up:
                Debug.Log("保存训练步骤");
                stepList.Add(new TrainStepMemory(RobotA.Instance));


                break;
        
        }
    }

    public void recover()
    {

        if (stepList.Count < 2)
        {
            Debug.Log("无法恢复");
            return;
        }
        TrainStepMemory memory = stepList[stepList.Count - 2];
        stepList.RemoveAt(stepList.Count - 1);
        Debug.Log(memory.stepInfo.toJson());
        UIPointController.clear();
        for (int i = 0; i < RobotA.Instance.axleDic.Count; i++)
        {
           
            switch (i)
            {
                case 0:


                    RobotA.Instance.axleDic[AxleName.J1].transform.localRotation = Quaternion.Euler(memory.stepInfo.toP1Euler());
                

                    break;

                case 1:

                    // RobotA.axleDic[AxleName.J2].transform.localEulerAngles = Vector3.Lerp(RobotA.axleDic[AxleName.J2].transform.localEulerAngles, stepInfo.toP2Euler(), Time.deltaTime);
                    RobotA.Instance.axleDic[AxleName.J2].transform.localRotation = Quaternion.Euler(memory.stepInfo.toP2Euler());
                
                    break;

                case 2:
                    RobotA.Instance.axleDic[AxleName.J3].transform.localRotation = Quaternion.Euler(memory.stepInfo.toP3Euler());
                
                    break;
                case 3:

                    RobotA.Instance.axleDic[AxleName.J4].transform.localRotation = Quaternion.Euler(memory.stepInfo.toP4Euler());
                
                    break;
                case 4:

                    // RobotA.axleDic[AxleName.J5].transform.localEulerAngles = Vector3.Lerp(RobotA.axleDic[AxleName.J5].transform.localEulerAngles, stepInfo.toP5Euler(), Time.deltaTime);
                    RobotA.Instance.axleDic[AxleName.J5].transform.localRotation = Quaternion.Euler(memory.stepInfo.toP5Euler());
                
                    break;

                case 5:
                    RobotA.Instance.axleDic[AxleName.J6].transform.localRotation = Quaternion.Euler(memory.stepInfo.toP6Euler());
                
                    break;

                default:

                    break;
            }



        }

        

        

    
    
    }


}
