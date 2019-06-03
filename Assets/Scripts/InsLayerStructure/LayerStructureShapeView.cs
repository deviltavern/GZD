using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class LayerStructureShapeView : MonoBehaviour
{


    public RectTransform viewport;
    public RectTransform Content;

  
    public Dictionary<string, LayerData> layerDic = new Dictionary<string, LayerData>();
    public List<GameObject> layerLabelList = new List<GameObject>();
    public static LayerStructureShapeView Instance;
    private void Awake()
    {

        viewport = this.GetComponent<RectTransform>();
        Content = viewport.Find("Content").GetComponent<RectTransform>();

        Instance = this;


     
    }

    private void Start()
    {
        updateShapeInfo(Application.streamingAssetsPath + "/LayerStructure");
    }


    public void insLabel(Dictionary<string,LayerData> layerDataDic,List<GameObject> labelList)
    {
        foreach(GameObject G in labelList)
        { GameObject.Destroy(G);

        }
        labelList.Clear();

      
        int index = 0;
        foreach (LayerData data in layerDataDic.Values)
        {

            GameObject label =  GameObject.Instantiate(ResourcesManager.prefabDic["layerViewItem"], Content.transform);
            label.transform.Find("Text").GetComponent<Text>().text = data.getFileName();
            label.GetComponent<RectTransform>().localPosition += new Vector3(0, 50 * index, 0);
            index++;
            labelList.Add(label);
            label.GetComponent<Button>().onClick.AddListener(delegate ()
            {
            onClickLayerLabel(label.GetComponent<Button>());


            });



        }
        
    }
    public void onClickLayerLabel(Button btn)
    {
        string name = btn.transform.Find("Text").GetComponent<Text>().text;
        LayerData layerData = layerDic[name];

        Debug.Log(layerData.ToString());

        LayerStructrueDataCache.Instance.DestroyAllLayerItem();
        LayerStructrueDataCache.Instance.insCubeFromLayerData(layerDic[name]);




    }

    public void updateShapeInfo(string path)
    {

        layerDic.Clear();

        DirectoryInfo Dir = new DirectoryInfo(path);


        FileInfo[] DirSub = Dir.GetFiles();

        foreach (FileInfo value in DirSub)
        {

            string[] valueArray = value.ToString().Split('.');

            if (valueArray[valueArray.Length - 1].TrimEnd() == "txt")
            {


                LayerData data = new LayerData(value.ToString());
                layerDic.Add(data.getFileName(),data);
             //   GameObject.Instantiate();
            }


        }

        insLabel(layerDic, layerLabelList);






    }
}