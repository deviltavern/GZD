using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSchedule : LabelEvent {


    public static TimeSchedule Instance;

    public override void Awake()
    {
        base.Awake();
        Instance = this;
    }
}
