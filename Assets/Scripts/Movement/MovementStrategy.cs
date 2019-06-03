using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementStrategy : Strategy {

    public MovementStrategy(MovementStrategy _parent, MovementStrategy _workStrategy)
    {

        this.parent = _parent;
        this.workStrategy = _workStrategy;
        
    }

    public MovementStrategy() { }
    public MovementStrategy(MovementStrategy _parent)
    {

        this.parent = _parent;
        

    }
    public virtual void insNextStrategy()
    {


    }
    public MovementStrategy parent { get; set; }

    public MovementStrategy workStrategy { get; set; }

    public void changeStrategy(MovementStrategy _workStrategy)
    {
        workStrategy = _workStrategy;
            
    
    
    }

    public override void doSomthing()
    {

        if (workStrategy != null)
        {
            workStrategy.doSomthing();
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
