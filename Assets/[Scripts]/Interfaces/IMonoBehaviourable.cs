using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMonoBehaviourable
{
    void MonoBehaviourAwake();
    void Start();
    void Update();
    void FixedUpdate();
}
