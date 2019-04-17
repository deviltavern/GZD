using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class StepInfoEvent : UIBase {
    private Button button;

    void Awake()
    {
        button = this.GetComponent<Button>();
        button.onClick.AddListener(onClickBtn);
    }

    public abstract void onClickBtn();
}
