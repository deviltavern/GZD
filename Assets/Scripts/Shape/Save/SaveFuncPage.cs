using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
 
public class SaveFuncPage : MonoBehaviour {
    public Button saveBtn;
    public InputField input;
    public Button saveOk;
    
    private void Awake()
    {
        saveBtn = this.transform.Find("saveBtn").GetComponent<Button>();
        input = this.transform.Find("input").GetComponent<InputField>();
        saveOk = this.transform.Find("saveOk").GetComponent<Button>();

        input.gameObject.SetActive(false);
        saveOk.gameObject.SetActive(false);

        saveBtn.onClick.AddListener(onClickSaveBtn);
        saveOk.onClick.AddListener(onsaveOkBtn);
    }

    public void onClickSaveBtn()
    {
        input.gameObject.SetActive(true);
        saveOk.gameObject.SetActive(true);
    }
    string value = "";
    public void onsaveOkBtn()
    {
        if (input.text == "")
            return;

        Debug.Log(ShapeAreaAction.insShapeItemDic.Count);
        foreach (string key in ShapeItemCatcher.getData())
        {

            GameObject g = ShapeAreaAction.insShapeItemDic[key];
            ShapeItemData vec = ShapeItemData.conveter(g.transform.localPosition);
            vec.ID = key;

            value += JsonUtility.ToJson(vec)+"&";

        }
        ShapeItemData center = new ShapeItemData();
        //center.ID = ShapeAreaAction.Instance.width+"-"+ ShapeAreaAction.Instance.len+"-"+ ShapeAreaAction.Instance.height+"&";
        Debug.Log(value);
        StreamWriter sw = new StreamWriter(Pather.shapePath + input.text+".txt");
        sw.Write(value);
        sw.Flush();
        sw.Close();

        SceneManager.LoadScene("MainScene");
        
    }
}
