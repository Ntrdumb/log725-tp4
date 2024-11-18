using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToInitialPosition : Node
{
    private Transform enemy;
    private Vector3 initialPosition;

    public MoveToInitialPosition(Transform enemy, Vector3 initialPosition)
    {
        this.enemy = enemy;
        this.initialPosition = initialPosition;
    }

    public override NodeState Evaluate()
    {
        enemy.position = Vector3.MoveTowards(enemy.position, initialPosition, Time.deltaTime * 2f);

        if (Vector3.Distance(enemy.position, initialPosition) < 0.1f)
        {
            return NodeState.SUCCESS;
        }
        return NodeState.RUNNING;
    }
}