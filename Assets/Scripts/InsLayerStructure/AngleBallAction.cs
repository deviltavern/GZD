using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AngleBallAction : MonoBehaviour {

    public Vector3 ballfrom;
    public Vector3 ballto;
    public Vector3 standardDir;
    public Vector3 dir;
    public float dis;
    public float dis6;
    public float speed = 30;
    public float Angle;
    public float standardAngle;
    public Vector3 p1;
    public Vector3 p2;
    public Vector3 p2_dir;
    public float p2_dis;
    public Vector3 p3;
    public Vector3 p3_dir;
    public float p3_dis;
    public Vector3 p4;
    public Vector3 p4_dir;
    public float p4_dis;
    public Vector3 p5;
    public Text label;
    public Dictionary<int,Vector3> AnglePosDic = new Dictionary<int ,Vector3>();



	// Use this for initialization
	void Start () {

    //   Vector3 tto;
    //   Vector3 from;
    //   tto = getStandard(ballto);
    //   from = getStandard(ballfrom);
    //   dir = Vector3.Normalize(tto - from);
    //   dis6 = Vector3.Distance(ballto, ballfrom);
    //   
    //   standardAngle = Angle / 5f;
    //   dis6 = dis6 / 6f;
    //   p1 = ballto + standardDir * 2;
    //   p5 = ballfrom + dir * 2;
    //   //p3
    //   p3_dir = Vector3.Normalize(p5 - p1);
    //   p3_dis = Vector3.Distance(p5, p1);
    //   p3 = p5 + p3_dir * (p3_dis / 2);
    //   //p2
    //   p2_dir = Vector3.Normalize(p3 - p1);
    //   p2_dis = Vector3.Distance(p3, p1);
    //   p2 = p3 + p2_dir * (p2_dis / 2);
    //   //p4
    //   p4_dir = Vector3.Normalize(p5 - p3);
    //   p4_dis = Vector3.Distance(p5, p3);
    //   p4 = p5 + p4_dir * (p4_dis / 2);
    //



        AnglePosDic.Add(0, ballfrom);
        AnglePosDic.Add(1, ballto);
     //   AnglePosDic.Add(2, p3);
     //   AnglePosDic.Add(3, p4);
   //     AnglePosDic.Add(4, p5);

	}
    int index = 0;
    void Update()
    {


        if (index > 4)
        {
            Destroy(this.gameObject);
          Destroy(this.label.gameObject);
        }
        else

            if (index <2)
            {
                this.transform.position = AnglePosDic[index];
                
                this.label.text = "角度：" + Angle;
            
            }

      
        index++;

     
      

    }
    public Vector3 getStandard(Vector3 vector) {

        vector = new Vector3(vector.x, 0, vector.z);
        return vector;
    }
}
