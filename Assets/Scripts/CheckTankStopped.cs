using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTankStopped : Node
{
    private Transform tank;

    public CheckTankStopped(Transform tank)
    {
        this.tank = tank;
    }

    public override NodeState Evaluate()
    {
        bool tankFiring = false; 

        return tankFiring ? NodeState.FAILURE : NodeState.SUCCESS;
    }
}
