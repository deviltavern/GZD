using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class AxleStepInfoSaver : MonoBehaviour {

    public const string path = "D:\\GZRobot\\";
    public static string getProcedureValue(List<AxleStepInfo> list)
    {
        string reValue = "/POS\n";
        for (int i = 0; i < list.Count;i++ )
        {

            reValue += list[i].ToProcedure(i+1) + "\n";


        }
        reValue += "/END";
        return reValue;
    
    }


    public static void save2PC(string fileName, string value)
    {

        StreamWriter writer = new StreamWriter(path + fileName,false);

        writer.Write(value);

        writer.Flush();
        

    }


}
