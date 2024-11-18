using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : Node
{
    private List<Node> childNodes;

    public Selector(List<Node> nodes)
    {
        childNodes = nodes;
    }

    public override NodeState Evaluate()
    {
        foreach (Node node in childNodes)
        {
            NodeState childState = node.Evaluate();
            if (childState == NodeState.SUCCESS)
            {
                return NodeState.SUCCESS;
            }
            else if (childState == NodeState.RUNNING)
            {
                return NodeState.RUNNING;
            }
        }
        return NodeState.FAILURE;
    }
}
