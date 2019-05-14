using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseboardPage : MonoBehaviour {
    public InputField widthInput;
    public InputField lenInput;
    public InputField TypeInput;
    public Button insBtn;
    public static BaseboardPage Instance;
    public InputField InsWidth;
    public InputField InsLen;
    public Image InsBItem;
    public RectTransform SaveFunc;
    public Button saveOk;
    
    public Button saveBtn;
    public GameObject canvas1;
	void Awake() {
        Instance = this;
        widthInput = this.transform.Find("WidthInput").GetComponent<InputField>();
        lenInput = this.transform.Find("LenghInput").GetComponent<InputField>();
       
        insBtn = this.transform.Find("InsBtn").GetComponent<Button>();
        
        InsBItem = this.transform.Find("InsBaseboardItem").GetComponent<Image>();
        InsWidth = InsBItem.transform.Find("baseboard_X").GetComponent<InputField>();
        InsLen = InsBItem.transform.Find("baseboard_Y").GetComponent<InputField>();

        canvas1 = GameObject.Find("Canvas");
        SaveFunc = canvas1.transform.Find("SaveFunc").GetComponent<RectTransform>();
        saveBtn = SaveFunc.transform.Find("saveBtn").GetComponent<Button>();
        TypeInput = SaveFunc.transform.Find("TypeInput").GetComponent<InputField>();
        saveOk = SaveFunc.transform.Find("saveOk").GetComponent<Button>();
	}
	

}
