using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxleStepInfo {


    public static int workStrategyIndex = 0;
    public float J1;
    public float J2;
    public float J3;
    public float J4;
    public float J5;
    public float J6;

    public AxleStepInfo() { }

    public AxleStepInfo(List<float> list)
    {
        Debug.Log("该数据长度！！ == " + list.Count);
        if (list.Count != 6)
            return;

        J1 = list[0];
        J2 = list[1];
        J3 = list[2];
        J4 = list[3];
        J5 = list[4];
        J6 = list[5];
                 
    }

    public override string ToString()
    {
        return JsonUtility.ToJson(this);
    }


    public string ToProcedure(int index)
    {

        string value = "";
        value += "P[";
        value += index;
        value += "]";
        value += "\n";
        value += "{";
        value += " GP1:\n";
        value += "UF : 1, UT : 2,\n";
        value += "J1=" + J1 + "deg,";
        value += "J2=" + J2 + "deg,";
        value += "J3=" + J3 + "deg,";
        value += "J4=" + J4 + "deg,";
        value += "J5=" + J5 + "deg,";
        value += "J6=" + J6 + "deg";
        value += "};";

        return value;
 
    
    }


}
