using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToWall : Node
{
    private Transform enemy;
    private Vector3 targetPosition; 
    private float speed = 2f; 

    public MoveToWall(Transform enemy, Vector3 targetPosition)
    {
        this.enemy = enemy;
        this.targetPosition = targetPosition;
    }

    public override NodeState Evaluate()
    {
        if (enemy == null)
        {
            return NodeState.FAILURE;
        }

        enemy.position = Vector3.MoveTowards(enemy.position, targetPosition, speed * Time.deltaTime);

        if (Vector3.Distance(enemy.position, targetPosition) < 0.1f)
        {
            return NodeState.SUCCESS;
        }

        return NodeState.RUNNING;
    }
}
