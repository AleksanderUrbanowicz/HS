using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Interfaces
{
    public interface ISpawner
    {
        GameObject CreateInstance(Transform parent, Vector3 position, Quaternion rotation, ISpawnable spawnable = null);
    }
}