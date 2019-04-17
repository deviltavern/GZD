using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeItemRecoverByListInfo : MonoBehaviour {



    public static GameObject insShateItem(int w, int l, int h, Color color)
    {
        GameObject g = GameObject.Instantiate(ResourcesManager.prefabDic[ResName.shapeItem], new Vector3(w * ShapeConstValue.spaceDistance, h + 0.5f, l * ShapeConstValue.spaceDistance), Quaternion.identity);
        string id = w + "-" + l + "-" + h+"-";
      
        g.GetComponent<MeshRenderer>().material.color = color;
        
        g.GetComponent<ShapeItem>().id = id;

        return g;

    }
    public static void Recover(Vector3 vec, List<string> data,Color co)
    {
        foreach (string key in data)
        {

            Recover(vec, key, co);
        }
    }
    public static void Recover(Vector3 vec,string id,Color color)
    {
        Debug.Log(id);
        string[] idArray = id.Split('-');
        List<int> parameterArray = new List<int>();
        
        for (int i = 0; i < idArray.Length-1; i++)
        {
            
            parameterArray.Add(int.Parse(idArray[i].Trim()));


        }
        Debug.Log(parameterArray.Count+":"+idArray.Length   );
        int w = parameterArray[0];
        int l = parameterArray[1];
        int h = parameterArray[2];
        GameObject insG = insShateItem(w, l, h, color);

        insG.transform.position += vec;

    }


}
