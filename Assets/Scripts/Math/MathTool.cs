using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathTool {

    public static Vector3 vecRotate(Vector2 vex,float angle)
    {

        return new Vector2(vex.x * Mathf.Cos(angle * Mathf.Deg2Rad), vex.y * Mathf.Sin(angle * Mathf.Deg2Rad));
    
    }
}
