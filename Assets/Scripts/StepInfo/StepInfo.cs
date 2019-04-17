using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepInfo  {

    public StepInfo() { }
  
    
    public string index;
    public int type;
    public float p1_x;
    public float p1_y;
    public float p1_z;
    public float p2_x;
    public float p2_y;
    public float p2_z;
    public float p3_x;
    public float p3_y;
    public float p3_z;
    public float p4_x;
    public float p4_y;
    public float p4_z;
    public float p5_x;
    public float p5_y;
    public float p5_z;
    public float p6_x;
    public float p6_y;
    public float p6_z;


    public Vector3 toP1Euler()
    {

        return new Vector3(p1_x, p1_y, p1_z);
    
    }

    public Vector3 toP2Euler()
    {

        return new Vector3(p2_x, p2_y, p2_z);

    }
    public Vector3 toP3Euler()
    {

        return new Vector3(p3_x, p3_y, p3_z);

    }

    public Vector3 toP4Euler()
    {

        return new Vector3(p4_x, p4_y, p4_z);

    }


    public Vector3 toP5Euler()
    {

        return new Vector3(p5_x, p5_y, p5_z);

    }
    public Vector3 toP6Euler()
    {

        return new Vector3(p6_x, p6_y, p6_z);

    }


    public static Vector3 getEuler(int type,StepInfo info)
    {
        switch (type)
        { 
            case 1:
                return info.toP1Euler();
              
            case 2:
                return info.toP2Euler();
              
            case 3:

                return info.toP3Euler();
            case 4:

                return info.toP4Euler();
            case 5:

                return info.toP5Euler();
            case 6:

                return info.toP6Euler();

            default:

                break;
        }

        return new Vector3();
    }

    public string toJson()
    {
        return JsonUtility.ToJson(this);
    
    }
}
