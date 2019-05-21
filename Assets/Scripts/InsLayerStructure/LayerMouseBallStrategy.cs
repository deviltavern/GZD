using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerMouseBallStrategy : Strategy
{

    public Vector3 aimVec;
    public Vector3 initVec;
    public Vector3 posBallto;
    public Vector3 posBallfrom;
    public Vector3 preVec;
    public Vector3 lastVec;
    public float dis;
    public float dis_ball;
    public float angle;
    public GameObject ball;
    public Vector3 dir_ball;
    public Vector3 normalVec;
    public Vector3 dir;
    public LayerMouseBallStrategy(Vector3 _preVec, Vector3 _lastVec,  GameObject _ball, Vector3 _posballfrom, Vector3 _posballto)
    {
        this.preVec = _preVec;
        this.lastVec = _lastVec;
 
        this.ball = _ball;
        this.ball.transform.position = _posballfrom;

        this.posBallto = _posballto;
        this.posBallfrom = _posballfrom;
    }
    public Vector3 getStandard(Vector3 pos)
    {
        return new Vector3(pos.x, 0, pos.z);


    }
    public override void doSomthing()
    {
       
        posBallfrom = getStandard(posBallfrom);
        posBallto = getStandard(posBallto);
        dir_ball = Vector3.Normalize(posBallto - posBallfrom);

        dis_ball = Vector3.Distance(getStandard(ball.transform.position), posBallto);

        if (dis_ball > 0.1f)
        {
            Debug.Log("球的距离" + dis_ball + "sssssssssssssssssss:" + posBallto);
            Debug.Log("sssssssssssssssssss:" + posBallto);
            ball.transform.position += dir_ball * Time.deltaTime * 3;
        }

        dis = Vector3.Distance(aimVec, initVec);
        normalVec = Vector3.Normalize(aimVec - initVec);

        //_normalVec归一化
        angle = Vector3.Angle(normalVec, dir);
        Debug.Log("角度" + angle);
        if (dis > 0.1f)
        {
            // cube.transform.position += dir * Time.deltaTime * 30;
        }

    }

    public override void waitting()
    {
       
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
