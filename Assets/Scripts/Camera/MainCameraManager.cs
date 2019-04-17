using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraManager : MonoBehaviour {
    public static GameObject mainCamera;

    void Awake()
    {
        mainCamera = this.gameObject;
    }
}
