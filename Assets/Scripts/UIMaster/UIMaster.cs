using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMaster : MonoBehaviour {

    public static GameObject stepController;
    public static GameObject crashController;
    public static GameObject funcController;
    public static GameObject pointController;


    void Awake()
    {
        stepController = GameObject.Find("Canvas").transform.Find("StepController").gameObject;
        crashController = GameObject.Find("Canvas").transform.Find("CastController").gameObject;
        funcController = GameObject.Find("Canvas").transform.Find("FuncController").gameObject;
        pointController = GameObject.Find("Canvas").transform.Find("PointController").gameObject;
    }




}
