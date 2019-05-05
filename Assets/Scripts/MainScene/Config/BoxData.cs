using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class BoxData {
    public string id;
    public string box_attribute;
    public int width;
    public int height;
    public int len;

    public static Dictionary<string, BoxData> dic = new Dictionary<string, BoxData>();

	public static void getData(XmlNodeList data)
    {
       
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


                    case "len":
                        data2.len = int.Parse(e2.InnerText);
                        break;
                
                }

            
            }

            dic.Add(data2.id,data2);
            Debug.Log(data2.ToString());
        }
    
    
    }

    public override string ToString()
    {

        string str = "";
        str += width + "\n";
        str += height + "\n";
        str += len + "\n";
        return str;
    }


}
