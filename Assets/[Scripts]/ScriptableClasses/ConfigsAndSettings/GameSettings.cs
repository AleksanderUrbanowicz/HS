using Characters;
using Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Objects;
using EditorTools;
#if UNITY_EDITOR

#endif
namespace ScriptableData
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
        private List<ScriptableSystem> scriptableSystems;

        public List<ScriptableSystem> ScriptableSystems
        {
            get
            {
                if (scriptableSystems == null)
                {
                    scriptableSystems = new List<ScriptableSystem>() { scriptableBuildSystem, scriptableDataSystem, scriptableSelectSystem };

                }
                return scriptableSystems;
            }
        }

        private void OnEnable()
        {
#if UNITY_EDITOR
            allObjectsArray = EditorStaticTools.GetAllInstances<BuildObjectData>();
#endif
        }

        public BuildObjectData GetBuildObjectData(string _id)
        {
            /*
            allObjectsArray.FirstOrDefault(x => x.id == _id);
            for (int i = 0; i < allObjectsArray.Length; i++)
            {
                if (allObjectsArray[i].id == _id)
                {
                    return allObjectsArray[i];

                }

            }*/
            return allObjectsArray.FirstOrDefault(x => x.id == _id); ;
        }
    }
}