using Characters;
using ScriptableSystems;
using System;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR

#endif
namespace EditorTools
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "Settings/GameSettings")]

    [Serializable]
    public class GameSettings : ScriptableObject
    {
        public GlobalConfig globalConfig;
        public ScriptableBuildSystem scriptableBuildSystem;
        public ScriptableDataSystem scriptableDataSystem;
        public ScriptableSelectSystem scriptableSelectSystem;
        private BuildObjectData[] allObjectsArray;
        public Vector2Int charactersRandomSpread;
        public List<PluggableCharacterData> debugCharactersToSpawn = new List<PluggableCharacterData>();
        public List<ScriptableSystem> scriptableSystems = new List<ScriptableSystem>();
        private void OnEnable()
        {
#if UNITY_EDITOR
          //  allObjectsArray = EditorStaticTools.GetAllInstances<BuildObjectData>();
#endif
        }

        public BuildObjectData GetBuildObjectData(string _id)
        {

            for (int i = 0; i < allObjectsArray.Length; i++)
            {
                if (allObjectsArray[i].id == _id)
                {
                    return allObjectsArray[i];

                }

            }
            return new BuildObjectData();
        }
    }
}