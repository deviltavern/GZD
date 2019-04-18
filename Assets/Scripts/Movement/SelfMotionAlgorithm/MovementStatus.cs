using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementStatus : MonoBehaviour {
    public static MovementStatus Instance;


    public float J3;
    public float J2;
    public float J5;
    private void Awake()
    {
        Instance = this;
    }

  
}
