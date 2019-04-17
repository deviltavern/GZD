using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileView : MonoBehaviour {

    public Transform fileButtonParent;

    void Awake()
    {
        fileButtonParent = this.transform.Find("Content").transform.Find("backGround");


    }



}
