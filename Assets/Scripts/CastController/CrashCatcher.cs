using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashCatcher : MonoBehaviour, IViewer
{
    public static CrashCatcher Instance;


    void Awake()
    {
        Instance = this;
    }

    private List<IViewer> viewerList = new List<IViewer>();
    /// <summary>
    /// 生成一个碰撞角色
    /// </summary>
    public void InsCrashItem(GameObject transformParent,Vector3 dir)
    {
        GameObject insBullet = GameObject.Instantiate(ResourcesManager.prefabDic["bullet"], transformParent.transform.position, Quaternion.identity);

        BulletViewer obViewer = insBullet.GetComponent<BulletViewer>();
        obViewer.addViewer(this);
        obViewer.dir = Vector3.Normalize(new Vector3(0, -1, 0));
    
    }


    public void addViewer(IViewer view)
    {
        viewerList.Add(view);
    }

    public void deleteViewer(IViewer view)
    {
        viewerList.Remove(view);
    }




    public void broadCast(ViewInfo info)
    {
        foreach(IViewer view in viewerList)
        {
            view.update(info);
        }
    }




    /// <summary>
    /// 0:表示存在一个碰撞者
    /// </summary>
    /// <param name="info"></param>
    public void update(ViewInfo info)
    {


        switch (info.code)
        {
            case 0:

                break;

            case 1:


                Debug.Log("发生碰撞");
                Debug.Log(info.aimObje.name);

                break;

            default:


                break;
        
        }


    }
}
