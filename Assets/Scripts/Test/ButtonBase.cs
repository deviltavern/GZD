using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBase : MonoBehaviour {

    public Image _image;
    public GameObject res_block;
    public GameObject init_block;
    public RectTransform rect_block;
    void Awake() {

        _image = this.transform.GetComponent<Image>();
     //   _image.rectTransform.localPosition = new Vector3(0, 200, 1);
        CreateSb(1, 1);
        Debug.Log("1231231");
    }


    public void CreateDb(float db_lenth, float db_width)
    {



    }






    public void CreateSb(float sb_lenth, float sb_width)
    {

        res_block = Resources.Load<GameObject>(ResName.block);
        init_block = GameObject.Instantiate(res_block, CanvasManager.canvas);
        rect_block = init_block.GetComponent<RectTransform>();
        rect_block.localPosition = new Vector3(100, 200);
//设置宽高
        rect_block.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 300);
        rect_block.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 100);


    }


}
