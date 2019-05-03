using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StyleSecletPageEX2 : MonoBehaviour {

    public Button ipBtn;
    public Button portBtn;
    public Button kindBtn;

    public Dropdown dropDown;


    public InputField ipInput;
    public InputField portInput;
    
    private void Awake()
    {
        ipBtn = this.transform.Find("s_ipBtn").GetComponent<Button>();
        portBtn = this.transform.Find("s_portBtn").GetComponent<Button>();
        kindBtn = this.transform.Find("s_kindBtn").GetComponent<Button>();
        dropDown = this.transform.Find("s_labalDropdown").GetComponent<Dropdown>();
        ipInput = this.transform.Find("s_ipInput").GetComponent<InputField>();
        portInput = this.transform.Find("s_portInput").GetComponent<InputField>();
        ipBtn.onClick.AddListener(onClickIpBtn);
        portBtn.onClick.AddListener(onClickPortBtn);
        kindBtn.onClick.AddListener(onClickKindBtn);

    


    }
    ListBaseX data;
    void Start() {

        data = ConfigFile.dataDic["cs_kind"];
        ipInput.text = ConfigFile.dataDic["cs_ip"].getList()[0];

        portInput.text = ConfigFile.dataDic["cs_port"].getList()[0];


        foreach (string key in data.getList())
        {


            print(key);


        }
        dropDown.AddOptions(data.getList());

    }
    void Update()
    {
       // dropDown.AddOptions(data.getList());
    }
    public void onClickIpBtn()
    {

    }


    public void onClickPortBtn()
    {


    }
    public void onClickKindBtn()
    {


    }
}
