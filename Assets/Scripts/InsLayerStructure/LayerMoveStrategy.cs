using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerMoveStrategy : Strategy {


   public Vector3 aimVec;
   public Vector3 initVec;
   public Vector3 normalVec;
   public Vector3 _normalVec;
   public Vector3 preVec;
   public Vector3 lastVec;
   public float dis;
    public float dis_ball;
   public float angle;
   public Vector3 dir;
   public Vector3 balldir;
   public Vector3 dirTypeObtain;
   public GameObject cube;
   public GameObject ball;
   public  Ray ray;
   public RaycastHit hit;
    float frameTime = 0;
    public Vector3 posBallfrom;
    public Vector3 posBallto;
    //public Dictionary<int, Vector3> dirType = new Dictionary<int, Vector3>();


    /// <summary>
    /// 构造函数：传参
    /// </summary>
    public LayerMoveStrategy(Vector3 _aimVec, Vector3 _initVec, GameObject
        _cube, Vector3 _dir, GameObject _ball, Vector3 _posballfrom, Vector3 _posballto)
    {
        this.aimVec = _aimVec;
        this.initVec = _initVec;
        this.cube = _cube;
        this.dir = _dir;
        this.ball = _ball;
        this.ball.transform.position = _posballfrom;

        this.posBallto = _posballto;
            this.posBallfrom=_posballfrom;
    }
    public Vector3 getStandard( Vector3 pos) {
        return new Vector3(pos.x, 0, pos.z);
    
    
    }
    public override void doSomthing()
    {
        
        //Debug.Log(dis + ":" + dir+":"+aimVec);
        posBallto = getStandard(posBallto);
        posBallfrom = getStandard(posBallfrom);
        
        balldir = Vector3.Normalize(posBallto - posBallfrom);
        Debug.Log(balldir + "pppppppppp:" + posBallto + ":" + posBallfrom);
        dis_ball = Vector3.Distance(getStandard(ball.transform.position), posBallto);
        
       
        if (dis_ball > 0.1f)
        {
            Debug.Log("球的距离" + dis_ball + "sssssssssssssssssss:" + posBallto);
            Debug.Log("sssssssssssssssssss:" + posBallto);
            ball.transform.position += balldir * Time.deltaTime * 3;
        }
      
        
    
      



       // dis = Vector3.Distance(aimVec,cube.transform.position); 
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
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
