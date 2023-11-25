using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;



public abstract class CorruptedNode<I,O> : CorruptedNode
{

    [Input] public I Input;
    [Output] public O Output;


    public O[] path => GetPath<O>("Output");
    public O link => GetLink<O>("Output");


    public bool HasNextNode<T>(string port = "Output") where T : O
    {
        foreach(O bn in GetPath(port))
        {
            if (bn is T)
                return true;

        }
        return false;
    }


    public O[] GetPath(string port)
    {
        return GetPath<O>(port);
    }

    public O GetLink(string port)
    {
        return GetLink<O>(port);
    }

}






public abstract class CorruptedNode : Node
{
    public T[] GetPath<T>(string port)
    {
        return GetPort(port).GetInputValues<T>();
    }

    public T GetLink<T>(string port)
    {
        return GetPort(port).GetInputValue<T>();
    }

    public override object GetValue(NodePort port)
    {
        return this;
    }
}
