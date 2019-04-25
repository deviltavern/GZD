using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class DropdowControl : Selectable {
    public string[] showText;
    Dropdown dropDownItem;
  public static List<string> temoNames;
  

   
    void Start()
    {
        dropDownItem = this.GetComponent<Dropdown>();
        temoNames = new List<string>();
        temoNames.Add("前");
        temoNames.Add("后");
        temoNames.Add("侧边");


   
        UpdateDropDownItem(temoNames);

    }


    void UpdateDropDownItem(List<string> showNames)
    {
        dropDownItem.options.Clear();
        Dropdown.OptionData temoData;
        for (int i = 0; i < showNames.Count; i++)
        {
            //给每一个option选项赋值
            temoData = new Dropdown.OptionData();
            temoData.text = showNames[i];
            dropDownItem.options.Add(temoData);
        }
        //初始选项的显示
        dropDownItem.captionText.text = showNames[0];
        
    }

    //void AddNames()
    //{
    //    for (int i = 0; i < showText.Length; i++)
    //    {
    //        temoNames.Add(showText[i]);
    //    }

    //}



}
