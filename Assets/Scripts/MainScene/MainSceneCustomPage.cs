using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainSceneCustomPage : MainScenePage
{

   public InputField box_x;
   public InputField box_y;
   public InputField box_z;
   public InputField box_typeNum; 
   public InputField baseboard_width;
   public InputField baseboard_len;
   public InputField baseboard_typeNum;
   public Dropdown box_Dropdown;
   public Dropdown baseboard_Dropdown;
   public Button saveBtn;
   public Button createBtn;
   public static MainSceneCustomPage Instance;


    public Button customShape;
    public Button customBaseBoard;
    public Button customSingleLayer;
    public Button customBoxType;

    public Button simulinkBtn;

    public Dropdown stacking_type;

    public List<string> stacking_type_value;

/// <summary>
/// MVC模式下的   View
/// </summary>
    public override void setParameter()
    {
        baseboard_Dropdown = findElement<Dropdown>("baseboard_Dropdown");
        box_Dropdown = findElement<Dropdown>("box_Dropdown");
        box_x = findElement<InputField>("box_x");
        box_y = findElement<InputField>("box_y");
        box_z = findElement<InputField>("box_z");
        box_typeNum = findElement<InputField>("box_typeNum");
        baseboard_width = findElement<InputField>("baseboard_width");
        baseboard_len = findElement<InputField>("baseboard_len");
        baseboard_typeNum = findElement<InputField>("baseboard_typeNum");
        saveBtn = findElement<Button>("saveBtn");
        createBtn = findElement<Button>("createBtn");
        stacking_type = this.transform.Find("stacking_type").GetComponent<Dropdown>();

        customShape= findElement<Button>("customShape");
        customBaseBoard = findElement<Button>("customBaseBoard");
        customSingleLayer = findElement<Button>("customSingleLayer");
        customBoxType = findElement<Button>("customBoxType");

        stacking_type.ClearOptions();


        simulinkBtn = findElement<Button>("simulink");
        CreateFolder.getFolderNameList("D:\\GZRobot\\Shape",out stacking_type_value);


        this.stacking_type.AddOptions(stacking_type_value);
        Instance = this;
        
        base.setParameter();
    }






}
