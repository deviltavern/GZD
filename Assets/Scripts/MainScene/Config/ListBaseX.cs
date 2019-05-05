using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class ListBaseX  {

    private List<string> _list = new List<string>();
    public ListBaseX()
    { 
    
    }

    public ListBaseX(XmlNodeList data)
    {
        foreach (XmlElement value in data)
        {//为子节点下的每一个元素添加value属性
            _list.Add(value.GetAttribute("value"));
        
        }    
    
    }
    public void addList(string vlaue) {

        _list.Add(vlaue);
    
    
    }
    public List<string> getList()
    {

        return _list;


    }
}
