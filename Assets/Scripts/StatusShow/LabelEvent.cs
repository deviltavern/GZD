using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class LabelEvent : MonoBehaviour {

    private Text text;
    

    public virtual void Awake()
    {

        text = this.transform.GetComponent<Text>();
    }

    public virtual void setText(string value)
    {
        this.text.text = value;
    
    }



}
