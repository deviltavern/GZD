using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeCameraViewRotate : CameraViewRotation {

    public override void Awake()
    {

        this.lookPoint = GameObject.Find("ShapeViewPoint");
        
    }
}
