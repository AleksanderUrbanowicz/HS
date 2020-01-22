using BaseLibrary.StateMachine;
using Data;
using System;
using UnityEditor;
using UnityEngine;

namespace Managers
{
    [Serializable]
    [CreateAssetMenu(fileName = "Helper_BuildObjects", menuName = "Managers/ Build Objects Helper")]

    public class BuildObjectsHelperData : ScriptableObject
    {
        public int currentBuildObjectIndex = 0;
        public BuildObjectData[] buildObjectsData;
        public ScriptableEvent currentchangedEvent;
        public BuildObjectData currentBuildObject;
        // public BuildManagerMonoBehaviourHookup monoBehaviourHookup;

        public BuildObjectData CurrentBuildObject
        {
            get
            {
                //for inspector
                currentBuildObject = BuildObjectsData[CurrentBuildObjectIndex];
                return currentBuildObject;
            }

        }



        public void OnEnable()
        {
            CurrentBuildObjectIndex++;
            if (currentchangedEvent == null)
            {
                Debug.LogError("BuildObjectsHelper.OnEnable: currentchangedEvent==null");
                ScriptableEvent scriptableEvent = new ScriptableEvent();
                string path = "Assets/Resources/ScriptableObjects/Auto/" + "Event_CurrentChanged.asset";
                AssetDatabase.CreateAsset(scriptableEvent, path);


                currentchangedEvent = scriptableEvent;
            }

        }


        public int CurrentBuildObjectIndex
        {
            get
            {
                return currentBuildObjectIndex;
            }
            set
            {
                if (value != currentBuildObjectIndex)
                {
                    currentBuildObjectIndex = value % BuildObjectsData.Length;
                    currentchangedEvent.Raise();
                }

            }
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