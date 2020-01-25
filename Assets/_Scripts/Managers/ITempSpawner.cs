using Data;
using UnityEngine;

namespace BaseLibrary.Interfaces
{
    public interface ITempSpawner : ISpawner
    {
        GameObject InstanceGameObject { get; }
        ISpawnableBuildObject SpawnableInstance { get; set; }
        void DestroyInstance();

        void ToggleInstance(bool b);
    }
}