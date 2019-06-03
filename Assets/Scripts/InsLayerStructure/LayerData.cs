using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LayerData  {

   public List<BoxData> boxDataList;
    public string path;


    public string getFileName()
    {
        Debug.Log(path);

        string[] pathArray = path.Split('\\');

        return pathArray[pathArray.Length - 1];
    }
    public LayerData(string path)
    {
        this.path = path;

        boxDataList = getLayerData(path);
    }

    public List<BoxData> getLayerData(string path)
    {
        this.path = path;
        List<BoxData> boxDataList2 = new List<BoxData>();

        

        StreamReader sr = new StreamReader(path, System.Text.Encoding.UTF8);


        string v2 = sr.ReadToEnd();
        string[] v2Array = v2.Split('&');
        for (int i = 0; i < v2Array.Length - 1; i++)
        {
            BoxData data = BoxData.getBoxData(v2Array[i]);
            boxDataList2.Add(data);
            Debug.Log(data.ToString());
        }

        return boxDataList2;

    }

    public override string ToString()
    {

        string vlaue = "";

        foreach (BoxData data in boxDataList)
        {

            vlaue += data.ToString() + "\n";
        }
        return vlaue;
    }
}
