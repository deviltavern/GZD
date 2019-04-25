using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PageBase : MonoBehaviour {

 
    public Dictionary<string, PageBase> dic;
    public Vector3 initPosition = new Vector3();

  
    public void Awake()
    {
        setParameter();
        this.GetComponent<RectTransform>().localPosition = initPosition;
       
        dic.Add(this.GetType().Name, this);


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



}
