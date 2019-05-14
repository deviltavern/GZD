using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
//底板数据
public class BaseboardData{
    //底板参数
    public string id;
    public int width;
    public int len;

    public static Dictionary<string, BaseboardData> Baseboard_dic = new Dictionary<string, BaseboardData>();

    public static void getData(XmlNodeList data)
    {
        Baseboard_dic.Clear();
        foreach (XmlElement element in data)
        {
            XmlNodeList list = element.ChildNodes;
            BaseboardData data3 = new BaseboardData();
            foreach (XmlElement e3 in list)
            {
                switch (e3.Name)
                {

                    case "baseboard_id":
                        data3.id = e3.InnerText;
                        break;
                    case "width":
                        data3.width = int.Parse(e3.InnerText);
                        break;
                    case "len":
                        data3.len = int.Parse(e3.InnerText);
                        break;

                }


            }

            Baseboard_dic.Add(data3.id, data3);

        }


    }

    public override string ToString()
    {

        string str = "";
        str += width + "\n";
        str += len + "\n";
        return str;
    }
}
