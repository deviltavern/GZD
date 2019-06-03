using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputStrategy_Rotate : Strategy
{

    public GameObject cube;

    public InputStrategy_Rotate(GameObject cube)
    {
        this.cube = cube;
    }




    public override void doSomthing()
    {
        cube.transform.localRotation = Quaternion.Euler(cube.transform.localEulerAngles+90*Vector3.Normalize( new Vector3(0, Input.mouseScrollDelta.y, 0)));



    }

    public override void onEnd()
    {
       
    }

    public override void waitting()
    {
        throw new System.NotImplementedException();
    }
}
