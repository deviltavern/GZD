using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class BoxData {
    public string id;
    public string box_attribute;
    public float width;
    public float height;
    public float len;
    public float rotation_x;
    public float rotation_y;
    public float rotation_z;
    public float scale_x;
    public float scale_y;
    public float scale_z;

    
    public string materialsType;
    public string type;
    public static Dictionary<string, BoxData> dic = new Dictionary<string, BoxData>();
    public GameObject Cube;
	public static void getData(XmlNodeList data)
    {
        dic.Clear();
        foreach (XmlElement element in data)
        {
            XmlNodeList list =  element.ChildNodes;
            BoxData data2 = new BoxData();
            foreach (XmlElement e2 in list)
            {
                switch (e2.Name) { 

                    case "box_id":
                        data2.id = e2.InnerText;
                        break;
                    case "width":
                        data2.width = int.Parse(e2.InnerText);
                        break;

                    case "height":
                        data2.height = int.Parse(e2.InnerText);
                        break;

                    case "materials_type":

                        data2.materialsType = e2.InnerText;


                        break;


                    case "len":
                        data2.len = int.Parse(e2.InnerText);
                        break;
                
                }

            
            }

            dic.Add(data2.id,data2);

        }
    
    
    }

    public static BoxData getBoxData(string value)
    {
        BoxData d = JsonUtility.FromJson<BoxData>(value);

        return d;
    }
    public Vector3 getLocalScale()
    {
        Vector3 vec = new Vector3(len/1000f,width/1000f,height/1000f);


        return vec;
    }

    public GameObject insCube(Transform parent)
    {
        GameObject g = GameObject.Instantiate(ResourcesManager.prefabDic["shapeItem"], parent);

        g.transform.localPosition = new Vector3(width, len, height);
        g.transform.localRotation = Quaternion.Euler(new Vector3(rotation_x, rotation_y, rotation_z));
        g.transform.localScale = new Vector3(scale_x, scale_y, scale_z);
        Cube = g;
        return g;
    }
    public override string ToString()
    {

      string str =  JsonUtility.ToJson(this);
        return str;
    }

    public BoxData(GameObject boxItem,string id)
    {
        width = boxItem.transform.localPosition.x;
        len = boxItem.transform.localPosition.y;
        height = boxItem.transform.localPosition.z;
        rotation_x = boxItem.transform.localRotation.x;
        rotation_y = boxItem.transform.localRotation.y;
        rotation_z = boxItem.transform.localRotation.z;
        scale_x = boxItem.transform.localScale.x;
        scale_y = boxItem.transform.localScale.y;
        scale_z = boxItem.transform.localScale.z;
        this.id = id;
    }

    public BoxData()
    {
       
    }
}
