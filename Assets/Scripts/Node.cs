public abstract class Node
{
    public enum NodeState { RUNNING, SUCCESS, FAILURE }
    protected NodeState state;

    public abstract NodeState Evaluate();
}
