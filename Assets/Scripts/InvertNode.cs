using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class InvertNode : Node
{
    private Node childNode;

    public InvertNode(Node node)
    {
        childNode = node;
    }

    public override NodeState Evaluate()
    {
        NodeState childState = childNode.Evaluate();

        switch (childState)
        {
            case NodeState.SUCCESS:
                return NodeState.FAILURE;
            case NodeState.FAILURE:
                return NodeState.SUCCESS;
            default:
                return NodeState.RUNNING;
        }
    }
}

