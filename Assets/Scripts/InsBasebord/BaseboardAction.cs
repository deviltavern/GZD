using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BaseboardAction : MonoBehaviour {

    public int width;
    public int len;
    public RectTransform rect_block;
    public RectTransform rect_y;
    public RectTransform rect_x;
    BaseboardPage page;
    MainSceneCustomPage _MainSceneCustomPage;
    public static BaseboardAction Instance;
    public float x_float;
    public float y_float;
    private void Awake()
    {
        Instance = this;

    }
    void Start()
    {
        page = BaseboardPage.Instance;
        page.insBtn.onClick.AddListener(OnClickInsBtn);

        page.TypeInput.gameObject.SetActive(false);
        page.saveOk.gameObject.SetActive(false);

        page.saveBtn.onClick.AddListener(onClickSaveBtn);
        page.saveOk.onClick.AddListener(onsaveOkBtn);
    }
	// Update is called once per frame
	void Update () {
		
	}
   
    public void insBaseboardItem(int w, int l)
    {
        
        string id = w + "-" + l + "-" ;
       rect_block= page.InsBItem.GetComponent<RectTransform>();
      // rect_block.localPosition = new Vector3(100, 200);

        //设置宽高
        rect_block.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, w);
        rect_block.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, l);
       

    }
    public void OnClickInsBtn()
    {
        page.InsWidth.text ="底板的宽："+ page.widthInput.text;
        page.InsLen.text = "底板的长："+page.lenInput.text;
        width = int.Parse(page.widthInput.text);
        len = int.Parse(page.lenInput.text);
        insBaseboardItem(width, len);
        //加偏移
        x_float = -15-width/2;
        rect_y = page.InsLen.GetComponent<RectTransform>();
        rect_y.localPosition = new Vector3(x_float ,-2);
        //设置宽高
        rect_y.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, len);
 
        y_float = -30 - len;
        rect_x = page.InsWidth.GetComponent<RectTransform>();
        rect_x.localPosition = new Vector3(0, y_float / 2);
        //设置宽高
        rect_x.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width);
   
    }
    public void onClickSaveBtn()
    {
        page.TypeInput.gameObject.SetActive(true);
        page.saveOk.gameObject.SetActive(true);
    }
    string value = "";

    /// <summary>
    /// CatcheData
    /// </summary>
    public void onsaveOkBtn()
    {
        string baseboard_len = page.lenInput.text + "";
        string baseboard_width = page.widthInput.text + "";
        string baseboard_type = page.TypeInput.text + "";

        if (page.TypeInput.text == "")
            return;

        ConfigFile.updateBaseboardDataInXML(int.Parse(baseboard_len), int.Parse(baseboard_width), int.Parse(baseboard_type));
        DataCatche.onRebackFromInsBaseBoard = int.Parse(baseboard_type);
        SceneManager.LoadScene("MainScene");


       
    }
}
