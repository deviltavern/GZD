using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryToAimShapeStrategy : Strategy {

    public GameObject originObject;
    public List<GameObject> targetShape;
  
    public CarryToAimShapeStrategy(GameObject origin,List<GameObject> _targetShape)
    {
        this.originObject = origin;
        this.targetShape = _targetShape;
        code = -1;
    }


    int code = 0;
    int index = 0;
    public override void doSomthing()
    {
      
        switch (code)
        {
            case -1:

                SelfMotionManager.selfMotionStrategy = new SelfMotionStrategyX(originObject);

                code++;
                break;

            case 0:
                if (SelfMotionManager.selfMotionStrategy.endStrategy() == true)
                {
                    code++;
                }
                break;

            case 1:
                MachineHand.carryObj.SetActive(true);
                code++;
                break;


            case 2:
                SelfMotionManager.selfMotionStrategy = new SelfMotionStrategyX(targetShape[index]);
                code++;
                break;

            case 3:

                if (SelfMotionManager.selfMotionStrategy.endStrategy() == true)
                {
                    code++;
                }
                break;


            case 4:
                MachineHand.carryObj.SetActive(false);

                code++;
                break;

            case 5:
                targetShape[index].GetComponent<MeshRenderer>().material = ResourcesManager.materialDic[ResName.OnGetOriginMateril];

                code++;
                break;

            case 6:
                if (index >= targetShape.Count)
                {
                    code = 7;
                }
                else {
                    index++;
                    code = -1;
                }
                
                break;

            case 7:


                break;
        }
       
    }

    public override void waitting()
    {
       
    }

    public override void onEnd()
    {
        throw new System.NotImplementedException();
    }
}
