using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class CreateFolder : MonoBehaviour {

   

    public List<string> folderValue = new List<string>();

    public Transform fileButtonParent;

    public static List<string> getFolderNameList(string path)
    {

  

        List<string> tempList = new List<string>();
        if (!Directory.Exists(path))
        {

            print("文件夹不存在！");
        }
        else
        {
            FileInfo[] infoArray = new DirectoryInfo(path).GetFiles();
            foreach (FileInfo info in infoArray)
            {

                string value = info.ToString();
                if (value.Contains(".txt") == true)
                {

                    tempList.Add(value);
                }

            }
           

        }
        return tempList;

    }

    void Awake()
    {
        fileButtonParent = GameObject.Find("Canvas").transform.Find("fileView").transform.Find("Content").gameObject.transform.Find("backGround");
        string path = ConfigFile.dataDic["savePath"].getList()[0];

        print(path);
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
                if (value.Contains(".txt") == true) {

                    folderValue.Add(value);
                }
               
            }
                
        }

      
        
    }

    void Start()
    {
        for (int i = 0; i < folderValue.Count; i++)
        {
            Debug.Log(i);
            GameObject g = GameObject.Instantiate(ResourcesManager.prefabDic[ResName.FileButton], fileButtonParent);
            g.GetComponent<RectTransform>().localPosition -= new Vector3( 33 * i,0, 0);
            FileButton button = g.GetComponent<FileButton>();
            string[] strArray = folderValue[i].Split('\\');
            string strValue = "";
            foreach (string key in strArray)
            {
                if (key.Contains(".txt") == true)
                {
                    strValue = key;
                }
            }
            g.transform.Find("Text").GetComponent<Text>().text = strValue;
            button.init(folderValue[i], strValue);

        }
    }

}
