using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBoardDisposer : MonoBehaviour {

    public GameObject baseBoard;

    public static BaseBoardDisposer Instance;
    public List<GameObject> insShapeItemList = new List<GameObject>();

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


        
    }


    public void changeValue(float width,float len)
    {
        baseBoard.transform.localScale = new Vector3(width,1, len);

    }

    public void changeWL(BoxData data)
    {
        foreach (GameObject G in insShapeItemList) {
            G.GetComponent<MeshRenderer>().material = ResourcesManager.materialDic[data.materialsType];
        }



    }

    public void insShape(ShapeData data)
    {
        clearShape();
        foreach (ShapeItemData itemData in data.shapeItemDataList)
        {
            // GameObject.Instantiate();

            GameObject G = GameObject.Instantiate(ResourcesManager.prefabDic[ResName.shapeItem]);

            G.transform.SetParent(insParent);
            G.transform.localPosition = itemData.getVector3();

            
            insShapeItemList.Add(G);



        }


    }



    
}
