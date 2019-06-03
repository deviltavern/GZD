using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelfMotionAlgorithm : Strategy
{

    public GameObject initDirObjet;
    float j2Len;
    public Text txt;

    Vector3 aimRoEulerJ1;
    Vector3 aimRoEulerJ2;
    Vector3 aimRoEulerJ3;
    Vector3 aimRoEulerJ4;
    Vector3 aimRoEulerJ5;
    Vector3 aimRoEulerJ6;
    public Quaternion aimRoJ1;
    public Quaternion aimRoJ2;
    public Quaternion aimRoJ3;
    public Quaternion aimRoJ4;
    public Quaternion aimRoJ5;
    public Quaternion aimRoJ6;

    GameObject g;
    
    public SelfMotionAlgorithm(GameObject _g)
    {
        this.g = _g;
        speed = 10;
        offset = 4;
        j2Len = 3.75f;
    }

    
    public static Vector3 getStandardVec(Vector3 input)
    {
        return new Vector3(input.x, 0, input.z);

    }
    int code;
    public float offset;
    Ray ray;
    RaycastHit hit;
    
    public float offset2;
    GameObject midPoint;

    public float getAimOffset(float x,float y)
    {
        if (y == 0)
        {
            return 0.22f;
        }

        if (y == 1)
        {
            return 6.61f - 0.733f * x;
        }



        return (8.154f - 1.014f * x);
    }
    public float gDis;
    public static float getAngle(float rad)
    {
        return Mathf.Asin(rad) * Mathf.Rad2Deg;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="dir1">j3->g</param>
    /// <param name="dir2">j3->j5</param>
    /// <param name="g"></param>
    public void changeJ3Value()
    {

        Vector3 j3Dir2GHead = RobotA.Instance.axleDic[AxleName.J3].transform.position - (g.transform.position + new Vector3(0, 1.5f));

        Vector3 j3Toj5Dir = RobotA.Instance.axleDic[AxleName.J5].transform.position - RobotA.Instance.axleDic[AxleName.J3].transform.position;
        float Angle = Vector3.Angle(-j3Dir2GHead, j3Toj5Dir);

        if ((Angle - 3) < 0.1f)
        {
            code++;
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


    public float getJ1Angle()
    {


        return 0;
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
            txt.text += "目标物体xy平面距离" + gDis + "\n";
            txt.text += "offset值：" + offset + "\n";


            //Debug.DrawLine(RobotA.Instance.axleDic[AxleName.J1].transform.position, RobotA.Instance.axleDic[AxleName.J1].transform.position - j1Dir * 20, Color.red);



            //     float J3Angle = Vector3.Angle(-Vector3.Normalize(j3Dir2GHead), Vector3.Normalize(j3Toj5Dir));

            if (Input.GetKeyDown(KeyCode.V))
            {
                Debug.Log("j3 = " + J3Angle);
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                float J1Angle = Vector3.Angle(Vector3.Normalize(BaseDir), Vector3.Normalize(BasePositiveDir));
               
                
                float J2Angle = Vector3.Angle(Vector3.Normalize(-j2Dir), Vector3.Normalize(-BaseDir));
                RobotA.Instance.axleDic[AxleName.J1].transform.localEulerAngles = new Vector3(0, J1Angle);
                Debug.Log(J1Angle);
                offset = getAimOffset(gDis,g.transform.position.y);



                float dis = Vector3.Distance(j1Dir / offset, new Vector3());

                RobotA.Instance.axleDic[AxleName.J2].transform.localEulerAngles = new Vector3(0, 0, -getAngle(dis / 3.454f));
                Debug.Log("j2 = " + J2Angle);

                Debug.Log(getAngle(dis / 3.454f));
            }


        }
    }

    Vector3 j1Dir;
    Vector3 j2Dir;
    Vector3 j3Dir;
    Vector3 j4Dir;
    Vector3 j5Dir;
    Vector3 j6Dir;
    Vector3 j3Dir2GHead;
    Vector3 j3Toj5Dir;

    Vector3 j5Toj6Dir;



    float J1Angle;
    float J2Angle;
    float J3Angle;
    float J4Angle;
    float J5Angle;
    float J6Angle;
    Vector3 BaseDir;
    Vector3 BasePositiveDir;

    Vector3 onTimeJ1;
    Vector3 onTimeJ2;
    Vector3 onTimeJ3;
    Vector3 onTimeJ4;
    Vector3 onTimeJ5;
    Vector3 onTimeJ6;
    int stepIndex;
    float speed;
    public bool nextStepContition(Vector3 aimRo, Vector3 onTimeRo)
    {
       // Debug.Log(Mathf.Abs(Vector3.Distance(aimRo, onTimeRo)));
        if (Mathf.Abs(Vector3.Distance(aimRo, onTimeRo)) < 1)
        {

            stepIndex++;
            return true;
        }
        else
        {
            return false;
        }


    }

    public void changeJ2Value()
    {

        Vector3 BasePositiveDir = new Vector3(1, 0, 0);


        Vector3 j1DirStandard = getStandardVec(RobotA.Instance.axleDic[AxleName.J1].transform.position) - g.transform.position;

        float dis = Vector3.Distance(j1DirStandard / 2, new Vector3());
        Vector3 j1DirCross = Vector3.Normalize(Vector3.Cross(j1DirStandard, BasePositiveDir));

        Vector3 j2AimPoint = j1DirStandard / 2 + g.transform.position + j1DirCross * Mathf.Sqrt((j2Len * j2Len - (dis / 2) * (dis / 2)));

        Vector3 j2ToJ2AimPoint = j2AimPoint - RobotA.Instance.axleDic[AxleName.J2].transform.position;

        Vector3 j2ToJ3Dir = RobotA.Instance.axleDic[AxleName.J3].transform.position - RobotA.Instance.axleDic[AxleName.J2].transform.position;





        float Angle = Vector3.Angle(j2ToJ2AimPoint, j2ToJ3Dir);

        if ((Angle - 1) < 0.1f)
        {
            code++;
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

    public override void doSomthing()
    {

        gDis = Vector3.Distance(getStandardVec(g.transform.position), getStandardVec(RobotA.Instance.axleDic[AxleName.J1].transform.position));
        BaseDir = getStandardVec(g.transform.position) - getStandardVec(RobotA.Instance.axleDic[AxleName.J1].transform.position);
        BasePositiveDir = new Vector3(1, 0, 0);

        j1Dir = RobotA.Instance.axleDic[AxleName.J1].transform.position - g.transform.position;
        j2Dir = RobotA.Instance.axleDic[AxleName.J2].transform.position - g.transform.position;
        j3Dir = RobotA.Instance.axleDic[AxleName.J3].transform.position - g.transform.position;
        j4Dir = RobotA.Instance.axleDic[AxleName.J4].transform.position - g.transform.position;
        j5Dir = RobotA.Instance.axleDic[AxleName.J5].transform.position - g.transform.position;
        j6Dir = RobotA.Instance.axleDic[AxleName.J6].transform.position - g.transform.position;


        j3Dir2GHead = RobotA.Instance.axleDic[AxleName.J3].transform.position - (g.transform.position + new Vector3(0, 1.5f));
        j3Toj5Dir = RobotA.Instance.axleDic[AxleName.J5].transform.position - RobotA.Instance.axleDic[AxleName.J3].transform.position;

        j5Toj6Dir = RobotA.Instance.axleDic[AxleName.J6].transform.position - RobotA.Instance.axleDic[AxleName.J5].transform.position;


        Vector3 j1DirStandard = getStandardVec(RobotA.Instance.axleDic[AxleName.J1].transform.position) - g.transform.position;

        float dis = Vector3.Distance(j1DirStandard / 2, new Vector3());
        //Debug.DrawLine(RobotA.Instance.axleDic[AxleName.J1].transform.position, RobotA.Instance.axleDic[AxleName.J1].transform.position - j1Dir * 20, Color.red);
        Vector3 j2ToJ3Dir = RobotA.Instance.axleDic[AxleName.J3].transform.position - RobotA.Instance.axleDic[AxleName.J2].transform.position;


        Vector3 j1DirCross = Vector3.Normalize(Vector3.Cross(j1DirStandard, BasePositiveDir));

        Vector3 j2AimPoint = j1DirStandard / 2 + g.transform.position + j1DirCross * Mathf.Sqrt((j2Len * j2Len - (dis / 2) * (dis / 2)));

        Vector3 j2ToJ2AimPoint = j2AimPoint - RobotA.Instance.axleDic[AxleName.J2].transform.position;



        onTimeJ1 = RobotA.Instance.axleDic[AxleName.J1].transform.localEulerAngles;
        onTimeJ2 = RobotA.Instance.axleDic[AxleName.J2].transform.localEulerAngles;
        onTimeJ3 = RobotA.Instance.axleDic[AxleName.J3].transform.localEulerAngles;
        onTimeJ4 = RobotA.Instance.axleDic[AxleName.J4].transform.localEulerAngles;
        onTimeJ5 = RobotA.Instance.axleDic[AxleName.J5].transform.localEulerAngles;
        onTimeJ6 = RobotA.Instance.axleDic[AxleName.J6].transform.localEulerAngles;

        Debug.Log(this.code);
        switch (this.code)
        {
            case 0:
                //初始化J1Angle
                J1Angle = Vector3.Angle(Vector3.Normalize(BaseDir), Vector3.Normalize(BasePositiveDir));
               
                
                Vector3 J1AngleDir = Vector3.Cross(Vector3.Normalize(BaseDir), Vector3.Normalize(BasePositiveDir));
                
                J1Angle = Vector3.Normalize(J1AngleDir).y * J1Angle;

                
                J1Angle = -J1Angle;

                dis = Vector3.Distance(j1Dir / offset, new Vector3());

               // RobotA.Instance.axleDic[AxleName.J2].transform.localEulerAngles = new Vector3(0, 0,-getAngle(dis / 3.454f));
                Debug.Log("j2 = " + J2Angle);
                
              
              //  J2Angle = -getAngle(dis / 3.454f);
                Debug.Log(J1Angle);
              //  Debug.Log(J2Angle);
                aimRoEulerJ1 = new Vector3(RobotA.Instance.axleDic[AxleName.J1].transform.localEulerAngles.x, J1Angle, RobotA.Instance.axleDic[AxleName.J1].transform.localEulerAngles.z);
               // aimRoEulerJ2 = new Vector3(RobotA.Instance.axleDic[AxleName.J2].transform.localEulerAngles.x, RobotA.Instance.axleDic[AxleName.J2].transform.localEulerAngles.y, J2Angle);
                aimRoJ1 = Quaternion.Euler(aimRoEulerJ1);
               // aimRoJ2 = Quaternion.Euler(aimRoEulerJ2);
                waitting();
                break;

            case 1:

                RobotA.Instance.axleDic[AxleName.J1].transform.localRotation = Quaternion.LerpUnclamped(RobotA.Instance.axleDic[AxleName.J1].transform.localRotation, aimRoJ1, Time.deltaTime * speed);
            //    RobotA.Instance.axleDic[AxleName.J2].transform.localRotation = Quaternion.LerpUnclamped(RobotA.Instance.axleDic[AxleName.J2].transform.localRotation, aimRoJ2, Time.deltaTime * speed);

                waitting();

                nextStepContition(aimRoEulerJ1, onTimeJ1);

             //   nextStepContition(aimRoEulerJ2, onTimeJ2);

                

                if (stepIndex > 2) {

                    code++;
                }
                
                break;

            case 2:
                changeJ2Value();
                break;

            case 3:

               
                changeJ3Value();
                break;


            case 4:

                changeJ5Value();
                Debug.Log("第四步！");

                break;

            default:

                break;
        }



    }

    public override void waitting()
    {
        switch (code)
        { 
            case 0:

                code++;
                break;

            case 1:
                
                break;
        }

    }

    public override void onEnd()
    {
        throw new System.NotImplementedException();
    }
}
