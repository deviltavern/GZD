using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfMotionManager : MonoBehaviour {


    public static SelfMotionStrategyX selfMotionStrategy;

    public static CarryToAimShapeStrategy CarryToAimStrategy;
    Ray ray;
    RaycastHit hit;
    



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            Debug.Log(OriginObject.originObj+"=="+ InsAimShape.Instance.gList.Count);

            CarryToAimStrategy = new CarryToAimShapeStrategy(OriginObject.originObj, ShapeViewPage.gList);
        }
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

        if (CarryToAimStrategy != null)
        {
            CarryToAimStrategy.doSomthing();
        }
    }



}
