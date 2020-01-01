using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IScriptableManager 
{
    void Initialize(GameObject obj);
    void LoadState();
    void SaveState();

}
