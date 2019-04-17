using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Offset : MonoBehaviour {

    public float offset;
    public float offset2;
    public float viewOffset1;
    public static Offset Instance;


    private void Awake()
    {
        Instance = this;
    }
}
