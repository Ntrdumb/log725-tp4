using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence : Node
{
    private List<Node> childNodes;

    public Sequence(List<Node> nodes)
    {
        childNodes = nodes;
    }

    public override NodeState Evaluate()
    {
        foreach (Node node in childNodes)
        {
            NodeState childState = node.Evaluate();
            if (childState == NodeState.FAILURE)
            {
                return NodeState.FAILURE;
            }
            else if (childState == NodeState.RUNNING)
            {
                return NodeState.RUNNING;
            }
        }
        return NodeState.SUCCESS;
    }
}
