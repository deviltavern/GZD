using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class StepInfoLoader : MonoBehaviour {

    public static List<StepInfo> stepInfoList = new List<StepInfo>();
    float x ;
    float y ;
    float z ;

    public GameObject box1;
    public GameObject box2;
    public Vector3 toP1Euler(StepInfo info)
    {
      Vector3 vec = new Vector3();

      x = float.Parse(info.p1_x.ToString());
      y = info.p1_y  ;
      z = info.p1_z;
       return vec;
 
    
    }
    void Awake()
    {

        load(StepInfoCatcher.path);



    }


  
    public static void load(string path)
    {
        try
        {
            stepInfoList.Clear();
            StreamReader reader = new StreamReader(path);
            
            string value = reader.ReadToEnd();
           
           // string value = PlayerPrefs.GetString("animation"); 
            string[] valueArray = value.Split('\n');

            for (int i = 0; i < valueArray.Length - 1; i++)
            {
                stepInfoList.Add(JsonUtility.FromJson<StepInfo>(valueArray[i]));


            }


        }
        catch {

            Debug.Log("不存在该文件");
        }
       
    }
}
