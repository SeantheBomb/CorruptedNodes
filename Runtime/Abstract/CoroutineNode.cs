using Corrupted;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CoroutineNode : CorruptedNode<CoroutineNode, CoroutineNode>, ICoroutineModel
{


    protected abstract IEnumerator PlayNode(CoroutineRunner runner);

    protected virtual void StopNode(CoroutineRunner runner) { }


    public void RunTask(CoroutineRunner runner)
    {
        runner.StartTask(this);
    }

    public IEnumerator RunCoroutine(CoroutineRunner runner)
    {
        yield return PlayNode(runner);
        runner.StopTask(this);
    }

    public void StopTask(CoroutineRunner runner)
    {
        runner.StopTask(this);
        StopNode(runner);
    }


    public virtual void PlayNextInPath(CoroutineRunner runner)
    {
        PlayNextFromPort(runner, "Output");
    }

    public virtual void PlayNextFromPort(CoroutineRunner runner, string port)
    {
        foreach(CoroutineNode cn in GetPath(port))
        {
            cn.RunTask(runner);
        }
    }


}
