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
        Instance = this;
        
        base.setParameter();
    }





}
