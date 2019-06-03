using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coordinate : MonoBehaviour {

    
    public static int selectCoord { get; set; }

    public GameObject rightCube;
    public GameObject upCube;
    public GameObject frontCube;

    private void Awake()
    {

        rightCube = this.transform.Find("rightCube").gameObject;
        upCube = this.transform.Find("upCube").gameObject;
        frontCube = this.transform.Find("frontCube").gameObject;




    }
    Ray ray;
    RaycastHit hit;
    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {

            bool successHit = Physics.Raycast(ray,out hit);
            if (successHit == true)
            {
                Debug.Log("点击了左侧标签");

                if (hit.collider.gameObject == rightCube) {

                    Debug.Log("点击了左侧标签");

                }
                if (hit.collider.gameObject == upCube)
                {

                    Debug.Log("点击了向上的Cube");

                }
                if (hit.collider.gameObject == frontCube)
                {

                    Debug.Log("点击了向前的Cube");

                }
            }
        }
        
    }


}
