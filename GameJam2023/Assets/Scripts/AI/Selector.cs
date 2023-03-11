using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : Node
{
    public Selector(string n)
    {
        name = n;
    }

    public override Status Process()
    {
        Status childStatus = children[currentChild].Process();

        if (childStatus == Status.RUNNING)
        {
            return childStatus;
        }

        if(childStatus == Status.SUCCESS)
        {
            currentChild = 0;
            return childStatus;
        }

        currentChild++;
        if (currentChild >= children.Count)
        {
            currentChild = 0;
            return Status.FAILURE;
        }

        return Status.RUNNING;
    }
}
