using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerStructure3DManager : MonoBehaviour {

    public static LayerStructure3DManager Instance;

    public GameObject viewItem;
    public GameObject viewItemSon;
    private void Awake()
    {
        Instance = this;
        viewItem = this.transform.Find("viewItem").gameObject;
        viewItemSon = viewItem.transform.Find("Cube").gameObject;

    }
}
