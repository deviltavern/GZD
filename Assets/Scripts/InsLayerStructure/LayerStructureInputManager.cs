using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LayerStructureInputManager : MonoBehaviour {
    Vector3 dirTypeObtain;
    Vector3 posBallfrom;
    Vector3 posBallto;
    Vector3 initCirclePos;
	// Use this for initialization
    Vector3 initCircleDir;
 
    Vector3 p1;
    Vector3 p5;
 Ray ray;
   RaycastHit hit;
   public GameObject ball;
  public static Dictionary<int, Vector3> dirType = new Dictionary<int, Vector3>();
  public MouseBallAction mouseBall;
  public AngleBallAction mouseAngle;
  public MouseLabelAction mouseLabel;
  
    /// <summary>
  /// 声明策略
  /// </summary>
    public Strategy strategy { get; set; }
    public Strategy strategyMouseBall { get; set; }

	void Start () {
        dirType.Add(0, Vector3.forward);
        dirType.Add(1,Vector3.back);
        dirType.Add(2,Vector3.left);
        dirType.Add(3, Vector3.right);
	}

   
    // 定义两个向量 lastVec、preVec
    Vector3 lastVec;
    Vector3 preVec;
    Vector3 dir;
    Vector3 initBall_pos;
	// Update is called once per frame

    float frameTime = 0;


    
    public void insLine(Vector3 from,Vector3 to)
    {

        getBall = initGetBall(initBall, from);
        mouseBall = getBall.AddComponent<MouseBallAction>();
        mouseBall.ballFrom = from;
        mouseBall.ballTo = to;
                    
    }



    public void insCircle(Vector3 from, Vector3 to,float _angel) {
        getCircle = initGetBall(initBall, from);
        mouseAngle = getCircle.AddComponent<AngleBallAction>();
        mouseAngle.ballfrom = from;
        mouseAngle.ballto = to;
        mouseAngle.label = initGetLable(initAngleLabel, Camera.main.WorldToScreenPoint(to));
        mouseAngle.Angle = (180-_angel);
       
        mouseAngle.transform.position = from;
    
    }


    

    float frameTime2 = 0;
    float dis;
     GameObject Cube;
    public GameObject initBall;
    public GameObject getBall;
    public GameObject getCircle;
    public GameObject getAngleLabel;
    public Text initAngleLabel;
	void Update () {
        if (strategy != null)
        {
            strategy.doSomthing();
            Debug.Log("执行策略");
        }

        if (strategyMouseBall != null)
        {
            strategyMouseBall.doSomthing();
            Debug.Log("执行策略");
        }


        if (Input.GetMouseButtonDown(0))
        {
          

            lastVec = getInputPosition();
            posBallfrom = hit.point;

            //按下左键后，获取相机拍摄下的鼠标点击的位置，
            //lastVec与preVec的位置，y取消，用来计算方向。

           
            if (hit.collider.tag == "Box")
            {
           //     hit.collider.gameObject.transform.position += dirTypeObtain * Time.deltaTime * 30;
               Cube = hit.collider.gameObject;
                //hit检测碰撞到的物体（tag标记为Box）,Cube

            }

        }


        if (Cube != null)
        {
            if (Input.GetMouseButton(0))

            {
                //实时时间frameTime箱子时间
                frameTime += Time.deltaTime;
                preVec = getInputPosition();

                if (frameTime > Time.deltaTime * 50)
                {
                    //Time.deltaTime渲染时间 ，鼠标移动时间记录，5帧
                    frameTime = 0;
                    dir = (preVec - lastVec);
                    preVec = lastVec;
                    //计算方向dir(鼠标方向)后，重设preVec

                    dirTypeObtain = getDir(dir);

                    //计算方向dirTypeObtain(四正方向)后，重设preVec

                }


                frameTime2 += Time.deltaTime;
                //实时时间frameTime2，用来记录ball的时间
                if (frameTime2 > Time.deltaTime * 3)
                {
                    frameTime2 = 0;
                    //每隔3帧
                    insLine(posBallfrom, getInputPosition());
                    //生成第一个球
                    Vector3 tempDir = getDir(getStandard(getInputPosition()), getStandard(posBallfrom));
                    //规正方向tempDir
                    float tempAngle = Vector3.Angle(tempDir,Vector3.Normalize(getStandard(getInputPosition())- getStandard(posBallfrom)));
                    //求夹角
                   // float cosValue = Mathf.Abs(Mathf.Cos(tempAngle * Mathf.PI / 180f));
                    //求cos夹角
                    float cosValue = Mathf.Cos(tempAngle * Mathf.PI / 180f);
                    Debug.Log(180 - tempAngle + ":" + cosValue);
                    Vector3 tempPosition = posBallfrom + tempDir * cosValue * Vector3.Distance(getStandard(getInputPosition()), getStandard(posBallfrom));
//初始圆圈的位置： 距离
                   
                    initCircleDir = Vector3.Normalize(posBallfrom - getInputPosition());
                    initCirclePos = posBallfrom + initCircleDir * 2;
                    float lengh = getOnTimeMouseLenthFromSourceDir(posBallfrom) / 10;
                    p1 = posBallfrom + getOnTimeMousePointFromSourceDir(posBallfrom) * lengh;
                    p5 = posBallfrom -tempDir * lengh;


                    insCircle(p1, p5, tempAngle);
                    Debug.Log("p1:" + p1 + "-----+p5:" + p5);
                    insLine(posBallfrom, tempPosition);

                    insLine(tempPosition,getInputPosition());
                
                }
              
               // this.strategyMouseBall = new LayerMouseBallStrategy(preVec, lastVec, getBall, posBallfrom, posBallto);
            }





            //

            //旋转
            if (Input.GetMouseButtonDown(1))
            {
                if (hit.collider.tag == "Box")
                {
                    hit.collider.gameObject.transform.Rotate(Vector3.up, 30);
                }
            }

        }






        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("抬起");

            posBallto = hit.point;  
            //    this.strategy = new LayerMoveStrategy(preVec, lastVec, Cube, dirTypeObtain, ball, posBallfrom,posBallto);
          

        }



		
	}


    public Vector3 getStandard(Vector3 pos)
    {
        return new Vector3(pos.x, 0, pos.z);


    }
    public GameObject initGetBall(GameObject _initBall, Vector3 _posBallfrom)
    { 
     //生成球---第0帧
        _initBall = GameObject.Instantiate(LayerStructureItem.Instance.InsLayerball, LayerStructureItem.Instance.transform);
            _initBall.transform.position = _posBallfrom;
            return _initBall;
    
    }
    public Text initGetLable(Text _initAngelLable,Vector3 _p5)
    {
        //生成球---第0帧
        _initAngelLable = GameObject.Instantiate(LayerStructureItem.Instance.InsAngelLabel, CanvasManager.canvas.transform);
        _initAngelLable.transform.position = _p5;
        return _initAngelLable;

    }



    public int getMatchDirType(List<float> list)
    {

        float value = getMin(list);//得到最小值
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i] == value)
            {
                return i;
            }
        }

        return 0;

    }
    public float getMin(List<float> list)
    {

        float min = list[0];
        foreach (float num in list)
        {
            if (min > num)
            {
                min = num;
            }
        }
        return min;
    }

    /// <summary>
    /// 得到一个方向，这个方向从SourceDir只想当前鼠标
    /// </summary>
    /// <param name="sourceDir"></param>
    /// <returns></returns>
    public Vector3 getOnTimeMousePointFromSourceDir(Vector3 sourceDir)
    {
        Vector3 dir = Vector3.Normalize(getStandard(getInputPosition()) - getStandard(sourceDir));

        return dir;

    }
    /// <summary>
    /// 得到一个长度，这个长度从SourceDir指向鼠标Point
    /// </summary>
    /// <param name="sourceDir"></param>
    /// <returns></returns>
    public float getOnTimeMouseLenthFromSourceDir(Vector3 sourceDir)
    {
        float dir = Vector3.Distance(getStandard(getInputPosition()),getStandard(sourceDir));

        return dir;

    }
    public Vector3 getDir(Vector3 from, Vector3 to)
    {
        Vector3 inputDir = Vector3.Normalize(to - from);

        return getDir(inputDir);
    }

    public Vector3 getDir(Vector3 inputDir)
    {
      //  Debug.Log(inputDir);
        float front = Vector3.Angle(inputDir, Vector3.forward);
        float back = Vector3.Angle(inputDir, Vector3.back);
        float left = Vector3.Angle(inputDir, Vector3.left);
        float right = Vector3.Angle(inputDir, Vector3.right);

        // Debug.Log("getDir = " + front + ":" + back + ":" + left + ":" + right);
        List<float> dirList = new List<float>();
        dirList.Add(front);
        dirList.Add(back);
        dirList.Add(left);
        dirList.Add(right);
        int dirTypeInt = getMatchDirType(dirList);
        Vector3 dirTypes = LayerStructureInputManager.dirType[dirTypeInt];

        Debug.Log("方向值：" + dirTypeInt);
        return dirTypes;
    }

    /// <summary>
    /// getInputPosition  取消y的值，方便计算方向
    /// </summary>
    /// <returns></returns>
    public Vector3 getInputPosition()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        bool isTouch = Physics.Raycast(ray, out hit);
        if (isTouch == true)
        {
            Vector3 pos = hit.point;
            //  Debug.Log(pos);
            return new Vector3(pos.x, 0.5f, pos.z);
        }
        else
        {
            return new Vector3();
        }

    }
    public Vector3 getInputPosition(float y)
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        bool isTouch = Physics.Raycast(ray, out hit);
        if (isTouch == true)
        {
            Vector3 pos = hit.point;
            //  Debug.Log(pos);
            return new Vector3(pos.x, y, pos.z);
        }
        else
        {
            return new Vector3();
        }

    }
}
