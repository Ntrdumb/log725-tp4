using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class CheckBulletDirection : Node
{
    private Transform enemy;
    private Transform player; 

    public CheckBulletDirection(Transform enemy, Transform player)
    {
        this.enemy = enemy;
        this.player = player;
    }

    public override NodeState Evaluate()
    {
        if (player == null)
        {
            return NodeState.FAILURE;
        }

        float relativePosition = player.position.x - enemy.position.x;

        if (relativePosition < 0)
        {
            UnityEngine.Debug.Log("Go left. (The left of the ennemy)");
            return NodeState.SUCCESS;
        }

        if (relativePosition > 0)
        {
            UnityEngine.Debug.Log("Go right. (The right of the ennemy)");
            return NodeState.FAILURE;
        }

        return NodeState.FAILURE;
    }
}