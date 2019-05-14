using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataCatche : MonoBehaviour {

    public static ShapeItemData ShapeItemData;
    public static ShapeData shapeData;
    public static BaseboardData baseBoard;
    public static BoxData boxData;

    /// <summary>
    /// 我从InsBaseBoard回来之后,只有从那个场景跳转会MainScene时才会设定非空
    /// </summary>
    public static int onRebackFromInsBaseBoard = -1;

}
