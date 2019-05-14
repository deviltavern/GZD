using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ProjectSaveBtn : ButtonEventBase {
  
  
    public InputField bp_lenInput;
    public InputField bp_widthInput;
    public InputField bp_heightInput;
    public InputField bp_weightInput;
  


    public InputField p_lengthInput;
    public InputField p_widthInput;
    public InputField p_heightInput;
    public InputField p_weightInput;
    public InputField p_distanceInput;
    public InputField p_numInput;
    public Dropdown p_labelInput;

    //通讯配置
    public InputField s_ipInput;
    public InputField s_portInput;
    public InputField s_kindInput; 
  
    public override void onClickButton(){
        DateTime date = DateTime.Now;

        string saveName = date.Month + "" + date.Day + "" + date.Hour + "" + date.Minute + "" + ".txt";
        StreamWriter sw = new StreamWriter(ConfigFile.dataDic["savePath"].getList()[0] + saveName);
        PorjectData data = new PorjectData();
   
   


 //卡板page的参数
       
        bp_lenInput = MainSceneNewProjectPage.Instance.blackBoard.transform.Find(ResName.bp_lenInput).GetComponent<InputField>();
        bp_widthInput = MainSceneNewProjectPage.Instance.blackBoard.transform.Find(ResName.bp_widthInput).GetComponent<InputField>();
        bp_heightInput = MainSceneNewProjectPage.Instance.blackBoard.transform.Find(ResName.bp_heightInput).GetComponent<InputField>();
        bp_weightInput = MainSceneNewProjectPage.Instance.blackBoard.transform.Find(ResName.bp_weightInput).GetComponent<InputField>();
       if (bp_lenInput.text == "" || bp_widthInput.text == "" || bp_heightInput.text == "" || bp_weightInput.text == "") {


           print("卡板page有空没填");

           return;
       }
            
               data.baseplate_height = float.Parse(bp_heightInput.text);
               data.baseplate_width = float.Parse(bp_widthInput.text);
               data.baseplate_length = float.Parse(bp_lenInput.text);
               data.baseplate_weight = float.Parse(bp_weightInput.text);
//描述了产品page的参数
       p_lengthInput = MainSceneNewProjectPage.Instance.produceBoard.transform.Find(ResName.p_lenInput).GetComponent<InputField>();
       p_widthInput = MainSceneNewProjectPage.Instance.produceBoard.transform.Find(ResName.p_widthInput).GetComponent<InputField>();
       p_heightInput = MainSceneNewProjectPage.Instance.produceBoard.transform.Find(ResName.p_heightInput).GetComponent<InputField>();
       p_weightInput = MainSceneNewProjectPage.Instance.produceBoard.transform.Find(ResName.p_weightInput).GetComponent<InputField>();
       p_distanceInput = MainSceneNewProjectPage.Instance.produceBoard.transform.Find(ResName.p_disInput).GetComponent<InputField>();
       p_numInput = MainSceneNewProjectPage.Instance.produceBoard.transform.Find(ResName.p_numInput).GetComponent<InputField>();
       p_labelInput = MainSceneNewProjectPage.Instance.produceBoard.transform.Find(ResName.p_labelDropdown).GetComponent<Dropdown>();

       if (p_lengthInput.text == "" || p_widthInput.text == "" || p_heightInput.text == "" || p_distanceInput.text == "" || p_numInput.text == "" || p_labelInput.value ==null)
       {


           print("产品page有空没填");

           return;
       }
       data.product_length = float.Parse(p_lengthInput.text);
       data.product_width = float.Parse(p_widthInput.text);
       data.product_height = float.Parse(p_heightInput.text);
       data.product_weight = float.Parse(p_weightInput.text);
       data.product_distance = float.Parse(p_distanceInput.text);
       data.product_num = float.Parse(p_numInput.text);
       data.product_label = DropdowControl.temoNames[p_labelInput.value];
//描述了通讯page的参数

       s_ipInput = MainSceneNewProjectPage.Instance.socektBoard.transform.Find(ResName.s_ipInput).GetComponent<InputField>();
       s_portInput = MainSceneNewProjectPage.Instance.socektBoard.transform.Find(ResName.s_portInput).GetComponent<InputField>();
       s_kindInput = MainSceneNewProjectPage.Instance.socektBoard.transform.Find(ResName.s_kindInput).GetComponent<InputField>();

       if (s_ipInput.text == "" || s_portInput.text == "" || s_kindInput.text == "")
       {


           print("通讯page有空没填");

           return;
       }

       data.socket_ip = float.Parse(s_ipInput.text);
       data.socket_port = float.Parse(s_portInput.text);
       data.socket_kind = float.Parse(s_kindInput.text);
  







        sw.Write(JsonUtility.ToJson(data));
     
        sw.Flush();
        sw.Close();
    }
}
