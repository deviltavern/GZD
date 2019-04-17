using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class StepInfoCatcher : MonoBehaviour
{

    public static List<string> stepInfoList = new List<string>();
    public static StepInfoCatcher Instance;

    public static string path = "D:\\stepInfo.txt";
    void Awake()
    {

        Instance = this;
        
    
    }

    string value;
    public void save()
    {
        foreach (string key in stepInfoList)
        {
            Debug.Log(".....");
            value += key + "\n";


        
        }

       FileStream fs = new FileStream(path, FileMode.Create);
       StreamWriter sw = new StreamWriter(fs);
       sw.Write(value);
       sw.Close();

       // PlayerPrefs.SetString("animation", value);
        value = "";
    }


    

    public void addStep(StepInfo info,StepType type)
    {

        Debug.Log("存储类型为：" + (int)type);                      
        info.type = (int)type;
        stepInfoList.Add(info.toJson());
    
    }

}
