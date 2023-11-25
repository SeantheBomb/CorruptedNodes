using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;


[CreateAssetMenu(fileName ="CoroutineGraph", menuName = "Corrupted/Nodes/Coroutine")]
public class CoroutineGraph : NodeGraph
{


    public virtual CoroutineNode GetEntry()
    {
        foreach(Node n in nodes){
            if(n is EntryNode en)
            {
                return en.GetLink<CoroutineNode>("start");
            }
        }
        return null;
    }

}
