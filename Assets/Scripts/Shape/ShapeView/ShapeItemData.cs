using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeItemData {
    public float x;
    public float y;

    public float z;
    public string ID;

    public GameObject shapeItem;
    public static ShapeItemData conveter(Vector3 vec)
    {
        ShapeItemData data = new ShapeItemData();


        data.x = vec.x;
        data.y = vec.y;
        data.z = vec.z;

        return data;
    }

    public Vector3 getVector3()
    {
        return new Vector3(x, y, z);
    }
}
