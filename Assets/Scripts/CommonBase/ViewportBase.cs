using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class ViewportBase : MonoBehaviour {

    public RectTransform viewport;
    public RectTransform content;

    private List<GameObject> tempList = new List<GameObject>();

    /// <summary>
    /// 返回数据列表
    /// </summary>
    /// <returns></returns>
    /// 
    public void Awake()
    {
        viewport = this.GetComponent<RectTransform>();
        content = viewport.Find("Content").GetComponent<RectTransform>();
    }
    public void Start()
    {
        insStrategy();
    }
    public abstract void insStrategy();

    
    public List<GameObject> getList()
    {
        return tempList;
    }


    public abstract void updateViewportInfo();
    /// <summary>
    /// 生成content的子物体
    /// </summary>
    /// <param name="res"></param>
    /// <param name="ins_Vec"></param>
    public void insGameObject(GameObject res, Vector3 ins_Vec)
    {

        GameObject g = GameObject.Instantiate(res,viewport.parent);
        g.GetComponent<RectTransform>().localPosition = ins_Vec;
        g.GetComponent<RectTransform>().SetParent(content);
        tempList.Add(g);
    }
    public void insGameObject(GameObject res, Vector3 ins_Vec,string value)
    {

        GameObject g = GameObject.Instantiate(res, viewport.parent);
        g.GetComponent<RectTransform>().localPosition = ins_Vec;
        g.GetComponent<RectTransform>().SetParent(content);

        g.GetComponentInChildren<Text>().text = value;
        tempList.Add(g);
    }

}
