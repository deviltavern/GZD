using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EidtVaule : MonoBehaviour {
    public InputField EidtInput;
    public Button OkBtn;
    public Text pointText;
    public static EidtVaule Instance;


    void Awake()
    {
        Instance = this;
        pointText = this.transform.Find("TextX").GetComponent<Text>();
        EidtInput = this.transform.Find("EidtInput").GetComponent<InputField>();
        OkBtn = this.transform.Find("Ok").GetComponent<Button>();
    }
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
