using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUpdateExecutor : IExecutor, IConditionalExecutor
{
    void StartExecute();
    void StopExecute();

    
   
    bool CheckUpdateConditions { get; }
}
