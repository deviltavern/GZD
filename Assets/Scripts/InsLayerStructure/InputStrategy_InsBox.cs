using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputStrategy_InsBox : Strategy {



    int index = 0;
    public override void doSomthing()
    {
      
        if (Input.GetKey(KeyCode.LeftControl))
        {

            if (Input.GetKeyDown(KeyCode.D)) {

                GameObject box =  GameObject.Instantiate(LayerStructrueDataCache.Instance.pointBox, LayerStructrueDataCache.Instance.pointBox.transform.parent);
                LayerStructrueDataCache.Instance.pointBox.transform.localPosition += new Vector3(LayerStructrueDataCache.Instance.pointBox.transform.localScale.x,0,0);
                box.name = index + "";
                Debug.Log("执行生成策略");

                box.transform.GetComponent<Collider>().enabled = true;

                LayerStructrueDataCache.Instance.boxItemList.Add(box);

                LayerStructrueDataCache.Instance.onSelect(box);
            }
        }


    }

    public override void onEnd()
    {
      
    }

    public override void waitting()
    {
      
    }

    // Use this for initialization

}
