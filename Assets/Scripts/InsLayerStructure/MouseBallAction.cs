using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseBallAction : MonoBehaviour {

    public Vector3 ballFrom;
    public Vector3 ballTo;
    public Vector3 dir;
    public float dis;
    public float dis3;
    public float speed=300;


	// Use this for initialization
	void Start () {
        ballTo = getStandard(ballTo);
        ballFrom = getStandard(ballFrom);
        dir = Vector3.Normalize(ballTo-ballFrom);
        dis3 = Vector3.Distance(ballTo, ballFrom);
        dis3 = dis3 / 3f;
      
        pointDic.Add(0, this.transform.position + dir * dis3);
        pointDic.Add(1, this.transform.position + dir * dis3*2);
        pointDic.Add(2, this.transform.position + dir * dis3*3);
	}
	
	// Update is called once per frame
    Dictionary<int, Vector3> pointDic = new Dictionary<int, Vector3>();

    int index = 0;
	void Update () {

       
        if (index > 6)
        {
            Destroy(this.gameObject);
        }
        else
        {
            if (index < 3)
            {
                this.transform.position = pointDic[index];
                
            }
           
        }
        index++;
       
       

	}


    public Vector3 getStandard(Vector3 _aimVector)
    {
        _aimVector = new Vector3(_aimVector.x, 0, _aimVector.z);
        return _aimVector;
    }
}
