using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideBehindWall : Node
{
    private Ennemi enemy;

    public HideBehindWall(Ennemi enemy)
    {
        this.enemy = enemy;
    }

    public override NodeState Evaluate()
    {
        enemy.StartHiding();
        return NodeState.SUCCESS;
    }
}