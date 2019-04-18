using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CameraViewRotation : MonoBehaviour {

    public GameObject lookPoint;
    private GameObject insPoint;
    private GameObject insLookPoint;
    public Vector3 offset;
    public virtual void Awake()
    {
     

        
    }
    Vector3 initVec;
    public virtual void Start()
    {
        insLookPoint = GameObject.Instantiate(ResourcesManager.prefabDic[ResName.shapeItem], lookPoint.transform);
        insLookPoint.transform.localPosition = new Vector3();
        insPoint = GameObject.Instantiate(ResourcesManager.prefabDic[ResName.shapeItem], this.transform);
        insPoint.transform.localPosition = new Vector3();
        insPoint.transform.SetParent(insLookPoint.transform);
        Transform.Destroy(insPoint.GetComponent<MeshRenderer>());
        Transform.Destroy(insLookPoint.GetComponent<MeshRenderer>());
        initVec = insLookPoint.transform.position;


    }

    public void Update()
    {
        insLookPoint.transform.position = initVec+offset;
        insLookPoint.transform.Rotate(Vector3.up, 0.5f);
        this.transform.position = insPoint.transform.position;
        this.transform.LookAt(insLookPoint.transform.position);

    }

}
