using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ViewPortItemBase : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    bool allowDrag = false;
    void Update()
    {

        if (allowDrag == true)
        {

            this.transform.parent.localPosition += new Vector3(0, Input.mouseScrollDelta.y);


        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        allowDrag = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        allowDrag = false;
    }
}
