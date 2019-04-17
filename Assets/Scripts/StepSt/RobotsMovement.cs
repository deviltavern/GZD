using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotsMovement : StepStrategyTemplates {
    public RobotsMovement()
     {}
     public StepInfo stepInfo { get; set; }

     public float theChangeDistance{ get; set; }
     
     public float speed { get; set; }
     public RobotsMovement(StepInfoDispose _dispose ,StepInfo info, float _theChangeDistance, float _speed) {
         this.stepInfoDispose = _dispose;
         this.stepInfo = info;
         this.theChangeDistance = _theChangeDistance;
         this.speed = _speed;

     
     
     }

    public override void doSomthing()
    {

        Robots.Instance.point_1.transform.rotation = Quaternion.LerpUnclamped(Robots.Instance.point_1.transform.rotation, Quaternion.Euler(stepInfo.toP1Euler()), Time.deltaTime * speed);
        Robots.Instance.point_2.transform.rotation = Quaternion.LerpUnclamped(Robots.Instance.point_2.transform.rotation, Quaternion.Euler(stepInfo.toP2Euler()), Time.deltaTime * speed);
        Robots.Instance.point_3.transform.rotation = Quaternion.LerpUnclamped(Robots.Instance.point_3.transform.rotation, Quaternion.Euler(stepInfo.toP3Euler()), Time.deltaTime * speed);
        float d1 = Vector3.Distance(Robots.Instance.point_1.transform.eulerAngles, stepInfo.toP1Euler());
        float d2 = Vector3.Distance(Robots.Instance.point_2.transform.eulerAngles, stepInfo.toP2Euler());
        float d3 = Vector3.Distance(Robots.Instance.point_3.transform.eulerAngles, stepInfo.toP3Euler());


        if ((d1 < theChangeDistance || Mathf.Abs(d1 - 360) < theChangeDistance) && (d2 < theChangeDistance || Mathf.Abs(d2 - 360) < theChangeDistance)

            && (d3 < theChangeDistance || Mathf.Abs(d3 - 360) < theChangeDistance))
        {

            stepInfoDispose.strategy = null;

            stepInfoDispose.index++;


        }



    }

    public override void waitting()
    {
        throw new System.NotImplementedException();
    }
}
