using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainSceneCustomPage : MainScenePage
{

   public InputField box_x;
   public InputField box_y;
   public InputField box_z;
   public InputField baseboard_width;
   public InputField baseboard_len;





    public override void setParameter()
    {

        box_x = findElement<InputField>("box_x");
        box_y = findElement<InputField>("box_y");
        box_z = findElement<InputField>("box_z");
        baseboard_width = findElement<InputField>("baseboard_width");
        baseboard_len = findElement<InputField>("baseboard_len");
      
    
        base.setParameter();
    }





}
