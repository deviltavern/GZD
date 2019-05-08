using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsAimShape : MonoBehaviour,IViewer {


    bool selectShape;
    public List<GameObject> gList = new List<GameObject>();

    public static InsAimShape Instance;
    public Dictionary<string, GameObject> dic = new Dictionary<string, GameObject>();
    string data;



    void Awake()
    {
        Instance = this;
        OnClickShapeDataItemBtn.addViewers(this);
        selectShape = false;
    }

    GameObject emp;
    public void update(ViewInfo info)
    {

        data = info.arg1;


        foreach (GameObject g in gList)
        {
            Destroy(g);
        }
        gList.Clear();
        dic.Clear();
        selectShape = true;
        emp = GameObject.Instantiate(ResourcesManager.prefabDic[ResName.shapeItem],new Vector3(),Quaternion.identity);
       
        string[] dataArray = data.Split('&');
        Debug.Log(dataArray.Length);
        foreach (string key in dataArray)
        {

            if (key == "")
                continue;
            ShapeItemData sd = JsonUtility.FromJson<ShapeItemData>(key);
            GameObject G = GameObject.Instantiate(ResourcesManager.prefabDic[ResName.shapeItem], emp.transform);

            dic.Add(sd.ID, G);

          
            G.transform.localPosition = sd.getVector3();
            G.GetComponent<MeshRenderer>().material = ResourcesManager.materialDic[ResName.AimPointMateril];

        }

        Dictionary<int, ReshapeItem> reshapeDic = new Dictionary<int, ReshapeItem>();
        foreach (string key in dic.Keys)
        {
            string[] keyArray = key.Split('-');

            int w = int.Parse(keyArray[0]);
            int l = int.Parse(keyArray[1]);
            int h = int.Parse(keyArray[2]);


            if (reshapeDic.ContainsKey(h) == false)
            {
                reshapeDic.Add(h, new ReshapeItem());
                reshapeDic[h].list.Add(key);
            }
            else
            {
                reshapeDic[h].list.Add(key);
            }

        }
        int max = 0;

        foreach (int keyValue in reshapeDic.Keys)
        {
            if (keyValue > max)
            {
                max = keyValue;
            }

        }
        List<int> layerList = new List<int>();

        for (int layerValue = 0; layerValue <= max; layerValue++)
        {
            layerList.Add(layerValue);
        }

        foreach (int v in layerList)
        {
            foreach (string _key in reshapeDic[v].list)
            {
                 
                 gList.Add(dic[_key]);
                
            }

        }




    }



    Ray ray;

    RaycastHit hit;
    private void Update()
    {
        if (selectShape == true)
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            bool isTouch = Physics.Raycast(ray, out hit);
            if (isTouch == true)
            {
                Debug.Log("碰撞");
                if (hit.collider.tag == "Map")
                {
                    emp.transform.position = hit.point;
                }
               
            }



        }

        if (Input.GetMouseButtonDown(1)) {

            selectShape = false;
           // Destroy(emp);
        }
        


    }


}


class ReshapeItem {
    public List<string> list = new List<string>();

}
