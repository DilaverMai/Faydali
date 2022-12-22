using System.Collections.Generic;

public class BtSequence:BTNode
{
    private List<BTNode> mChildren;
    private int mCurrentChild;
    
    public BtSequence(BehaviourTree tree,BTNode[] nodes):base(tree)
    {
        mChildren = new List<BTNode>(nodes);
        mCurrentChild = 0;
    }
    
    public override Results Execute()
    {
        if (mCurrentChild >= mChildren.Count)
        {
            return Results.Success;
        }

        Results result = mChildren[mCurrentChild].Execute();
        if (result == Results.Success)
        {
            mCurrentChild++;
            return Execute();
        }
        else if (result == Results.Failure)
        {
            return Results.Failure;
        }
        else
        {
            return Results.Running;
        }
    }
}