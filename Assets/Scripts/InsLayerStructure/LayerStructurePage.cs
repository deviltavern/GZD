using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LayerStructurePage : MonoBehaviour {
/// <summary>
/// 定义单程Page
/// 长/宽/高
/// X/Y/Z
/// Rotation X/Y/Z
/// </summary>
    public InputField widthInput;
    public InputField heightInput;
    public InputField lenInput;
    public InputField rotationInput_X;
    public InputField rotationInput_Y;
    public InputField rotationInput_Z;
    public InputField layer_Y;
    public InputField layer_Z;
    public InputField layer_X;
    public InputField TypeInput;
    public Button insBtn;
    public static LayerStructurePage Instance;
    public InputField LayerItem_width;
    public InputField LayerItem_len;
    public InputField LayerItem_height;
    public InputField LayerItem_X;
    public InputField LayerItem_Y;
    public InputField LayerItem_Z;
    public InputField LayerItem_RX;
    public InputField LayerItem_RY;
    public InputField LayerItem_RZ;

    public RectTransform MagnetismPage;
    public Button MagnetismBtn;
    
  //  public InputField InsRotion;
    
    public RectTransform InsLayerItem;
    public RectTransform SaveFunc;
    public Button saveOk;

    public Button saveBtn;
    public GameObject canvas1;
 
    void Awake()
    {
        Instance = this;
        widthInput = this.transform.Find("WidthInput").GetComponent<InputField>();
        lenInput = this.transform.Find("LenghInput").GetComponent<InputField>();
        heightInput = this.transform.Find("heightInput").GetComponent<InputField>();
        rotationInput_X = this.transform.Find("rotationInput_X").GetComponent<InputField>();
        rotationInput_Y = this.transform.Find("rotationInput_Y").GetComponent<InputField>();
        rotationInput_Z = this.transform.Find("rotationInput_Z").GetComponent<InputField>();
        layer_Y = this.transform.Find("layer_Y").GetComponent<InputField>();
        layer_Z = this.transform.Find("layer_Z").GetComponent<InputField>();
        layer_X = this.transform.Find("layer_X").GetComponent<InputField>(); 

        insBtn = this.transform.Find("InsBtn").GetComponent<Button>();

        //磁力
        MagnetismPage = this.transform.Find("MagnetismPage").GetComponent<RectTransform>();
        MagnetismBtn = MagnetismPage.transform.Find("MagnetismBtn").GetComponent<Button>();




        InsLayerItem = this.transform.Find("InsLayerStructureItem").GetComponent<RectTransform>();
      
        
        
        LayerItem_width = InsLayerItem.transform.Find("LayerItem_width").GetComponent<InputField>();
        LayerItem_len = InsLayerItem.transform.Find("LayerItem_len").GetComponent<InputField>();
        LayerItem_height = InsLayerItem.transform.Find("LayerItem_height").GetComponent<InputField>();
        LayerItem_X = InsLayerItem.transform.Find("LayerItem_X").GetComponent<InputField>();

         
        LayerItem_Y = InsLayerItem.transform.Find("LayerItem_Y").GetComponent<InputField>();
        LayerItem_Z = InsLayerItem.transform.Find("LayerItem_Z").GetComponent<InputField>();
        LayerItem_RX = InsLayerItem.transform.Find("LayerItem_RX").GetComponent<InputField>();
        LayerItem_RY = InsLayerItem.transform.Find("LayerItem_RY").GetComponent<InputField>();
        LayerItem_RZ = InsLayerItem.transform.Find("LayerItem_RZ").GetComponent<InputField>();



        canvas1 = GameObject.Find("Canvas");
        SaveFunc = canvas1.transform.Find("SaveFunc").GetComponent<RectTransform>();
        saveBtn = SaveFunc.transform.Find("saveBtn").GetComponent<Button>();
        TypeInput = SaveFunc.transform.Find("TypeInput").GetComponent<InputField>();
        saveOk = SaveFunc.transform.Find("saveOk").GetComponent<Button>();
    }
	
}
