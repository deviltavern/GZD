using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShapeAreaPage : MonoBehaviour {


    public InputField widthInput;
    public InputField lenInput;
    public InputField heightInput;

    public Button insBtn;
    public static ShapeAreaPage Instance;

    public List<ShapeLayer> layerList = new List<ShapeLayer>();
    

    void Awake()
    {
        Instance = this;
        widthInput = this.transform.Find("WidthInput").GetComponent<InputField>();
        lenInput = this.transform.Find("LenghInput").GetComponent<InputField>();
        heightInput = this.transform.Find("HeightInput").GetComponent<InputField>();
        insBtn = this.transform.Find("InsBtn").GetComponent<Button>();
    }


}
