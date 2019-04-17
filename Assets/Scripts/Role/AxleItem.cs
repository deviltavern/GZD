using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxleItem : MonoBehaviour {
    public GameObject rulerBoard;
    public GameObject item;

    public MeshRenderer meshRenderal;
    public Material itemMaterial { get; set; }
    public  Material changeMaterial{ get; set; }
    
    public virtual void Awake()
    {
        item = this.transform.Find("item").gameObject;
       
        meshRenderal = item.GetComponent<MeshRenderer>();
        itemMaterial = meshRenderal.material;
        StartCoroutine(IEDelayInit());
        
    }


    IEnumerator IEDelayInit()
    {
        yield return new WaitForSeconds(Time.deltaTime);
        if(ResourcesManager.materialDic.ContainsKey(ResourcesManager.AxleColor))
        changeMaterial = ResourcesManager.materialDic[ResourcesManager.AxleColor];
    }
    public static void onPointThisChangeItem(string id)
    {
        foreach (string g in RobotA.Instance.axleDic.Keys)
        {
            if (g == id)
            {
                RobotA.Instance.axleDic[g].GetComponent<AxleItem>().meshRenderal.material = RobotA.Instance.axleDic[g].GetComponent<AxleItem>().changeMaterial;


            }
            else
            {
                RobotA.Instance.axleDic[g].GetComponent<AxleItem>().meshRenderal.material = RobotA.Instance.axleDic[g].GetComponent<AxleItem>().itemMaterial;


            }
            
        }
    
    }


    public void hideRulerBoard()
    {
        if (rulerBoard != null)
        {
            rulerBoard.gameObject.SetActive(false);
        
        }
    
    }
	



}
