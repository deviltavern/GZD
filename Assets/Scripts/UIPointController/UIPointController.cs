using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class UIPointController : UIBase {

    public static Dictionary<string, UIPointController> PointControllerDic = new Dictionary<string, UIPointController>();


    public static void clear()
    {
        foreach (UIPointController controller in PointControllerDic.Values)
        {

            controller.nodbar.value = 0.5f;
            controller.turnbar.value = 0.5f;
            controller.swingbar.value = 0.5f;
        }
    

    
    }
    public string PointControllerID;
    
    public Button nudplus;
    public Button noddown;
    public Button turnfront;
    public Button turnback;
    public Button swingleft;
    public Button swingright;
   
    public Scrollbar nodbar;
    public Scrollbar turnbar;
    public Scrollbar swingbar;
    public GameObject point;
    public Button allowBtn;
    public Text axleValue;
    public Vector3 savePreVector3;

    
    public UIPointController onClickAllowBtn(string input_key)
    {   
        savePreVector3 = point.transform.localEulerAngles;
        foreach (string key in PointControllerDic.Keys)
        {
            if (input_key == key)
            {

                Debug.Log("允许操作这个东西");
                PointControllerDic[key].gameObject.SetActive(true);


                

              nodbar.value = 0.5f;
              turnbar.value = 0.5f;
              swingbar.value = 0.5f;
          
            }
            else {
                PointControllerDic[key].gameObject.SetActive(false);
                
            }
        }

        return this;
    }

    public float stepSize { get; set; }

    public virtual void Start() {

      
    }


    private float tempValue;
    public virtual void Awake()
    {
       
        
        nudplus = this.transform.Find("nodplus").GetComponent<Button>();
        noddown = this.transform.Find("noddown").GetComponent<Button>();
        turnfront = this.transform.Find("turnfront").GetComponent<Button>();
        turnback = this.transform.Find("turnback").GetComponent<Button>();
        swingleft = this.transform.Find("swingleft").GetComponent<Button>();
        swingright = this.transform.Find("swingright").GetComponent<Button>();
        nodbar = this.transform.Find("nodbar").GetComponent<Scrollbar>();
        turnbar = this.transform.Find("turnbar").GetComponent<Scrollbar>();
        swingbar = this.transform.Find("swingbar").GetComponent<Scrollbar>();
        nodbar.gameObject.AddComponent<MemoryClickItem>();
        turnbar.gameObject.AddComponent<MemoryClickItem>();
        swingbar.gameObject.AddComponent<MemoryClickItem>();
        axleValue = this.transform.Find("axleValue").GetComponent<Text>();

      

        nodbar.value = 0.5f;
        turnbar.value = 0.5f;
        swingbar.value = 0.5f;
        

        nudplus.onClick.AddListener(nudplus_);
        noddown.onClick.AddListener(nuddown_);
        turnfront.onClick.AddListener(turnfront_);
        turnback.onClick.AddListener(turnback_);
        swingleft.onClick.AddListener(swingleft_);
        swingright.onClick.AddListener(swingright_);
       

        stepSize = 1/360f;
    }

    public virtual void barDown() { 
    
          nodbar.value  -= 0.01f;
          turnbar.value  -= 0.01f;
          swingbar.value  -= 0.01f;
    }
    public virtual void barPlus() {

        nodbar.value += 0.01f;
        turnbar.value += 0.01f;
        swingbar.value += 0.01f;
    }
    public virtual void Update()
    {

       
        axleValue.GetComponent<RectTransform>().localPosition = Camera.main.WorldToScreenPoint(point.transform.position);
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("执行一次");
            barDown();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("执行一次");
            barPlus();
        
        
        }


        if (Input.GetKey(KeyCode.Space))
        {
            if (Input.GetKey(KeyCode.A))
            {
                Debug.Log("执行一次");
                barDown();
            }

            if (Input.GetKey(KeyCode.D))
            {
                Debug.Log("执行一次");
                barPlus();


            }
        
        }
    
    }
    public virtual void nudplus_() {
        nodbar.value += stepSize;
        //point.transform.rotation = Quaternion.Euler(point.transform.eulerAngles + new Vector3(0, 0, stepSize));


    }
    public virtual void nuddown_() {

       // point.transform.rotation = Quaternion.Euler(new Vector3(point.transform.rotation.x, point.transform.rotation.y, point.transform.rotation.z-stepSize ));
       // point.transform.rotation = Quaternion.Euler(point.transform.eulerAngles + new Vector3(0, 0, -stepSize));
        nodbar.value -= stepSize;

    }
    public virtual void turnfront_() {
       // point.transform.rotation = Quaternion.Euler(new Vector3(point.transform.rotation.x, point.transform.rotation.y+stepSize, point.transform.rotation.z));
        point.transform.rotation = Quaternion.Euler(point.transform.eulerAngles + new Vector3(0,  stepSize,0));


    }
    public virtual void turnback_() {
       // point.transform.rotation = Quaternion.Euler(new Vector3(point.transform.rotation.x, point.transform.rotation.y - stepSize, point.transform.rotation.z));
        point.transform.rotation = Quaternion.Euler(point.transform.eulerAngles + new Vector3(0, -stepSize, 0));
    }
    public virtual void swingleft_() {
      //  point.transform.rotation = Quaternion.Euler(new Vector3(point.transform.rotation.x+stepSize, point.transform.rotation.y, point.transform.rotation.z));
        point.transform.rotation = Quaternion.Euler(point.transform.eulerAngles + new Vector3(stepSize,0, 0));
    }
    public virtual void swingright_() {
      //  point.transform.rotation = Quaternion.Euler(new Vector3(point.transform.rotation.x - stepSize, point.transform.rotation.y, point.transform.rotation.z));
        point.transform.rotation = Quaternion.Euler(point.transform.eulerAngles + new Vector3(-stepSize, 0, 0));
    }
    



}
