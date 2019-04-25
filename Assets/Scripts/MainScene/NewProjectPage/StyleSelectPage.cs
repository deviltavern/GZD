using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StyleSelectPage : MonoBehaviour
 {
     public Button style;
     public Button widthBtn;
     public Button lenBtn;


     private void Awake()
     {
         style = this.transform.Find("bp_style").GetComponent<Button>();

         widthBtn = this.transform.Find("bp_widthBtn").GetComponent<Button>();

         lenBtn = this.transform.Find("bp_lenBtn").GetComponent<Button>();

     style.onClick.AddListener(onClickStyle);
         widthBtn.onClick.AddListener(onClickWidthBtn);
         lenBtn.onClick.AddListener(onClickLenBtn);

     }

  public void onClickStyle()
   {
     MainSceneBaseBoardViewBase.stackDIc[MainSceneResName.MainSceneBaseBoardView_style].showPage();
    }

     public void onClickWidthBtn()
     {

         MainSceneBaseBoardViewBase.stackDIc[MainSceneResName.MainSceneBaseBoardView_wAndh].showPage();

     }

     public void onClickLenBtn()
     {
         MainSceneBaseBoardViewBase.stackDIc[MainSceneResName.MainSceneBaseBoardView_wAndh].showPage();
     }

}
