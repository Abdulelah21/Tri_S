using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : State
{
    public ChaseState chaseState;

    public bool inRange;

    public override State RunCurrentState()
    {

        if (inRange)
        {
            return chaseState;
        }
        else
        {
            return this;
        }

    }
}
