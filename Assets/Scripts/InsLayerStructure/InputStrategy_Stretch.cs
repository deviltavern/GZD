using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputStrategy_Stretch : Strategy
{


    Ray ray;
    RaycastHit hit;
    public GameObject cube;
    public int speed;

    public GameObject upCube;
    public GameObject rightCube;
    public GameObject frontCube;

    /// <summary>
    /// 描述当前选择的面
    /// </summary>
    public int faceType { get; set; }
    /// <summary>
    /// 扩张箱子
    /// </summary>
    public void stretchCube(int type)
    {


        this.faceType = type;

        stretchCube();
    }

    public void stretchCube()
    {
     
        if (Input.mouseScrollDelta.y == 0)
            return;
        float scrollValue = Input.mouseScrollDelta.y;


      
        switch (this.faceType)
        {
            case 0:
                this.cube.transform.localScale += new Vector3(scrollValue, 0, 0);
                break;

            case 1:
                this.cube.transform.localScale += new Vector3(0, scrollValue, 0);
                break;


            case 2:
                this.cube.transform.localScale += new Vector3(0, 0, scrollValue);
                break;

            default:

                break;
        }
        
    }
    public InputStrategy_Stretch(GameObject _cube)
    {


        this.cube = _cube;
        // upCube = GameObject.Instantiate(ResourcesManager.prefabDic["indicateCube"], cube.transform.parent);
        //
        // rightCube = GameObject.Instantiate(ResourcesManager.prefabDic["indicateCube"], cube.transform.parent);
        // frontCube = GameObject.Instantiate(ResourcesManager.prefabDic["indicateCube"], cube.transform.parent);
        this.faceType = getFaceType(getPointToItemDir(), cube.transform.localScale);




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
    public int getFaceType(Vector3 inputValue,Vector3 inputScale)
    {

        Debug.Log(inputValue);
        Debug.Log(inputScale/2);
        Dictionary<int, float> tempDic = new Dictionary<int, float>();

        tempDic.Add(0, inputScale.x/2f);
        tempDic.Add(1, inputScale.y / 2f);
        tempDic.Add(2, inputScale.z / 2f);


        int type = -1;

        if (Mathf.Abs((int)(inputValue.x*1000)) == Mathf.Abs((int)(tempDic[0] * 1000)))
        {
            type = 0;
        }
        if (Mathf.Abs((int)(inputValue.y * 1000)) == Mathf.Abs((int)(tempDic[1] * 1000)))
        {
            type = 1;
        }
        if (Mathf.Abs((int)(inputValue.z * 1000)) == Mathf.Abs((int)(tempDic[2] * 1000)))
        {
            type = 2;
        }
   
        

        Debug.Log("选择结果："+type);
  //
  //     for (int i = 0; i < tempList.Count; i++)
  //     {
  //         tempList[i] = Mathf.Abs(tempList[i]);
  //     }
  //
  //     float max = 0;
  //
  //     for (int i = 0; i < tempList.Count; i++)
  //     {
  //         Debug.Log(tempList[i]+":"+i);
  //         if (max < tempList[i])
  //         {
  //
  //             max = tempList[i];
  //         }
  //
  //
  //     }
  //
  //     for (int i = 0; i < tempList.Count; i++)
  //
  //     {
  //         if (tempList[i] == max)
  //         {
  //             return i;
  //         }
  //     }
  //
  //
        return type;
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

    public void getDir(Vector3 inputDir)
    {
        //  Debug.Log(inputDir);
        float front = Vector3.Angle(inputDir, new Vector3(1,0,0));
  
        float right = Vector3.Angle(inputDir, new Vector3(0,1,0));


        float up = Vector3.Angle(inputDir, new Vector3(0,0,1));
        //  // Debug.Log("getDir = " + front + ":" + back + ":" + left + ":" + right);
        //  List<float> dirList = new List<float>();
        //  dirList.Add(front);
        //  dirList.Add(back);
        //  dirList.Add(left);
        //  dirList.Add(right);
        //  int dirTypeInt = getMatchDirType(dirList);
        //  Vector3 dirTypes = LayerStructureInputManager.dirType[dirTypeInt];
        //
        //  Debug.Log("方向值：" + dirTypeInt);
        // return dirTypes;

        Debug.Log(inputDir);

        Debug.Log("front:"+front+ "right:" + right + "up:" + up);
    }
    public Vector3 getPointToItemDir()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        bool isHit = Physics.Raycast(ray, out hit);

        GameObject obj = null;
        if (isHit == true)
        {
            obj = hit.collider.gameObject;

           // Debug.Log(hit.point - obj.transform.position);
        }
        return (hit.point - obj.transform.position);
    }

    public override void doSomthing()
    {
        Debug.Log("执行type：" + this.faceType);
    
        stretchCube();



    }

    public override void waitting()
    {

    }

    public override void onEnd()
    {
        
    }
}
