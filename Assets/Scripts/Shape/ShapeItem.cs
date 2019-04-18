using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeItem : MonoBehaviour {



    
    MeshRenderer mesh;
    public Color defaultColor;
    public Color dynamicColor;
    public static Color changeColor = new Color(238 / 255f, 59 / 255f, 59 / 255f);
    public string id { get; set; }
    void Awake()
    {

        mesh = this.GetComponent<MeshRenderer>();
        
    }

    void Start()
    {
        defaultColor = mesh.material.color;
        dynamicColor = defaultColor;

    }
    public int index = 0;
    void OnMouseDown()
    {
        Debug.Log("鼠标点击！");
        if (index % 2 == 0)
        {
            dynamicColor = changeColor;
            ShapeItemCatcher.addShapeItem(this.id);
            


        }
        else
        {
            dynamicColor = defaultColor;
            ShapeItemCatcher.deleteShapeItem(this.id);


        }

        index++;
        
    }
    void OnMouseEnter()
    {
        Debug.Log("鼠标进入！");
        mesh.material.color = changeColor;
        


    }

    void OnMouseExit()
    {
        Debug.Log("鼠标离开！");
        mesh.material.color = dynamicColor;
    }
}
