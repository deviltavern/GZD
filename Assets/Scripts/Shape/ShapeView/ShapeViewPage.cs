using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ShapeViewPage : MonoBehaviour {

    public RectTransform content;
    public RectTransform dataView;


    public List<string> getPathContent(string path)
    {
        List<string> list = new List<string>();
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        else
        {
            FileInfo[] infoArray = new DirectoryInfo(path).GetFiles();
            foreach (FileInfo info in infoArray)
            {

                string value = info.ToString();
                if (value.Contains(".txt") == true)
                {

                    list.Add(value);
                }

            }

        }

        return list;

    }


    private void Awake()
    {
        Debug.Log("123");
        dataView = this.transform.Find("DataView").GetComponent<RectTransform>();

        content = dataView.transform.Find("Content").GetComponent<RectTransform>();

       
      
    }
    private void Start()
    {
        List<string> fileList = getPathContent(Pather.shapePath);
        int index = 0;
        foreach (string value in fileList)
        {

            GameObject G = GameObject.Instantiate(ResourcesManager.prefabDic[ResName.shapeDataItem], this.content);
            G.GetComponent<RectTransform>().localPosition -= new Vector3(0, 30, 0) * index;

            Text G_text = G.transform.Find("Text").GetComponent<Text>();
            G_text.text = value.Split('\\')[value.Split('\\').Length - 1];
            OnClickShapeDataItemBtn btn = G.GetComponent<OnClickShapeDataItemBtn>();
            btn.parent = GameObject.Find("ShapeViewPoint").GetComponent<Transform>();
            StreamReader sr = new StreamReader(value);
            btn.data = sr.ReadToEnd();

            index++;
        }
    }
    public static void insShapeDataBtn(string path) {


            
    }



}
