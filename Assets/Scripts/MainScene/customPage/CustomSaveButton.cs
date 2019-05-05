using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomSaveButton : ButtonEventBase{

    public InputField coustom_lenInput;
    public InputField coustom_widthInput;
    public InputField coustom_y;
    public InputField coustom_x;
    public InputField coustom_z;
    public InputField coustom_typeNum;
    public override void onClickButton()
    {
    

     
      
        PorjectData data = new PorjectData();

   


        //page的参数

        coustom_lenInput = MainSceneCustomPage.Instance.transform.Find("baseboard_width").GetComponent<InputField>();
        coustom_widthInput = MainSceneCustomPage.Instance.transform.Find("baseboard_len").GetComponent<InputField>();
        coustom_y = MainSceneCustomPage.Instance.transform.Find("box_y").GetComponent<InputField>();
        coustom_x = MainSceneCustomPage.Instance.transform.Find("box_x").GetComponent<InputField>();
        coustom_z = MainSceneCustomPage.Instance.transform.Find("box_z").GetComponent<InputField>();
        coustom_typeNum = MainSceneCustomPage.Instance.transform.Find("box_typeNum").GetComponent<InputField>();









    }


  
}
