using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StyleSecletPageEX1 : MonoBehaviour {


    public Button weightBtn;
    public Button heightBtn;
    public Button widthBtn;
    public Button lenBtn;
    public Button disBtn;
    public Button numBtn;
    public Button labelBtn;
    public Dropdown labelDropDown;
    private void Awake()
    {
        weightBtn = this.transform.Find("p_weightBtn").GetComponent<Button>();
        heightBtn = this.transform.Find("p_heightBtn").GetComponent<Button>();
        lenBtn = this.transform.Find("p_lenBtn").GetComponent<Button>();
        widthBtn = this.transform.Find("p_widthBtn").GetComponent<Button>();
        disBtn = this.transform.Find("p_disBtn").GetComponent<Button>();
        numBtn = this.transform.Find("p_numBtn").GetComponent<Button>();
        labelBtn = this.transform.Find("p_labelBtn").GetComponent<Button>();
        labelDropDown = this.transform.Find(ResName.p_labelDropdown).GetComponent<Dropdown>();



        weightBtn.onClick.AddListener(onClickWeightBtn);
        heightBtn.onClick.AddListener(onClickHeightBtn);
        disBtn.onClick.AddListener(onClickDisBtn);
        numBtn.onClick.AddListener(onClickNumBtn);
        labelBtn.onClick.AddListener(onClickLabelBtn);
        widthBtn.onClick.AddListener(onClickWidthBtn);
        lenBtn.onClick.AddListener(onClickLenBtn);

    }

    public void onClickWeightBtn()
    {
 
    }


    public void onClickHeightBtn()
    {

        
    }
    public void onClickDisBtn()
    {


    }
    public void onClickNumBtn()
    {

       

    }
    public void onClickLabelBtn()
    {

       

    }

    public void onClickWidthBtn()
    {

       

    }

    public void onClickLenBtn()
    {
       
    }
}
