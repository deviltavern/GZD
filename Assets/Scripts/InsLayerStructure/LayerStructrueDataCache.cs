using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LayerStructrueDataCache : MonoBehaviour {

    List<BoxData> boxData = new List<BoxData>();

    public List<GameObject> boxItemList = new List<GameObject>();

    public static LayerStructrueDataCache Instance;

    public Transform layerParent;
    public GameObject baseBoard;

    public GameObject pointBox;
    public void onDestroyPointBox()
    {
        
        boxItemList.Remove(pointBox);
        Destroy(pointBox);
    }

    public void insCubeFromLayerData(LayerData data)
    {
        foreach (BoxData boxData in data.boxDataList)
        {
            boxItemList.Add(boxData.insCube(layerParent));
            
        }

    }
    public void onSelect(GameObject _pointBox)
    {

        
        
        if (boxItemList.Contains(_pointBox) == false)
        {
            boxItemList.Add(_pointBox);
        }
        
        foreach (GameObject g in boxItemList)
        {
            g.GetComponent<MeshRenderer>().material = ResourcesManager.materialDic["NoneOutline"];
        }
        _pointBox.GetComponent<MeshRenderer>().material = ResourcesManager.materialDic["Outline"];
        this.pointBox = _pointBox;
    }


    private void Awake()
    {


        Instance = this;


    }

    public void DestroyAllLayerItem() {


        foreach (GameObject g in boxItemList)
        {
            Destroy(g);
        }

        boxItemList.Clear();
        Destroy(pointBox);

    }

    public string insJsonData(string layerName)
    {

        string value = "";

     
        foreach (GameObject g in boxItemList)
        {
            BoxData boxData = new BoxData(g,g.name);
            value += boxData.ToString() + "&";
        }
        Debug.Log(value);
        StreamWriter sw = new StreamWriter(Application.streamingAssetsPath+ "/LayerStructure/"+ layerName+".txt");
        sw.Write(value);
        sw.Flush();
        sw.Close();


        return value;

    }

    public void addBoxData(Vector3 localScanle)
    {

        BoxData boxData = new BoxData();
        boxData.len = (int)localScanle.x*1000;
        boxData.width = (int)localScanle.z*1000;
        boxData.height = (int)localScanle.y*1000;

    }

    
}
