using Corrupted;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineNodeRunner : CoroutineRunner
{

    public bool PlayOnAwake = true;

    public bool IsPlaying => current != null;

    protected CoroutineNode current;

    public CoroutineGraph graph;

    private void OnEnable()
    {
        if (PlayOnAwake)
            Play();
    }

    private void OnDisable()
    {
        if (IsPlaying)
            Stop();
    }


    public void Play()
    {
        if (IsPlaying)
        {
            return;
        }
        CoroutineNode entry = graph.GetEntry();
        if(entry != null)
        {
            StartTask(entry);
        }
    }


    public void Stop()
    {
        if(IsPlaying == false)
        {
            return;
        }
        StopAllTasks();
    }




}
