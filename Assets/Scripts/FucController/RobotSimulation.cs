using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RobotSimulation : ButtonEventBase {


    public override void onClickButton()
    {

        Debug.Log("点击了这玩意？");
      //StepInfoLoader.load(StepInfoCatcher.path);
      //StepInfoDispose.Instance.reLive();

        SceneManager.LoadScene("FileView");
        UIMaster.pointController.gameObject.SetActive(false);
    }
}
