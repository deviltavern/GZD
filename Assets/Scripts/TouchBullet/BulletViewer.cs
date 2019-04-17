using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletViewer : ObviewerTemplates
{

    public Vector3 dir { get; set; }
    void OnTriggerEnter(Collider co)
    {
        switch (co.tag)
        { 
            case "PosItem":
                ViewInfo info = new ViewInfo();
                info.code = 1;
                info.aimObje = co.gameObject;
                broadCast(info);


                break;

            default:

                break;
        }
    }

    void Update()
    {
        this.transform.position += dir * Time.deltaTime * 20;
    }
}
