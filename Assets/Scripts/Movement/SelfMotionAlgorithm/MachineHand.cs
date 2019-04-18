using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineHand : MonoBehaviour {

    public static GameObject carryObj;
    private void Awake()
    {
        carryObj = this.transform.Find("carryObj").gameObject;


    }
}
