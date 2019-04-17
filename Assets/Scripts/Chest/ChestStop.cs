using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestStop : MonoBehaviour,IViewer {


    Vector3 lastVec;

    int frameTime = 0;

    RaycastHit hit;
    public GameObject posItem;
    void Awake()
    {
       GameObject insBullet = GameObject.Instantiate(ResourcesManager.prefabDic["bullet"],this.transform.position,Quaternion.identity);

       BulletViewer obViewer = insBullet.GetComponent<BulletViewer>();
       obViewer.addViewer(this);
       obViewer.dir = Vector3.Normalize(new Vector3(0, -1, 0));
    }

    void Update()
    {
        if (this.posItem != null)
        {

            this.transform.SetParent(this.posItem.transform);

            this.transform.localPosition += Vector3.Normalize(new Vector3() - this.transform.localPosition) * Time.deltaTime * 5;

            if (Vector3.Distance(this.transform.localPosition, new Vector3()) < 0.1f)
            {
                this.transform.localPosition = new Vector3(); 
            }
        }
       // this.transform.position += new Vector3(0, -1, 0) * Time.deltaTime * 10;
    // bool isHit = Physics.Raycast(this.gameObject.transform.position, this.gameObject.transform.position + new Vector3(0, -1, 0), out hit, 50);
    //
    // if (isHit == true)
    // {
    //     Debug.Log(hit.collider.tag);
    //     Debug.Log(hit.collider.gameObject.name);
    //     if (hit.collider.tag == "PosItem")
    //     {
    //         posItem = hit.collider.gameObject;
    //
    //        
    //     }
    //
    // }


      Debug.DrawLine( this.gameObject.transform.position,this.gameObject.transform.position+new Vector3(0,-1,0), Color.red);
   //   if (lastVec == null)
   //   {
   //       lastVec = this.gameObject.transform.position;
   //   }
   //   else {
   //       frameTime += 1;
   //
   //       if (frameTime > 10)
   //       {
   //           frameTime = 0;
   //           if (Vector3.Distance(lastVec, this.transform.position) == 0)
   //           {
   //               this.gameObject.GetComponent<Collider>().isTrigger = true;
   //               Destroy(this.gameObject.GetComponent<Rigidbody>());
   //           }
   //           else
   //           {
   //
   //               lastVec = this.gameObject.transform.position;
   //           }
   //       }
   //      
   //       
   //   }
   //
    }



    public void update(ViewInfo info)
    {
        switch (info.code) { 
        
            case 1:
                this.posItem = info.aimObje;

                break;
        }
    }
}
