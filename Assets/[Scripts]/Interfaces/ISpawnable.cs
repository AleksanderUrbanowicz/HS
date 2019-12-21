using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Interfaces
{
    public interface ISpawnable
    {
        GameObject GetPrefab { get; }

        string GetID { get; }
    }
}