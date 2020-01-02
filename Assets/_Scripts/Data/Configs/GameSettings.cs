using Assets._Scripts.Data.Containers;
using Assets._Scripts.Gameplay.Managers;
using Assets._Scripts.StateMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
#if UNITY_EDITOR

#endif
namespace Assets._Scripts.Data.Configs
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "Data/Settings/GameSettings")]

    [Serializable]
    public class GameSettings : ScriptableObject
    {
        public GlobalConfig globalConfig;
        public ScriptableBuildSystem scriptableBuildSystem;
        public ScriptableDataSystem scriptableDataSystem;
        public ScriptableSelectSystem scriptableSelectSystem;
        public BuildObjectData[] allObjectsArray;
        public Vector2Int charactersRandomSpread;
        public List<PluggableCharacterData> debugCharactersToSpawn = new List<PluggableCharacterData>();
        public List<ScriptableSystem> scriptableSystems;

        public State buildObjectStartState;
        public State remainInState;

        private void OnEnable()
        {
#if UNITY_EDITOR
            // allObjectsArray = EditorStaticTools.GetAllInstances<BuildObjectData>();
#endif
        }

        public BuildObjectData GetBuildObjectData(string _id)
        {

            //allObjectsArray.FirstOrDefault(x => x.id == _id);
            for (int i = 0; i < allObjectsArray.Length; i++)
            {
                if (allObjectsArray[i].id == _id)
                {
                    return allObjectsArray[i];

                }

            }
            return allObjectsArray.FirstOrDefault(x => x.id == _id); ;
        }
    }
}