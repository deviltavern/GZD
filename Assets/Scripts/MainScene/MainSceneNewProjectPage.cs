using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainSceneNewProjectPage : MainScenePage
{
    public StyleSecletPageEX1 produceBoard;

    public StyleSelectPage blackBoard;
    public StyleSecletPageEX2 socektBoard;
    public StyleSecletPageEX3 formButton;
    public static MainSceneNewProjectPage Instance;
    public override void setParameter()//继承，重写，多态
    {
        base.setParameter();

        produceBoard = this.transform.Find("produceBoard").GetComponent<StyleSecletPageEX1>();
        blackBoard = this.transform.Find("blackBoard").GetComponent<StyleSelectPage>();
        socektBoard = this.transform.Find("socektBoard").GetComponent<StyleSecletPageEX2>();
        formButton = this.transform.Find("formButton").GetComponent<StyleSecletPageEX3>();
        Instance = this;



        
    }

}