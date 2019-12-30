using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IConditionalExecutor 
{
   // bool CheckEventConditions { get; }
    bool CheckPreConditions { get; }
}
