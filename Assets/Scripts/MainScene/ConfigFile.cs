using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using UnityEngine;

public class ConfigFile : MonoBehaviour {

  //  public static Dictionary<string, string> stackDic = new Dictionary<string, string>();

  //public static ConfigFile _loadplayerinfo;

  //  //xml信息
  //  public string xmlName = "config";//xml文件名
  //  public string rootNodeName = "Player";//根节点name

  //  //申明xml对象
  //  private static XmlDocument xmlDoc = new XmlDocument();
  //  //申明src
  //  private static string Path;
  //  void Awake()
  //  {
  //      _loadplayerinfo = this;
  //      CreatePath();
  //  }

  //  /// <summary>
  //  /// 创建xml文件，
  //  /// </summary>
  //  public void CreatePath()
  //  {
  //      Path = Application.persistentDataPath + "/"+xmlName+".xml";
  //      if (!File.Exists(Path))
  //      {
  //          xmlDoc.LoadXml(((TextAsset)Resources.Load("Xml/"+xmlName)).text);
  //          xmlDoc.Save(Path);//存储xml文件
  //          Debug.Log("Create Success："+ Path);
  //      }
  //      else
  //      {
  //          xmlDoc.Load(Path);
  //          Debug.Log("Use Success:"+Path);
  //      }
  //  }




    public List<string> _list;
    private ArrayList Adialogue = new ArrayList();
    private ArrayList Bdialogue = new ArrayList();
    private ArrayList textList = new ArrayList();
    // Use this for initialization


    void Awake() {


        LoadXml();
    
    
    
    
    
    }
    void Start () {

 



    }

    // Update is called once per frame
    void Update () {

    }



    void CreateXML(List<string> _list)
    {
        string path = Application.dataPath + "/data2.xml";


        if (!File.Exists(path))
        {
            //创建最上一层的节点。
            XmlDocument xml = new XmlDocument();
            //创建最上一层的节点。
            XmlElement root = xml.CreateElement("page");
            foreach (string value in _list) {

                XmlElement element = xml.CreateElement(value);
                element.SetAttribute("id",value);

                 XmlElement element2 = xml.CreateElement("item");
                 element2.SetAttribute("value", "0");
                 element.AppendChild(element2);


                root.AppendChild(element);
                
            }
            xml.AppendChild(root);
            
            //把节点一层一层的添加至xml中，注意他们之间的先后顺序，这是生成XML文件的顺序


            //最后保存文件
            xml.Save(path);
        }
    }

   public static Dictionary<string, ListBaseX> dataDic = new Dictionary<string, ListBaseX>();
    void LoadXml()
    {
        //创建xml文档
        XmlDocument xml = new XmlDocument();

        xml.Load(Application.dataPath + "/data2.xml");
        //得到page节点下的所有子节点
        XmlNodeList xmlNodeList = xml.SelectSingleNode("page").ChildNodes;
        //遍历所有子节点，每个子节点都以列表形式保存
        foreach (XmlElement xl1 in xmlNodeList)
        {

            print("XMLINFO:"+xl1.GetAttribute("value"));
            dataDic.Add(xl1.Name, new ListBaseX(xl1.ChildNodes));
            
        }



        foreach (string key in dataDic.Keys)
        {

            foreach (string value in dataDic[key].getList())
            {
                print(key + "--" + value);
            }

        }
        //print(xml.OuterXml);
    }


    //修改
    void updateXML()
    {
        string path = Application.dataPath + "/data2.xml";
        if (File.Exists(path))
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(path);
            XmlNodeList xmlNodeList = xml.SelectSingleNode("objects").ChildNodes;
            foreach (XmlElement xl1 in xmlNodeList)
            {
                if (xl1.GetAttribute("id") == "1")
                {
                    //把messages里id为1的属性改为5
                    xl1.SetAttribute("id", "5");
                }

                if (xl1.GetAttribute("id") == "2")
                {
                    foreach (XmlElement xl2 in xl1.ChildNodes)
                    {
                        if (xl2.GetAttribute("map") == "abc")
                        {
                            //把mission里map为abc的属性改为df，并修改其里面的内容
                            xl2.SetAttribute("map", "df");
                            xl2.InnerText = "我成功改变了你";
                        }

                    }
                }
            }
            xml.Save(path);
        }
    }

    //添加XML
    void addXMLData()
    {
        string path = Application.dataPath + "/data2.xml";
        if (File.Exists(path))
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(path);
            XmlNode root = xml.SelectSingleNode("objects");
            //下面的东西就跟上面创建xml元素是一样的。我们把他复制过来就行了
            XmlElement element = xml.CreateElement("messages");
            //设置节点的属性
            element.SetAttribute("id", "2");
            XmlElement elementChild1 = xml.CreateElement("contents");

            elementChild1.SetAttribute("name", "b");
            //设置节点内面的内容
            elementChild1.InnerText = "天狼，你的梦想就是。。。。。";
            XmlElement elementChild2 = xml.CreateElement("mission");
            elementChild2.SetAttribute("map", "def");
            elementChild2.InnerText = "我要妹子。。。。。。。。。。";
            //把节点一层一层的添加至xml中，注意他们之间的先后顺序，这是生成XML文件的顺序
            element.AppendChild(elementChild1);
            element.AppendChild(elementChild2);

            root.AppendChild(element);

            xml.AppendChild(root);
            //最后保存文件
            xml.Save(path);
        }
    }

}







     

