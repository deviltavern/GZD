using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AxleStepInfoSaverViewer : MonoBehaviour {



    public InputField input;
    public Button saveBtn;

    public void Awake()
    { 
        input = this.transform.Find("input").GetComponent<InputField>();
        saveBtn = this.transform.Find("saveBtn").GetComponent<Button>();
        saveBtn.onClick.AddListener(onClickButton);
        input.gameObject.SetActive(false);
        
    }
    public void onClickButton()
    {
        input.gameObject.SetActive(true);
        

        if (input.text == "")
        {
            Debug.Log("文件名不能为空！");
            return;
        }
            


        AxleStepInfoSaver.save2PC(input.text+".txt", AxleStepInfoSaver.getProcedureValue(AxleStepInfoRecord.getData()));

        input.gameObject.SetActive(false);
        input.text = "";
    }
}
