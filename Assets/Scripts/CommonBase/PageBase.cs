using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PageBase : MonoBehaviour {

 
    public Dictionary<string, PageBase> dic;
    public Vector3 initPosition = new Vector3();


    public void add2Dic(string key,PageBase value)
    {
        if (dic.ContainsKey(key) == true)
        {
            dic[key] = value;
        }else
        {

            dic.Add(key, value);
        }
    }
    public void Awake()
    {
        setParameter();
        this.GetComponent<RectTransform>().localPosition = initPosition;

        add2Dic(this.GetType().Name, this);


    }
    public void Start()
    {
        this.gameObject.SetActive(false);   
    }
    public abstract void setParameter();
   

    public void showPage()
    {
        this.gameObject.SetActive(true);


        foreach (PageBase page in dic.Values)
        {

            if (page != this)
            {
                page.hidePage();

            }
        }

    }

    public void hidePage()
    {
        this.gameObject.SetActive(false);
    }


    public T findElement<T>(string str) 
    {

        T a = this.transform.Find(str).GetComponent<T>();
        return a;


    }
}
