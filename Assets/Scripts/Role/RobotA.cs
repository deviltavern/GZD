using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotA : Role {

    public Dictionary<string, GameObject> axleDic = new Dictionary<string, GameObject>();

    public static RobotA Instance;

    public GameObject J1;
    public GameObject J2;
    public GameObject J3;
    public GameObject J4;
    public GameObject J5;
    public GameObject J6;


   

    public List<float> getAxleDataList()
    {
        List<float> AxleDataList = new List<float>();

        AxleDataList.Add(J1.transform.localEulerAngles.y);
        AxleDataList.Add(J2.transform.localEulerAngles.z);
        AxleDataList.Add(J3.transform.localEulerAngles.z);
        AxleDataList.Add(J4.transform.localEulerAngles.x);
        AxleDataList.Add(J5.transform.localEulerAngles.z);
        AxleDataList.Add(J6.transform.localEulerAngles.x);

        return AxleDataList;
    }

    public static void reTrain()
    {
        foreach (GameObject g in RobotA.Instance.axleDic.Values)
        {
            g.transform.eulerAngles = new Vector3();
        }
    }

    public static GameObject hand;
    void Awake()
    {
        Instance = this;
        J1 = this.transform.Find(AxleName.J1).gameObject;
        J2 = J1.transform.Find(AxleName.J2).gameObject;
        J3 = J2.transform.Find(AxleName.J3).gameObject;
        J4 = J3.transform.Find(AxleName.J4).gameObject;
        J5 = J4.transform.Find(AxleName.J5).gameObject;
        J6 = J5.transform.Find(AxleName.J6).gameObject;
        hand = J6.transform.Find("hand").gameObject;
        

        axleDic.Add(AxleName.J1, J1);
        axleDic.Add(AxleName.J2, J2);
        axleDic.Add(AxleName.J3, J3);

        axleDic.Add(AxleName.J4, J4);
        axleDic.Add(AxleName.J5, J5);
        axleDic.Add(AxleName.J6, J6);


        foreach (string key in axleDic.Keys)
        {

        }
    }

}
