using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robots : Role {


    public static Robots Instance;
    public GameObject point_1 { get; set; }
    public GameObject point_2 { get; set; }
    public GameObject point_3 { get; set; }

    public GameObject Box;


    void Awake()
    {

        Instance = this;
        point_1 = this.transform.Find("point_1").gameObject;

        point_2 = point_1.transform.Find("00").transform.Find("point_2").gameObject;

        point_3 = point_2.transform.transform.Find("01").Find("point_3").gameObject;

        Box = point_3.transform.Find("Box").gameObject;
        Box.SetActive(false);
    }



    /// <summary>
    /// point_1进行点头操作
    /// </summary>
    /// <param name="nodValue"></param>
    public void point_1_nod(float nodValue) {


        point_1.transform.rotation = Quaternion.Euler(new Vector3(point_1.transform.rotation.x, point_1.transform.rotation.y, nodValue));



    
    }
    /// <summary>
    /// point_2进行转头操作
    /// </summary>
    /// <param name="nodValue"></param>

    public void point_1_turned(float value)
    {

        point_1.transform.rotation = Quaternion.Euler(new Vector3(point_1.transform.rotation.x, value, point_1.transform.rotation.z));




    }
    /// <summary>
    /// point_1进行左右摆头操作
    /// </summary>
    /// <param name="nodValue"></param>
    public void point_1_swing(float value)
    {


        point_1.transform.rotation = Quaternion.Euler(new Vector3(value, point_1.transform.rotation.y, point_1.transform.rotation.z));



    }

}
