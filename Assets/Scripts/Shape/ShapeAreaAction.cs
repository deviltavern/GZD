using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShapeAreaAction : MonoBehaviour {

	// Use this for initialization
   public int width;
   public int len;
   public int height;
    ShapeAreaPage page;
    public static ShapeAreaAction Instance;
    Transform DSParent;
    public static Dictionary<string, GameObject> insShapeItemDic = new Dictionary<string, GameObject>();

    private void Awake()
    {
        Instance = this;
    }
    void Start () {
        page = ShapeAreaPage.Instance;
        DSParent = GameObject.Find("DSParent").transform;
        page.insBtn.onClick.AddListener(OnClickInsBtn);
        spaceDistanc = 1.2f;


	}
    public float spaceDistanc;
    public void insShateItem(int w, int l, int h,Color color)
    {
        GameObject g = GameObject.Instantiate(ResourcesManager.prefabDic[ResName.shapeItem], new Vector3(w * spaceDistanc,  h+0.5f,l * spaceDistanc), Quaternion.identity);
        string id = w + "-" + l + "-" + h+"-";
        insShapeItemDic.Add(id, g);
        g.GetComponent<MeshRenderer>().material.color = color;
        page.layerList[h].addLayerItem(id, g);
        g.GetComponent<ShapeItem>().id = id;
        g.transform.SetParent(DSParent);

    }
    public void OnClickInsBtn() {
        width = int.Parse(page.widthInput.text);
        len = int.Parse(page.lenInput.text);
        height = int.Parse(page.heightInput.text);

        page.layerList.Clear();
        for (int i = 0; i < height; i++)
        {

            ShapeLayer.insLayer(LayerList.Instance.transform, page.layerList);



        }


            for (int _height = 0; _height < height; _height++)
            {
                Color color = ResourcesManager.colorList[_height];
                for (int _len = 0; _len < len; _len++)
                {
                    for (int _width = 0; _width < width; _width++)
                    {
                        insShateItem(_width, _len, _height, color);




                    }

                }
            }
    
   }
	
	// Update is called once per frame
	void Update () {
		
	}
}
