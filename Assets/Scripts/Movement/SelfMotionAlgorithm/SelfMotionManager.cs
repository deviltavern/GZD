using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfMotionManager : MonoBehaviour {


    public SelfMotionStrategyX selfMotionStrategy;


    Ray ray;
    RaycastHit hit;
    void Update()
    {

        if (Input.GetKey(KeyCode.Z))
        {


            if (Input.GetMouseButtonDown(0))
            {

                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                bool isHit = Physics.Raycast(ray, out hit);

                if (isHit == true)
                {

                    GameObject g = hit.collider.gameObject;
                    selfMotionStrategy = new SelfMotionStrategyX(g);

                }



            }
        }

        if (selfMotionStrategy != null)
        {
            Debug.Log("执行策略！");
            selfMotionStrategy.doSomthing();
        }
    
    }



}
