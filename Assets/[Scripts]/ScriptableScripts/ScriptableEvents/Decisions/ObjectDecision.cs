using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectDecision : Decision
{
    public abstract bool Decide(BuildObjectStateControllerMB controller);
}
