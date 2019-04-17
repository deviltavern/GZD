using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeItemCatcher : MonoBehaviour {

    private static List<string> shapeItemIDList = new List<string>();

    public static void addShapeItem(string value)
    {
        if (shapeItemIDList.Contains(value) == false&&value!= "")
        {
            shapeItemIDList.Add(value);
        }
        else
        {
            return;
        }
    }

    public static List<string> getData()
    {
        return shapeItemIDList;
    }
    public static void deleteShapeItem(string value)
    {
        shapeItemIDList.Remove(value);
    }





}
