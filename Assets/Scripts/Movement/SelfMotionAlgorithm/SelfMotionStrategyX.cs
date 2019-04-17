using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfMotionStrategyX : Strategy {

    public int code;

    Vector3 onTimeJ1;
    float j2Len;

    Vector3 aimRoEulerJ1;
    Quaternion aimRoJ1;
    float speed;


    public GameObject g;
    public SelfMotionStrategyX(GameObject _g)
    {
        j2Len = 3.75f;
        g = _g;
        speed = 10;
    }
    public static Vector3 getStandardVec(Vector3 input)
    {
        return new Vector3(input.x, 0, input.z);

    }
    public void changeJ2Value()
    {

        Vector3 BasePositiveDir = new Vector3(1, 0, 0);

        Vector3 j2ToJ3Dir = RobotA.Instance.axleDic[AxleName.J3].transform.position - RobotA.Instance.axleDic[AxleName.J2].transform.position;

        Vector3 j1DirStandard = getStandardVec(RobotA.Instance.axleDic[AxleName.J1].transform.position) - g.transform.position;


        float dis = Vector3.Distance(j1DirStandard / 2, new Vector3());
        Offset.Instance.viewOffset1 = dis;

        // Vector3 j1DirCross = Vector3.Normalize(Vector3.Cross(j1DirStandard, BasePositiveDir));

        Vector3 j1DirCross = -Vector3.Normalize(Vector3.Cross(j1DirStandard, j2ToJ3Dir));
        j1DirCross = j1DirCross = Vector3.Normalize(Vector3.Cross(j1DirStandard, j1DirCross));


        Vector3 j2AimPoint = j1DirStandard / 2 + g.transform.position + j1DirCross *( Mathf.Sqrt((j2Len * j2Len - (dis / 2) * (dis / 2))*(1+Offset.Instance.offset2))+Offset.Instance.offset+(2.878f- dis));

        Vector3 j2ToJ2AimPoint = j2AimPoint - RobotA.Instance.axleDic[AxleName.J2].transform.position;



        float Angle = Vector3.Angle(j2ToJ2AimPoint, j2ToJ3Dir);

        if ((Angle - 1) < 0.1f)
        {
            Debug.Log("低头完成！");
            return;
        }

        //
        RobotA.Instance.axleDic[AxleName.J2].transform.localEulerAngles += new Vector3(0, 0, 0.1f);

        j2ToJ2AimPoint = j2AimPoint - RobotA.Instance.axleDic[AxleName.J2].transform.position;

        j2ToJ3Dir = RobotA.Instance.axleDic[AxleName.J3].transform.position - RobotA.Instance.axleDic[AxleName.J2].transform.position;
        float Angle2 = Vector3.Angle(j2ToJ2AimPoint, j2ToJ3Dir);



        
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

    public void changeJ2Value(float offset)
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
            Debug.Log("低头完成！");
            return;
        }

        //
        RobotA.Instance.axleDic[AxleName.J2].transform.localEulerAngles += new Vector3(0, 0, 0.1f);

        j2ToJ2AimPoint = j2AimPoint - RobotA.Instance.axleDic[AxleName.J2].transform.position;

        j2ToJ3Dir = RobotA.Instance.axleDic[AxleName.J3].transform.position - RobotA.Instance.axleDic[AxleName.J2].transform.position;
        float Angle2 = Vector3.Angle(j2ToJ2AimPoint, j2ToJ3Dir);




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
    public int getCrossDir(float value)
    {


        if (value >= 0)
            return 1;

        else
            return -1;
    }

    public float setAngle1(GameObject g)
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



    public bool nextStepContition(Vector3 aimRo, Vector3 onTimeRo)
    {
         Debug.Log(Mathf.Abs(Vector3.Distance(aimRo, onTimeRo)));
         if (Mathf.Abs(Vector3.Distance(aimRo, onTimeRo)) < 1 || Mathf.Abs((Mathf.Abs(Vector3.Distance(aimRo, onTimeRo)) - 360)) < 1)
        {

            code++;
            return true;
        }
        else
        {
            return false;
        }


    }

    public override void doSomthing()
    {

        Debug.Log("策略码：" + code);
        onTimeJ1 = RobotA.Instance.axleDic[AxleName.J1].transform.localEulerAngles;
        switch (code)
        { 
            case 0:

                aimRoEulerJ1 = new Vector3(RobotA.Instance.axleDic[AxleName.J1].transform.localEulerAngles.x, setAngle1(g), RobotA.Instance.axleDic[AxleName.J1].transform.localEulerAngles.z);

                aimRoJ1 = Quaternion.Euler(aimRoEulerJ1);

                code++;

                break;

            case 1:
                RobotA.Instance.axleDic[AxleName.J1].transform.localRotation = Quaternion.LerpUnclamped(RobotA.Instance.axleDic[AxleName.J1].transform.localRotation, aimRoJ1, Time.deltaTime * speed);

                nextStepContition(aimRoEulerJ1, onTimeJ1);
                break;

            case 2:
                changeJ2Value();
                Debug.Log("执行第二次策略！");

                changeJ3Value();
                changeJ5Value();
                break;

            
            default:

                break;
        }
    }

    public override void waitting()
    {
        throw new System.NotImplementedException();
    }
}
