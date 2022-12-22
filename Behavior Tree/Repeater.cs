using UnityEngine;

public class Repeater : DecoratorNode
{
    public Repeater(BehaviourTree tree, BTNode child) : base(tree, child)
    {
        
    }

    public override Results Execute()
    {
        Debug.Log("Child Result: " + Child.Execute());
        return Results.Running;
    }
}