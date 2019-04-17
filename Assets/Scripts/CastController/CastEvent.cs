using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastEvent : MonoBehaviour {

    public void addCrashItem()
    {
        GameObject insBullet = GameObject.Instantiate(ResourcesManager.prefabDic["bullet"], this.transform.position, Quaternion.identity);

        BulletViewer obViewer = insBullet.GetComponent<BulletViewer>();



       // obViewer.addViewer(this);
       // obViewer.dir = Vector3.Normalize(new Vector3(0, -1, 0));
       //
    
    }
}
