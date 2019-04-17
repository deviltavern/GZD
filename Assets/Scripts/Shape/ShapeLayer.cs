using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShapeLayer:MonoBehaviour {

    private Dictionary<string, GameObject> layerDic = new Dictionary<string, GameObject>();

    public Button btn;

    public int index;

     

    public static void insLayer(Transform parent, List<ShapeLayer> layerList)
    {
       
        GameObject g = GameObject.Instantiate(ResourcesManager.prefabDic[ResName.layerItem], parent);
        g.GetComponent<RectTransform>().localPosition -= new Vector3(0, 30 * layerList.Count);
        layerList.Add(g.GetComponent<ShapeLayer>());

        Text t = g.GetComponentInChildren<Text>();
        t.text = "layer：" + layerList.Count;
        
    }
    void Awake()
    {

        btn = this.GetComponent<Button>();
        btn.onClick.AddListener(onClickThisLayer);
    }

    public void onClickThisLayer()
    {
        if (index % 2 == 0)
        {
            hideLayer();
        }
        else
        {
            showLayer();
        
        }
        index++;
        
    }
    public void showLayer()
    {
        foreach (GameObject g in layerDic.Values)
        {
            g.SetActive(true);
        }
    
    
        }
    public void hideLayer()
    {
        foreach (GameObject g in layerDic.Values)
        {
            g.SetActive(false);
        }
    
    
    
    }


    public void addLayerItem(string ID,GameObject g)
    {

        layerDic.Add(ID, g);

    
    
    }

}
