using UnityEngine;

public class TestNode : BTNode
{
    private Vector3 randomPosition;
    private float timer;
    public TestNode(BehaviourTree tree) : base(tree)
    {
        randomPosition = tree.transform.position;
    }

    public bool FindNextPosition()
    {
        object obj;
        bool found = Tree.mBlackboard.TryGetValue("FindPosition", out obj);

        if (found)
        {
            randomPosition = new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));
        }

        return found;
    }

    public override Results Execute()
    {
        if (!FindNextPosition())
            return Results.Failure;
        
        if (Vector3.Distance(Tree.transform.position,randomPosition) > 0.1f)
        {
            Tree.transform.position = Vector3.MoveTowards(Tree.transform.position, randomPosition, 0.1f);
            return Results.Running;
        }

        return Results.Success;
    }
}