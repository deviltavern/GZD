using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBoardDisposer : MonoBehaviour {

    public GameObject baseBoard;

    public static BaseBoardDisposer Instance;
    public List<GameObject> insShapeItemList = new List<GameObject>();



    public static Color transparencyColor  = new Color(1,1,1,0.5f);
    public static Color noneTransparencyColor = new Color(1, 1, 1, 1);


    public Dictionary<float, int> layerValue = new Dictionary<float, int>();
    public void clearShape()
    {
        foreach (GameObject g in insShapeItemList)
        {
            Destroy(g);
        }
        insShapeItemList.Clear();
    }
   
    public Transform insParent;

    private void Awake()
    {
        Instance = this;
        layerValue.Add(0.5f,1);
        layerValue.Add(1.5f,2);
        layerValue.Add(2.5f,3);


    }


    public void changeValue(float width,float len)
    {
        baseBoard.transform.localScale = new Vector3(width,1, len);

    }
    public void changeValue(BaseboardData data)
    {
        baseBoard.transform.localScale = new Vector3(data.width, 1, data.len);

    }
    public void changeWL(BoxData data)
    {
        foreach (GameObject G in insShapeItemList) {
            G.GetComponent<MeshRenderer>().material = ResourcesManager.materialDic[data.materialsType];
        }



    }


    public void changeWL(Color color)
    {
        foreach (GameObject G in insShapeItemList)
        {
            G.GetComponent<MeshRenderer>().material.color = color;
        }

    }
    public List<GameObject> insShape(ShapeData data)
    {
        clearShape();

        List<ShapeItemData> sList = reOrder(data);
        foreach (ShapeItemData itemData in sList)
        {
            // GameObject.Instantiate();

            GameObject G = GameObject.Instantiate(ResourcesManager.prefabDic[ResName.shapeItem]);

            G.transform.SetParent(insParent);
            G.transform.localPosition = itemData.getVector3();
            itemData.shapeItem = G;
            insShapeItemList.Add(G);

        }

        return insShapeItemList;

    }

    Dictionary<int, float> layerDic = new Dictionary<int, float>();

    Dictionary<float, int> value2LayerDIc = new Dictionary<float, int>();
    public void addLayerDIc(int key,float value)
    {

        if (layerDic.ContainsValue(value) == true)
        {

            return;
        }
        else
        {
            if (layerDic.ContainsKey(key) == true)
            {
                return;
            }
            else
            {
                layerDic.Add(key, value);
                index++;
            }

        }



    }
    int index = 1;

    
    public void addValue2LayerDIc( float value, int key)
    {

        if (value2LayerDIc.ContainsKey(value) == true)
        {

            return;
        }
        else
        {

            value2LayerDIc.Add( value, key);
           

        }



    }
    public List<ShapeItemData> reOrder(ShapeData data)
    {

        //找到层-实际位置的映射
       

        //找到第一层的Order
      
    //   foreach (ShapeItemData tempData in data.shapeItemDataList)
    //   {
    //       addLayerDIc(index, tempData.y);
    //       
    //
    //   }
    //
    //   List<float> layerValueLIst = new List<float>();
    //
    //   foreach (float value in layerDic.Values)
    //   {
    //       layerValueLIst.Add(value);
    //   }
    //
    //   List<float> tempList = new List<float>();
    //
    //   for (int i = 0; i < layerValueLIst.Count; i++)
    //   {
    //
    //       float min = layerValueLIst[i];
    //       for (int j = 0; j < layerValueLIst.Count - 1; j++)
    //       {
    //
    //           if (min > layerValueLIst[j + 1])
    //           {
    //               
    //               min = layerValueLIst[j + 1];
    //           }
    //
    //           tempList.Add(min);
    //
    //       }
    //   }
    //
    //   foreach (float value in tempList) {
    //
    //       Debug.Log("层值：" + value);
    //   }
    //
    //   foreach (int key in layerDic.Keys)
    //   {
    //       addValue2LayerDIc(layerDic[key], key);
    //       print(key + ":" + layerDic[key]);
    //   }

        List<ShapeItemData> layer1 = new List<ShapeItemData>();

        List<ShapeItemData> layer2 = new List<ShapeItemData>();

        List<ShapeItemData> layer3 = new List<ShapeItemData>();



        foreach (ShapeItemData tempData in data.shapeItemDataList)
        {

            Debug.Log("层值：" + layerValue[tempData.y] + "值：" + tempData.y);
            switch (layerValue[tempData.y])
            {
                case 1:
                    layer1.Add(tempData);
                    break;

                case 2:
                    layer2.Add(tempData);
                    break;

                case 3:

                    layer3.Add(tempData);
                    break;


                default:

                    break;
            }


        }


        List<ShapeItemData> reShapeItemList = new List<ShapeItemData>();

        foreach (ShapeItemData i2 in layer1)
        {
            reShapeItemList.Add(i2);
        }
        foreach (ShapeItemData i2 in layer2)
        {
            reShapeItemList.Add(i2);
        }
        foreach (ShapeItemData i2 in layer3)
        {
            reShapeItemList.Add(i2);
        }

        return reShapeItemList;


    }




}
