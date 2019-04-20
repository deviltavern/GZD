using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PAGE1 : MonoBehaviour {


    public static Dictionary<string, PAGE1> DIC = new Dictionary<string, PAGE1>();

    private void Awake()
    {
        DIC.Add(this.GetType().Name, this);
    }


    public void show()
    {

        this.gameObject.SetActive(true);

        foreach (PAGE1 page in DIC.Values)
        {
            if (page != this)
            {
                page.hide();

            }
            else
            {
               
            }

        }

    }

    public void hide()
    {
        this.gameObject.SetActive(false);
    }


}
