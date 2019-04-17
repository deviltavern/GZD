using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class ButtonEventBase : MonoBehaviour {

    Button button;

    public virtual void Awake()
    {
        button = this.GetComponent<Button>();

        button.onClick.AddListener(onClickButton);
    
    }

    public abstract void onClickButton();
}
