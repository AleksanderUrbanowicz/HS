using Data;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Managers
{
    [Serializable]
    [CreateAssetMenu(fileName = "Helper_BuildObjects", menuName = "Managers/ Build Objects Helper")]

    public class BuildObjectsHelper : ScriptableObject
    {
        public int currentBuildObjectIndex = 0;
        public BuildObjectData[] buildObjectsData;

       // public BuildManagerMonoBehaviourHookup monoBehaviourHookup;

        public BuildObjectData CurrentBuildObject
        {
            get
            {
                return BuildObjectsData[CurrentBuildObjectIndex];
            }

        }
        public int CurrentBuildObjectIndex
        {
            get
            {
                return currentBuildObjectIndex;
            }
            set => currentBuildObjectIndex = value % BuildObjectsData.Length;
        }
        public BuildObjectData[] BuildObjectsData
        {
            get
            {
                if (buildObjectsData == null || buildObjectsData.Length == 0)
                {

                    buildObjectsData = Resources.LoadAll<BuildObjectData>("");
                    if (buildObjectsData.Length == 0)
                    {

                        Debug.LogError("No build Objects");

                        return null;
                    }
                }
                return buildObjectsData;
            }
            set => buildObjectsData = value;
        }
    }
}