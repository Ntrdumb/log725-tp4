using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBulletNearby : Node
{
    private Transform enemy;
    private GameObject[] bullets;
    private float detectionRange;

    public CheckBulletNearby(Transform enemy, GameObject[] bullets, float detectionRange)
    {
        this.enemy = enemy;
        this.bullets = bullets;
        this.detectionRange = detectionRange;
    }

    public override NodeState Evaluate()
    {
        if (bullets == null || bullets.Length == 0)
        {
            return NodeState.FAILURE;
        }

        foreach (var bullet in bullets)
        {
            if (bullet == null) continue; 

            float distance = Vector3.Distance(enemy.position, bullet.transform.position);
            if (distance < detectionRange)
            {
                return NodeState.SUCCESS;
            }
        }
        return NodeState.FAILURE;
    }
}
