﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomController : MonoBehaviour
{
    /// <summary>
    /// MVC模式的 controller
    /// </summary>
    /// 

    MainSceneCustomPage page;
    string pressCity;
    string pressBaseboard;
    private void Start()
    {

        page = (MainSceneCustomPage)MainScenePage.stackDic["MainSceneCustomPage"];


        page.createBtn.onClick.AddListener(onClickCreateBtn);
        page.saveBtn.interactable = false;

        page.saveBtn.onClick.AddListener(onClickSaveBtn);


        page.box_Dropdown.onValueChanged.AddListener(delegate { onChangeBoxDropdown(); });
        page.baseboard_Dropdown.onValueChanged.AddListener(delegate { onChangeBaseboardDropdown(); });
    }

    public void onClickCreateBtn()
    {
        page.saveBtn.interactable = true;
        page.createBtn.interactable = false;
    }
    public void onClickSaveBtn()
    {
        string box_x = page.box_x.text + "";
        string box_y = page.box_y.text + "";
        string box_z = page.box_z.text + "";
        string box_typeNum = page.box_typeNum.text + "";
        string baseboard_len = page.baseboard_len.text + "";
        string baseboard_width = page.baseboard_width.text + "";
        string baseboard_typeNum = page.baseboard_typeNum.text + "";

        //updateBoxDataInXML，在XML里面更新
        ConfigFile.updateBoxDataInXML(int.Parse(box_x), int.Parse(box_y), int.Parse(box_z), int.Parse(box_typeNum));
        ConfigFile.updateBaseboardDataInXML(int.Parse(baseboard_len), int.Parse(baseboard_width), int.Parse(baseboard_typeNum));

        page.saveBtn.interactable = false;
        page.createBtn.interactable = true;
    }
    public void onChangeBaseboardDropdown()
    {
        pressBaseboard = page.baseboard_Dropdown.options[page.baseboard_Dropdown.value].text;
        //pressBaseboard:选中的底板

        if (page.baseboard_Dropdown.value != 0)
        {

            foreach (BaseboardData element in BaseboardData.Baseboard_dic.Values)
            {
                if (element.id == pressBaseboard)
                {
                    page.baseboard_len.text = BaseboardData.Baseboard_dic[pressBaseboard].len + "";
                    page.baseboard_width.text = BaseboardData.Baseboard_dic[pressBaseboard].width + "";
                    page.baseboard_typeNum.text = BaseboardData.Baseboard_dic[pressBaseboard].id + "";

                }
            }
        }
        else
        {
            page.baseboard_len.text = "";
            page.baseboard_width.text = "";
            page.baseboard_typeNum.text = "";

        }

        Debug.Log("3333333333");

    }
    public void onChangeBoxDropdown()
    {
        pressCity = page.box_Dropdown.options[page.box_Dropdown.value].text;
        //pressCity:选中的data_id

        if (page.box_Dropdown.value != 0)
        {

            foreach (BoxData element in BoxData.dic.Values)
            {
                if (element.id == pressCity)
                {
                    page.box_x.text = BoxData.dic[pressCity].width + "";
                    page.box_y.text = BoxData.dic[pressCity].height + "";
                    page.box_z.text = BoxData.dic[pressCity].len + "";
                    page.box_typeNum.text = BoxData.dic[pressCity].id;
                }
            }
        }
        else
        {
            page.box_x.text = "";
            page.box_y.text = "";
            page.box_z.text = "";
            page.box_typeNum.text = "";
        }

        Debug.Log("2222222222222222222222222222222222222222");

    }
}
    
    



