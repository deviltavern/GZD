using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RobotProcedureAnalyser :MonoBehaviour, IViewer {

    public static RobotProcedureAnalyser Instance;

    void Awake()
    {
        Instance = this;
    }
    public static string path ="D:\\GZRobot\\t2.txt";

    private string procedureValue = "";
        
    public static List<AxleStepInfo> stepInfoList = new List<AxleStepInfo>();

    static char sign1 = '{';



    public static string getString(List<string> slist)
    {

        string value = "";

        foreach (string key in slist)
        {
            value += key;
        }

        return value;
    }



    public AxleStepInfo getAxleStepInfo(string procedureValue)
    {
      


        List<string> carveList = new List<string>();
        List<string> tempList = new List<string>();
        List<string> axleList = new List<string>();
        foreach (char value in procedureValue)
        {

            if (value == '{')
            {
                carveList.Add(RobotProcedureAnalyser.getString(tempList).Trim());
                tempList.Clear();
                continue;

            }

            if (value == ',')
            {

                carveList.Add(RobotProcedureAnalyser.getString(tempList).Trim());
                tempList.Clear();
                continue;
            }
            tempList.Add(value + "");




        }

        carveList.Add(RobotProcedureAnalyser.getString(tempList).Trim());
        tempList.Clear();
        foreach (string value in carveList)
        {

            if (value[0] == 'J')
            {
                axleList.Add(value);
            }

        }
        int index = 1;
        List<float> dataList = new List<float>();
        foreach (string axlueValue in axleList)
        {
            string temp = axlueValue.Replace("deg", "");
            temp = temp.Replace("J" + index + "=", "");
            temp = temp.TrimEnd();

            if (temp.Contains("};") == true)
            {
                
                temp = temp.Replace("};", "");
                temp = temp.TrimEnd();
               
            }
            if (temp.Contains("}") == true)
            {
                temp = temp.Replace("}", "");
                temp = temp.TrimEnd();
            }


            try {
                dataList.Add(float.Parse(temp));
            }
            catch
            {
              Debug.Log("异常数据："+temp);
            }
            
            index++;

        }

        foreach (float t in dataList)
        {

        }
       // stepInfoList.Add();

        return new AxleStepInfo(dataList);
        
    
    }

    public List<AxleStepInfo> analyseProcedure(string procedurePath)
    {
        StreamReader reader = new StreamReader(procedurePath);

        procedureValue = reader.ReadToEnd();

        string[] procedureArray = procedureValue.Split(';');

        int thePosBeginIndex = 0;
        for (int valueIndex = 0; valueIndex < procedureArray.Length; valueIndex++)
        {
            if (procedureArray[valueIndex].Contains("/POS"))
            {

                thePosBeginIndex = valueIndex;
            }

        }

        List<string> theMainList = new List<string>();

        for (int i = thePosBeginIndex; i < procedureArray.Length - 1; i++)
        {

            if (procedureArray[i].Contains("/POS") == true)
            {
                procedureArray[i] = procedureArray[i].Replace("/POS", "");

            }
            procedureArray[i] = procedureArray[i].Trim();
            theMainList.Add(procedureArray[i]);
        }

        List<AxleStepInfo> infoArray = new List<AxleStepInfo>();

        foreach (string key in theMainList)
        {

            infoArray.Add(getAxleStepInfo(key));
        }


        return infoArray;
    
    }



    public void update(ViewInfo info)
    {
        CommonData.stepInfoList = analyseProcedure(info.arg1);
        SceneManager.LoadScene("Simulink");





    }
}
