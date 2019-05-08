using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using UnityEngine;
using UnityEngine.UI;

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

    public static ConfigFile Instance;

    void Awake() {


        if (Instance == null)
        {
            Instance = this;
            LoadXml();
        }
        else
        {
            Debug.Log("已经存在ConfigFile");
        }

      

   

    
    
    
    
    }
    void Start () {

      //  updateXML();



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

        dataDic.Clear();
        //创建xml文档
        XmlDocument xml = new XmlDocument();

        xml.Load(Application.dataPath + "/data2.xml");
        //得到page节点下的所有子节点
        XmlNodeList xmlNodeList = xml.SelectSingleNode("page").ChildNodes;
        //遍历所有子节点，每个子节点都以列表形式保存
        foreach (XmlElement xl1 in xmlNodeList)
        {


            switch (xl1.Name)
            { 
                case "box_data_all":

                    BoxData.getData(xl1.ChildNodes);


                    break;

                case "baseboard_data_all":

                    BaseboardData.getData(xl1.ChildNodes);


                    break;

                default:
                    dataDic.Add(xl1.Name, new ListBaseX(xl1.ChildNodes));
                     
                    break;
            }
               
         
        }



        foreach (string key in dataDic.Keys)
        {

            foreach (string value in dataDic[key].getList())
            {

            }

        }
        //print(xml.OuterXml);
    }


    //修改BaseBoardData
   public static void updateBaseboardDataInXML(int width,int len,int typeBaseboard)
    {
        string path = Application.dataPath + "/data2.xml";
        print(path);
        if (File.Exists(path))
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(path);
           XmlNode root= xml.SelectSingleNode("page");
           XmlNode BoxNode = root.SelectSingleNode("baseboard_data_all");
           
                XmlElement element = xml.CreateElement("baseboard_data");

                XmlElement elementChild1 = xml.CreateElement("baseboard_id");
                elementChild1.InnerText = "" + typeBaseboard;
                
                XmlElement elementChild11 = xml.CreateElement("width");
                elementChild11.InnerText = ""+width;
                XmlElement elementChild12 = xml.CreateElement("len");
                elementChild12.InnerText = "" + len;
      
                //把节点一层一层的添加至xml中，注意他们之间的先后顺序，这是生成XML文件的顺序
                 element.AppendChild(elementChild1);
                 element.AppendChild(elementChild11);
                 element.AppendChild(elementChild12);

            BoxNode.AppendChild(element);
            xml.AppendChild(root);
                //最后保存文件

            xml.Save(path);
        }
    }
   public static void updateBoxDataInXML(int width, int len, int height, int Typenum)
   {
       string path = Application.dataPath + "/data2.xml";
       if (File.Exists(path))
       {
           XmlDocument xml = new XmlDocument();
           xml.Load(path);
           XmlNode root = xml.SelectSingleNode("page");
           XmlNode BoxNode = root.SelectSingleNode("box_data_all");

           XmlElement element = xml.CreateElement("box_data");

           XmlElement elementChild1 = xml.CreateElement("box_id");
           elementChild1.InnerText = "" + Typenum;

           XmlElement elementChild11 = xml.CreateElement("width");
           elementChild11.InnerText = "" + width;
           XmlElement elementChild12 = xml.CreateElement("height");
           elementChild12.InnerText = "" + height;
           XmlElement elementChild13 = xml.CreateElement("len");
           elementChild13.InnerText = "" + len;





           //把节点一层一层的添加至xml中，注意他们之间的先后顺序，这是生成XML文件的顺序
           element.AppendChild(elementChild1);
           element.AppendChild(elementChild11);
           element.AppendChild(elementChild12);
           element.AppendChild(elementChild13);

           BoxNode.AppendChild(element);
           xml.AppendChild(root);
           //最后保存文件

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







     

