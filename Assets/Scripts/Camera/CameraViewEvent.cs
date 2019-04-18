using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraViewEvent : ObviewerTemplates
{

    Button btn;
    private void Awake()
    {
        btn = this.GetComponent<Button>();

        btn.onClick.AddListener(OnClickBtn);

        addViewer(CameraRotation.Instance);
        mouseICON = Resources.Load<Texture2D>("mouse3");
    }

    public void OnClickBtn() {
        selectStatus = true;
    }
    bool selectStatus = false;

    Texture2D mouseICON;
    Ray ray;
    RaycastHit hit;

    private void Update()
    {
        if (selectStatus == false)
        {

            Cursor.SetCursor(null, new Vector2(), CursorMode.Auto);

        }
        else {

            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            bool isHit = Physics.Raycast(ray, out hit);
            if (isHit == true&&Input.GetMouseButtonDown(0))
            {
                GameObject g = hit.collider.gameObject;

                ViewInfo info = new ViewInfo();
                info.code = 1;
                info.aimObje = g;
                broadCast(info);
                selectStatus = false;



            }
            Cursor.SetCursor(mouseICON, new Vector2(), CursorMode.Auto);

        }
        
    }
}
