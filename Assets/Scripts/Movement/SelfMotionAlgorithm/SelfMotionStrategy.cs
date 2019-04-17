using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelfMotionStrategy : MonoBehaviour {


    public int code { get; set; }

    public GameObject initDirObjet;
    float j3InitY;
    public Text txt;

    public float j2Len = 0;

    public float gAimHead = 0;
    public void Start()
    {
        
        j3InitY = RobotA.Instance.axleDic[AxleName.J3].transform.position.y;
        initDirObjet = GameObject.Find("initDirObjet");
        offset = 4;

        j2Len = 3.75f;
    }
    public static Vector3 getStandardVec(Vector3 input)
    {
        return new Vector3(input.x, 0, input.z);

    }

    public float offset;
    Ray ray;
    RaycastHit hit;
    GameObject g;
    public float offset2;
    GameObject midPoint;


    public float gDis;
    public static float getAngle(float rad)
    {
        return Mathf.Asin(rad) * Mathf.Rad2Deg;
    }

 
    public void changeJ2Value()
    {

        Vector3 BasePositiveDir = new Vector3(1, 0, 0);

        Vector3 j2ToJ3Dir = RobotA.Instance.axleDic[AxleName.J3].transform.position - RobotA.Instance.axleDic[AxleName.J2].transform.position;

        Vector3 j1DirStandard = getStandardVec(RobotA.Instance.axleDic[AxleName.J1].transform.position) - g.transform.position;

        float dis = Vector3.Distance(j1DirStandard / 2, new Vector3());
        // Vector3 j1DirCross = Vector3.Normalize(Vector3.Cross(j1DirStandard, BasePositiveDir));

        Vector3 j1DirCross = -Vector3.Normalize(Vector3.Cross(j1DirStandard, j2ToJ3Dir));
        j1DirCross = j1DirCross = Vector3.Normalize(Vector3.Cross(j1DirStandard, j1DirCross));


        Vector3 j2AimPoint = j1DirStandard / 2 + g.transform.position + j1DirCross * Mathf.Sqrt((j2Len * j2Len - (dis / 2) * (dis / 2)));

        Vector3 j2ToJ2AimPoint = j2AimPoint - RobotA.Instance.axleDic[AxleName.J2].transform.position;



        float Angle = Vector3.Angle(j2ToJ2AimPoint, j2ToJ3Dir);

        if ((Angle - 1) < 0.1f)
        {
            return;
        }

        //
        RobotA.Instance.axleDic[AxleName.J2].transform.localEulerAngles += new Vector3(0, 0, 0.1f);

        j2ToJ2AimPoint = j2AimPoint - RobotA.Instance.axleDic[AxleName.J2].transform.position;

        j2ToJ3Dir = RobotA.Instance.axleDic[AxleName.J3].transform.position - RobotA.Instance.axleDic[AxleName.J2].transform.position;
        float Angle2 = Vector3.Angle(j2ToJ2AimPoint, j2ToJ3Dir);



        Debug.Log(Angle2 + ":" + Angle);
        if (Angle2 > Angle)
        {
            Debug.Log("不符合规则！");
            RobotA.Instance.axleDic[AxleName.J2].transform.localEulerAngles -= new Vector3(0, 0, 0.2f);


            Debug.Log(Angle2 + ":" + Angle);
        }
        else
        {
            Debug.Log("符合规则！");

        }


    }

    public void changeJ3Value()
    {

        Vector3 j3Dir2GHead = RobotA.Instance.axleDic[AxleName.J3].transform.position - (g.transform.position + new Vector3(0, 1.5f));

        Vector3 j3Toj5Dir = RobotA.Instance.axleDic[AxleName.J5].transform.position - RobotA.Instance.axleDic[AxleName.J3].transform.position;
        float Angle = Vector3.Angle(-j3Dir2GHead, j3Toj5Dir);

        if ((Angle - 3) < 0.1f)
        {
            return;
        }


        RobotA.Instance.axleDic[AxleName.J3].transform.localEulerAngles += new Vector3(0, 0, 0.1f);

        j3Dir2GHead = RobotA.Instance.axleDic[AxleName.J3].transform.position - (g.transform.position + new Vector3(0, 1.5f));
        j3Toj5Dir = RobotA.Instance.axleDic[AxleName.J5].transform.position - RobotA.Instance.axleDic[AxleName.J3].transform.position;

        //重新修正两个向量
        float Angle2 = Vector3.Angle(-j3Dir2GHead, j3Toj5Dir);

        // Debug.Log(RobotA.Instance.axleDic[AxleName.J3].transform.localRotation.z);

        //Debug.Log("初始状态：" + Angle + "-叠加态：" + Angle2 + "叠加态2" + Mathf.Abs(180 - Angle2));
        //  Debug.Log(Angle);

        if (Angle2 > Angle)
        {
            Debug.Log("不符合规则！");
            RobotA.Instance.axleDic[AxleName.J3].transform.localEulerAngles -= new Vector3(0, 0, 0.2f);



        }
        else
        {
            Debug.Log("符合规则！");

        }
    }


    public void changeJ3Value2()
    {

        Vector3 j3Dir2GHead = RobotA.Instance.axleDic[AxleName.J3].transform.position - (g.transform.position + new Vector3(0, 1.3f));

        Vector3 j3Toj5Dir = RobotA.Instance.axleDic[AxleName.J5].transform.position - RobotA.Instance.axleDic[AxleName.J3].transform.position;
        float Angle = Vector3.Angle(-j3Dir2GHead, j3Toj5Dir);

        if ((Angle) < 0.1f)
        {
            return;
        }


        RobotA.Instance.axleDic[AxleName.J3].transform.localEulerAngles -= new Vector3(0, 0, 0.1f);

        j3Dir2GHead = RobotA.Instance.axleDic[AxleName.J3].transform.position - (g.transform.position + new Vector3(0, 1.5f));

        //重新修正两个向量
        float Angle2 = Vector3.Angle(-j3Dir2GHead, j3Toj5Dir);

        // Debug.Log(RobotA.Instance.axleDic[AxleName.J3].transform.localRotation.z);

        //Debug.Log("初始状态：" + Angle + "-叠加态：" + Angle2 + "叠加态2" + Mathf.Abs(180 - Angle2));
        //  Debug.Log(Angle);


        Debug.Log(Angle + ":" + Angle2);
        if (Angle2 > Angle)
        {

            if (Mathf.Abs(Angle2 - 180) < Angle)
            {
                Debug.Log("符合规则");
            }
            else
            {
                Debug.Log("不符合规则！");

                RobotA.Instance.axleDic[AxleName.J3].transform.localEulerAngles += new Vector3(0, 0, 0.1f);


            }


        }
        else
        {
            Debug.Log("符合规则！");

        }
    }

    public int getCrossDir(float value)
    {
        if (value >= 0)
            return 1;

        else
            return -1;
    }

    public void changeJ5Value()
    {

        Vector3 j5Dir = RobotA.Instance.axleDic[AxleName.J6].transform.position - g.transform.position;

        Vector3 j5Toj6Dir = RobotA.Instance.axleDic[AxleName.J6].transform.position - RobotA.Instance.axleDic[AxleName.J5].transform.position;
        float Angle = Vector3.Angle(-j5Dir, j5Toj6Dir);

        if ((Angle - 3) < 0.1f)
        {
            return;
        }


        RobotA.Instance.axleDic[AxleName.J5].transform.localEulerAngles -= new Vector3(0, 0, 0.1f);
        j5Dir = RobotA.Instance.axleDic[AxleName.J6].transform.position - g.transform.position;

        j5Toj6Dir = RobotA.Instance.axleDic[AxleName.J6].transform.position - RobotA.Instance.axleDic[AxleName.J5].transform.position;
        float Angle2 = Vector3.Angle(-j5Dir, j5Toj6Dir);

        // Debug.Log(RobotA.Instance.axleDic[AxleName.J3].transform.localRotation.z);

        //Debug.Log("初始状态：" + Angle + "-叠加态：" + Angle2 + "叠加态2" + Mathf.Abs(180 - Angle2));
        //  Debug.Log(Angle);



        if (Angle2 > Angle)
        {

            if (Mathf.Abs(Angle2 - 180) < Angle)
            {
                Debug.Log("符合规则");
            }
            else
            {
                Debug.Log("不符合规则！");

                RobotA.Instance.axleDic[AxleName.J5].transform.localEulerAngles += new Vector3(0, 0, 0.2f);


            }


        }
        else
        {
            Debug.Log("符合规则！");

        }
    }
    void Update()
    {


        if (Input.GetMouseButtonDown(0))
        {

            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            bool isHit = Physics.Raycast(ray, out hit);

            if (isHit == true)
            {

                g = hit.collider.gameObject;


            }



        }

        if (g != null)
        {

            if (Input.GetKey(KeyCode.B))
            {

                changeJ3Value();

            }

            if (Input.GetKey(KeyCode.C))
            {

                changeJ5Value();

            }

            txt.text = "";
            txt.text += "目标物体xyz平面距离" + gDis + "\n";
            txt.text += "offset值：" + offset + "\n";
            txt.text += "j3InitY:" + j3InitY + "\n";


            txt.text += "gY:" + g.transform.position.y;

         
            gDis = Vector3.Distance(getStandardVec(g.transform.position), getStandardVec(RobotA.Instance.axleDic[AxleName.J1].transform.position));
            Vector3 BaseDir = getStandardVec(g.transform.position) - getStandardVec(RobotA.Instance.axleDic[AxleName.J1].transform.position);
            Vector3 BasePositiveDir = new Vector3(1, 0, 0);

            Vector3 j1Dir = RobotA.Instance.axleDic[AxleName.J1].transform.position - g.transform.position;
            Vector3 j2Dir = RobotA.Instance.axleDic[AxleName.J2].transform.position - g.transform.position;
            Vector3 j3Dir = RobotA.Instance.axleDic[AxleName.J3].transform.position - g.transform.position;
            Vector3 j4Dir = RobotA.Instance.axleDic[AxleName.J4].transform.position - g.transform.position;
            Vector3 j5Dir = RobotA.Instance.axleDic[AxleName.J5].transform.position - g.transform.position;
            Vector3 j6Dir = RobotA.Instance.axleDic[AxleName.J6].transform.position - g.transform.position;


            Vector3 j3Dir2GHead = RobotA.Instance.axleDic[AxleName.J3].transform.position - (g.transform.position + new Vector3(0, 1.5f));

            Vector3 j3Toj5Dir = RobotA.Instance.axleDic[AxleName.J5].transform.position - RobotA.Instance.axleDic[AxleName.J3].transform.position;
            //Debug.DrawLine(RobotA.Instance.axleDic[AxleName.J1].transform.position, RobotA.Instance.axleDic[AxleName.J1].transform.position - j1Dir * 20, Color.red);

            #region J2旋转相关

            //相关向量

            Vector3 j1DirStandard = getStandardVec(RobotA.Instance.axleDic[AxleName.J1].transform.position) - g.transform.position;
            Vector3 g2Vec = g.transform.position + new Vector3(0, 0, 0.2f);


            Vector3 j1DirStandardFromG2Vec = getStandardVec(RobotA.Instance.axleDic[AxleName.J1].transform.position) - g2Vec;

            Vector3 j2ToJ3Dir = RobotA.Instance.axleDic[AxleName.J3].transform.position - RobotA.Instance.axleDic[AxleName.J2].transform.position;




            Vector3 j1DirCross = -Vector3.Normalize(Vector3.Cross(j1DirStandard, j2ToJ3Dir));


            j1DirCross = Vector3.Normalize(Vector3.Cross(j1DirStandard, j1DirCross));
            Vector3 J1AngleDir = Vector3.Cross(Vector3.Normalize(BaseDir), Vector3.Normalize(BasePositiveDir));

            float dis = Vector3.Distance(j1DirStandard / 2, new Vector3());



            //主要点
            Vector3 j2AimPoint = j1DirStandard / 2 + g.transform.position + j1DirCross * Mathf.Sqrt((j2Len * j2Len - (dis / 2) * (dis / 2)));

            j2AimPoint = j2AimPoint * getCrossDir(Vector3.Normalize(J1AngleDir).y);


            Debug.DrawLine(getStandardVec(RobotA.Instance.axleDic[AxleName.J1].transform.position), getStandardVec(RobotA.Instance.axleDic[AxleName.J1].transform.position) + BasePositiveDir * 20, new Color(139 / 255f, 69 / 255f, 19 / 255f));

            Debug.DrawLine(getStandardVec(RobotA.Instance.axleDic[AxleName.J1].transform.position), getStandardVec(RobotA.Instance.axleDic[AxleName.J1].transform.position) - j1DirStandardFromG2Vec * 20, new Color(4 / 255f, 69 / 255f, 19 / 255f));



            //画图



            #endregion




            Debug.Log("方向" + getCrossDir(J1AngleDir.y));


            Vector3 j2ToJ2AimPoint = j2AimPoint - RobotA.Instance.axleDic[AxleName.J2].transform.position;



            Debug.DrawLine(j1DirStandard / 2 + g.transform.position, j1DirStandard / 2 + g.transform.position + j1DirCross * 20, Color.green);

            Debug.DrawLine(g.transform.position, g.transform.position + j1DirStandard * 20, Color.green);
            Debug.DrawLine(RobotA.Instance.axleDic[AxleName.J2].transform.position, RobotA.Instance.axleDic[AxleName.J2].transform.position + j2ToJ2AimPoint * 20, Color.green);
            Debug.DrawLine(RobotA.Instance.axleDic[AxleName.J2].transform.position, RobotA.Instance.axleDic[AxleName.J2].transform.position + j2ToJ3Dir * 20, new Color(0, 250 / 255f, 154 / 255f));


            Vector3 j5Toj6Dir = RobotA.Instance.axleDic[AxleName.J6].transform.position - RobotA.Instance.axleDic[AxleName.J5].transform.position;
            Debug.DrawLine(RobotA.Instance.axleDic[AxleName.J2].transform.position, RobotA.Instance.axleDic[AxleName.J2].transform.position - j2Dir * 20, Color.red);
            Debug.DrawLine(RobotA.Instance.axleDic[AxleName.J3].transform.position, RobotA.Instance.axleDic[AxleName.J3].transform.position - j3Dir * 20, Color.red);
            // Debug.DrawLine(RobotA.Instance.axleDic[AxleName.J4].transform.position, RobotA.Instance.axleDic[AxleName.J4].transform.position - j4Dir * 20, Color.red);
            Debug.DrawLine(RobotA.Instance.axleDic[AxleName.J5].transform.position, RobotA.Instance.axleDic[AxleName.J5].transform.position - j5Dir * 20, Color.red);
            // Debug.DrawLine(RobotA.Instance.axleDic[AxleName.J6].transform.position, RobotA.Instance.axleDic[AxleName.J6].transform.position - j6Dir * 20, Color.red);
            Debug.DrawLine(getStandardVec(g.transform.position), -BaseDir * 20);
            Debug.DrawLine(getStandardVec(g.transform.position), getStandardVec(g.transform.position) + new Vector3(0, 20, 0));
            // Debug.DrawLine(getStandardVec(RobotA.Instance.axleDic[AxleName.J1].transform.position), getStandardVec(RobotA.Instance.axleDic[AxleName.J1].transform.position) + BasePositiveDir * 20);

            Debug.DrawLine(RobotA.Instance.axleDic[AxleName.J1].transform.position - j1Dir / offset, RobotA.Instance.axleDic[AxleName.J1].transform.position - (j1Dir / offset) + new Vector3(0, 10, 0));

            Debug.DrawLine(RobotA.Instance.axleDic[AxleName.J3].transform.position, getStandardVec(RobotA.Instance.axleDic[AxleName.J3].transform.position) + j3Toj5Dir * 20, Color.blue);
            Debug.DrawLine(g.transform.position + new Vector3(0, 1.5f), g.transform.position + new Vector3(0, 1.5f) + j3Dir2GHead * 20, Color.yellow);
            Debug.DrawLine(g.transform.position + new Vector3(0, 1.5f), g.transform.position + new Vector3(0, 1.5f) - j3Dir2GHead * 20, Color.yellow);


            Debug.DrawLine(RobotA.Instance.axleDic[AxleName.J5].transform.position, RobotA.Instance.axleDic[AxleName.J5].transform.position + j5Toj6Dir * 20, Color.gray);

            float J3Angle = Vector3.Angle(-Vector3.Normalize(j3Dir2GHead), Vector3.Normalize(j3Toj5Dir));

            float Angle = Vector3.Angle(j2ToJ2AimPoint, j2ToJ3Dir);



            //float dis = Vector3.Distance(j1Dir / offset, new Vector3());

            // RobotA.Instance.axleDic[AxleName.J2].transform.localEulerAngles = new Vector3(0, 0, -getAngle(dis / 3.454f));
            if (Input.GetKeyDown(KeyCode.V))
            {
                Debug.Log("j3 = " + J3Angle);
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
              
                //RobotA.Instance.axleDic[AxleName.J2].transform.localEulerAngles = new Vector3(0, 0,-J2Angle);

                setAngle1();


            }

            if (Input.GetKey(KeyCode.N))
            {
                changeJ2Value();

            }



        }
    }

    // RobotA.Instance.axleDic[AxleName.J1].transform.localEulerAngles = new Vector3(0, J1Angle);

    public float setAngle1()
    {

        Vector3 BaseDir = getStandardVec(g.transform.position) - getStandardVec(RobotA.Instance.axleDic[AxleName.J1].transform.position);
        Vector3 BasePositiveDir = new Vector3(1, 0, 0);
        float J1Angle = Vector3.Angle(Vector3.Normalize(BaseDir), Vector3.Normalize(BasePositiveDir));
        //float J2Angle = Vector3.Angle(Vector3.Normalize(-j2Dir), Vector3.Normalize(-BaseDir));
        Vector3 j1DirStandard = getStandardVec(RobotA.Instance.axleDic[AxleName.J1].transform.position) - g.transform.position;
        float dis = Vector3.Distance(j1DirStandard / 2, new Vector3());
        Vector3 J1AngleDir = Vector3.Cross(Vector3.Normalize(BaseDir), Vector3.Normalize(BasePositiveDir));
        J1Angle = getCrossDir(Vector3.Normalize(J1AngleDir).y) * J1Angle;
        J1Angle = -J1Angle;


        return J1Angle;
    
    }




    public void doSomthing()
    {
        switch (code)
        { 
            case 0:


                break;
        }
    }

    public void waitting()
    {
        throw new System.NotImplementedException();
    }
}
