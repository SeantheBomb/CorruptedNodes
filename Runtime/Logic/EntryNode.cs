using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateNodeMenu("_Start/Entry"), NodeTint(25, 200, 25)]
public class EntryNode : CorruptedNode
{

    [Output] public CorruptedNode start;

}
