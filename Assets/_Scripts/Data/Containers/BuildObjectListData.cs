using Data.Containers;
using System;
using System.Collections.Generic;
using UnityEngine;
namespace Data
{
    [Serializable]
    [CreateAssetMenu(fileName = "NewBuildObjectListData", menuName = "ScriptableSystems/Build System/Build Object List Data")]

    public class BuildObjectListData : ScriptableObject
    {
        public string id;
        public List<BuildObjectData> items;


    }
}