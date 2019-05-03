using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HistoryViewport : ViewportBase {

    public override void insStrategy()
    {
        List<string> list = CreateFolder.getFolderNameList(ConfigFile.dataDic["savePath"].getList()[0]);
        int index  = 0;
        foreach (string key in list)
        {
            insGameObject(ResourcesManager.prefabDic[ResName.SettingItem], new Vector3(-241, 252.5f) - new Vector3(0, 30) * index,key);
            index++;
        }
     

    }


    public override void updateViewportInfo()
    {
        foreach (GameObject g in getList())
        {
            Destroy(g);
        }


        List<string> list = CreateFolder.getFolderNameList(ConfigFile.dataDic["savePath"].getList()[0]);
        int index = 0;
        foreach (string key in list)
        {
            insGameObject(ResourcesManager.prefabDic[ResName.SettingItem], new Vector3(-241, 252.5f) - new Vector3(0, 30) * index, key);
            index++;
        }

    }
}
