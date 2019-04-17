using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StepController : MonoBehaviour {

    public Button catchRobotAnimationBtn;
    public Button catchInsChestBtn;
    public Button catchReleaseChestBtn;
    public static GameObject preChest;


    public static Vector3 preChestDefaultVec = new Vector3(1.488f,0);

     
    public static Dictionary<int, GameObject> pointDic = new Dictionary<int, GameObject>();
    
    public void Awake()
    { 
    
        
    }


}
