using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LayerStructureAction : MonoBehaviour {
    List<BoxData> SingleLayerBoxDataList = new List<BoxData>();
    List<string> SingleLayerValueList = new List<string>();
    public BoxData SingleLayerBoxData;
    public int width;
    public int len;
    public RectTransform rect_block;
    public RectTransform rect_y;
    public RectTransform rect_x;
    LayerStructurePage page;
    MainSceneCustomPage _MainSceneCustomPage;
    public static LayerStructureAction Instance;
    public float x_float;
    public float y_float;

    public Transform rect_Cube;
    public float Cube_y;
    public float Cube_x;
    public float Cube_z;
    public bool ButtonOk=false;
    private void Awake()
    {
        Instance = this;

    }
    void Start()
    {
        page = LayerStructurePage.Instance;
        page.insBtn.onClick.AddListener(OnClickInsBtn);

        page.TypeInput.gameObject.SetActive(false);
        page.saveOk.gameObject.SetActive(false);

        page.saveBtn.onClick.AddListener(onClickSaveBtn);
        page.saveOk.onClick.AddListener(onsaveOkBtn);

        page.MagnetismBtn.onClick.AddListener(onClickMagnetismBtn);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnClickInsBtn()
    {
        Cube_x = float.Parse(page.widthInput.text);
        Cube_y = float.Parse(page.lenInput.text);
        Cube_z = float.Parse(page.heightInput.text);
        
        page.LayerItem_width.text = "单层的宽：" + page.widthInput.text;
        page.LayerItem_len.text = "单层的长：" + page.lenInput.text;
        page.LayerItem_height.text = "单层的高：" + page.heightInput.text;

        page.LayerItem_X.text = "单层的X：" + page.layer_X.text;
        page.LayerItem_Y.text = "单层的Y：" + page.layer_Y.text;
        page.LayerItem_Z.text = "单层的Z：" + page.layer_Z.text;

        page.LayerItem_RX.text = "旋转的X：" + page.rotationInput_X.text;
        page.LayerItem_RY.text = "旋转的Y：" + page.rotationInput_Y.text;
        page.LayerItem_RZ.text = "旋转的Z：" + page.rotationInput_Z.text;

        Debug.Log("单层的x:" + Cube_x + "单层的y:" + Cube_y + "单层的z:" + Cube_z);
        rect_Cube = LayerStructureItem.Instance.InsLayerCube.GetComponent<Transform>();
        rect_Cube.localScale = new Vector3(Cube_x, Cube_y, Cube_z);
        rect_Cube.tag = "Box";


    }
    public void onClickSaveBtn()
    {
        page.TypeInput.gameObject.SetActive(true);
        page.saveOk.gameObject.SetActive(true);
    }

    public void onClickMagnetismBtn() {

        page.MagnetismBtn.GetComponent<Image>().color = Color.blue;
        ButtonOk = true;
        
    }


    string value = "";

    /// <summary>
    /// CatcheData
    /// </summary>
    public void onsaveOkBtn()
    {


        if (page.TypeInput.text == "")
            return;

        string value = "";

        foreach (GameObject g in LayerStructrueDataCache.Instance.boxItemList) {
            
              SingleLayerBoxData=  new BoxData(g,g.name);
             
              SingleLayerBoxDataList.Add(SingleLayerBoxData);
              foreach (BoxData data in SingleLayerBoxDataList) {

                  value = data.ToString() + "&";
                  SingleLayerValueList.Add(value);
              }


        }
    
        string values="";
        foreach (string a in SingleLayerValueList) {

            values += a;
        
        }
       
    
       
       StreamWriter sw = new StreamWriter(LayerStructrueDataCache.FilePath + page.TypeInput.text + ".txt");
       sw.Write(values);
       sw.Flush();
       sw.Close();


      


       // ConfigFile.updateBaseboardDataInXML(int.Parse(baseboard_len), int.Parse(baseboard_width), int.Parse(baseboard_type));
        //DataCatche.onRebackFromInsBaseBoard = int.Parse(baseboard_type);
        SceneManager.LoadScene("MainScene");



    }
}
