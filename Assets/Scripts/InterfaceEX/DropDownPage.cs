using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropDownPage : MonoBehaviour {

    public Button dbutton;
    public RectTransform Viewport;
    public RectTransform _Content;
   public  float frameTime;
   bool downStart = false;
    Vector3 initPos;
    void Awake()
    {
      dbutton= this.transform.Find("dButton").GetComponent<Button>();
      Viewport = this.transform.Find("Viewport").GetComponent<RectTransform>();
      _Content = Viewport.Find("Content").GetComponent<RectTransform>();

      initPos = new Vector3(0, 158);
      _Content.localPosition = initPos;//相对位置localPosition
      Debug.Log(Viewport);


    //  _Content = Viewport.GetComponent<RectTransform>();
        dbutton.onClick.AddListener(ddwon);
        //
    }
    /// <summary>
    /// 
    /// </summary>
    public void ddwon()
    {
        Debug.Log("ddwon");
        downStart = true;       

    }



    void Update() {

      //  frameTime += Time.deltaTime;
        if (downStart==true)
        {
            if (_Content.localPosition.y >-8)
            {
                _Content.localPosition -= new Vector3(0, 5, 0);
            }
            else {
                downStart = false;
            }
        }
    
    }

}
