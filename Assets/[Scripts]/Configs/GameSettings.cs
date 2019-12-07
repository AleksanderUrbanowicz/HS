using ScriptableSystems;
using System;
using UnityEngine;
#if UNITY_EDITOR

#endif
namespace EditorTools
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "Settings/GameSettings")]

    [Serializable]
    public class GameSettings : ScriptableObject
    {
        public ScriptableBuildSystem scriptableBuildSystem;
        public ScriptableDataSystem scriptableDataSystem;
        public ScriptableSelectSystem scriptableSelectSystem;
        private BuildObjectData[] allObjectsArray;


        [ConfigSelector(paramsSetKey = GlobalConfig.CharacterTypeSelectorKey)]

        public string characterType;



        [ConfigSelector(paramsSetKey = GlobalConfig.EmployeeTypeSelectorKey)]


        public string employeeType;

        [ConfigSelector(paramsSetKey = GlobalConfig.GuestTypeSelectorKey)]



        public string guestType;
        [ConfigSelector(paramsSetKey = GlobalConfig.MaterialTypeSelectorKey)]

          public string materialType;

        [ConfigSelector(paramsSetKey = GlobalConfig.BuildObjectSelectorKey)]

        public string objectType;

        [ConfigSelector(paramsSetKey = GlobalConfig.MaterialSetSelectorKey)]

          public string materialSet;

        [ConfigSelector(paramsSetKey = GlobalConfig.BuildObjectSelectorKey)]


        public string defaultBuildObject;

        [ConfigSelector(paramsSetKey = GlobalConfig.BuildObjectCategorySelectorKey)]

        public string BuildObjectCategoryData;




        [ConfigSelector(paramsSetKey = GlobalConfig.GameEventSelectorKey)]

        public string gameEvent;

        [ConfigSelector(paramsSetKey = GlobalConfig.ScriptableEventSelectorKey)]

        public string scriptableEvent;

        [ConfigSelector(paramsSetKey = GlobalConfig.ThemeUIDataSelectorKey)]
        public string uiThemeData;



        [ConfigSelector(paramsSetKey = GlobalConfig.BuildObjectParameterSelectorKey)]
        public string buildObjectDynamicParameterTypes;

        [ConfigSelector(paramsSetKey = GlobalConfig.HotelParameterSelectorKey)]

        public string hotelParameterType;

        private void OnEnable()
        {
#if UNITY_EDITOR
            allObjectsArray = EditorStaticTools.GetAllInstances<BuildObjectData>();
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