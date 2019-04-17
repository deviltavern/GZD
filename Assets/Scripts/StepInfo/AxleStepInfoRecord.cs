using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxleStepInfoRecord : MonoBehaviour {

    private static List<AxleStepInfo> AxleStepInfoList = new List<AxleStepInfo>();


    public static List<AxleStepInfo> getData()
    {
        return AxleStepInfoList;
    }
    public static void save2AxleStepInfoList(AxleStepInfo info)
    {
        AxleStepInfoList.Add(info);
    }

    public static void removeFromAxleStepInfoList()
    {

        AxleStepInfoList.RemoveAt(AxleStepInfoList.Count - 1);
           
   }



}
