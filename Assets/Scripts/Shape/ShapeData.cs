using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeData {


    public List<ShapeItemData> shapeItemDataList = new List<ShapeItemData>();

    public ShapeData(string value)
    {

       
        string[] dataArray = value.Split('&');

        foreach (string key in dataArray)
        {

            if (key == "")
                continue;
            ShapeItemData sd = JsonUtility.FromJson<ShapeItemData>(key);
          
            shapeItemDataList.Add(sd);
            
        }
    }



}
