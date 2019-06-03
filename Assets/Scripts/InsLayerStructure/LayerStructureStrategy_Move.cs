using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerStructureStrategy_Move : Strategy {

    public GameObject Cube;
    StrategyMaster master;
    public LayerStructureStrategy_Move(GameObject cube,StrategyMaster _master)
    {
        Cube = cube;

        Cube.transform.GetComponent<Collider>().enabled = false;
        this.master = _master;

    }
    Ray ray;
    RaycastHit hit;
    public override void doSomthing()
    {

        Debug.Log("执行move策略");
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        bool isTouch  = Physics.Raycast(ray, out hit);

        if (isTouch == true)
        {

            this.Cube.transform.position = hit.point + new Vector3(0, this.Cube.transform.localScale.y/2f, 0);
        }


        if (Input.GetKeyDown(KeyCode.E))
        {

            master.endStrategy(this);
          
        }


    }

    public override void waitting()
    {


       
    }

    public override void onEnd()
    {
        this.Cube.transform.GetComponent<Collider>().enabled = true;
    }
}
