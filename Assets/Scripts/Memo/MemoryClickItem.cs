using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MemoryClickItem : MonoBehaviour, IObviewer, IPointerDownHandler, IPointerUpHandler
{
    public const int down = 0;
    public const int up = 1;
    private List<IViewer> viewList = new List<IViewer>();
    void Awake()
    {
       
    
    }

    void Start()
    {
        viewList.Add(MemoryEvent.Instance);
    }
    public void addViewer(IViewer view)
    {
        viewList.Add(view);
        
    }

    public void deleteViewer(IViewer view)
    {
        viewList.Remove(view);
    }

    public void broadCast(ViewInfo info)
    {
        Debug.Log(viewList[0]);  
        foreach (IViewer viewer in viewList)
        {
            viewer.update(info);
        
        }
       
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        ViewInfo info = new ViewInfo();
        info.code = MemoryClickItem.down;
        broadCast(info);


    }

    public void OnPointerUp(PointerEventData eventData)
    {
        ViewInfo info = new ViewInfo();
        info.code = MemoryClickItem.up;
        broadCast(info);
      
    }
}
