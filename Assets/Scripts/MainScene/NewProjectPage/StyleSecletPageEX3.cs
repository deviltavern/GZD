using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StyleSecletPageEX3 : MonoBehaviour {

    public Button formBtn;

    private void Awake()
    {
        formBtn = this.transform.GetComponent<Button>();


        formBtn.onClick.AddListener(onClickFormBtn);
     

    }

    public void onClickFormBtn()
    {

    }
}
