using System;
using UnityEngine;
namespace Assets._Scripts.Data.Containers
{
    [Serializable]
    [CreateAssetMenu(fileName = "NewBuildObjectCategoryData", menuName = "ScriptableSystems/Build System/Build Object Category Data")]

    public class BuildObjectCategoryData : ScriptableObject
    {

        public string id;
        public BuildObjectListData buildObjectListData;
    }
}