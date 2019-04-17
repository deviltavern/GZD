using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerList : MonoBehaviour {

    public static LayerList Instance;

    void Awake()
    {
        Instance = this;
    }
}
