using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LayerStructureItem : MonoBehaviour {
    public GameObject LayerCube;
    public GameObject InsLayerCube;
    public GameObject InsLayerball;
    public GameObject initBall;
    public GameObject baseBoard;
    public Text InsAngelLabel;
    Camera ca;
    LayerStructurePage page;
    public static LayerStructureItem Instance;

    private void Awake()
    {
        Instance = this;


    }

    Ray ray;
    Physics hit;
   public void Start()
    {
        page = LayerStructurePage.Instance;
  
        LayerCube = Resources.Load<GameObject>("insLayerCube");
      //  InsLayerCube = GameObject.Instantiate(LayerCube,this.transform);
        InsLayerball = Resources.Load<GameObject>("insBall");
        InsAngelLabel = Resources.Load<Text>("AngelLabel");

        baseBoard = this.transform.Find("board").gameObject;
        //initBall = GameObject.Instantiate(InsLayerball, this.transform);
        // ca.ScreenPointToRay(Input.mousePosition);
    }
}
