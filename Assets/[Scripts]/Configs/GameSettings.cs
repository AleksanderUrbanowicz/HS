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


        //  [ConfigSelector]
        public ParameterBase parameterBase = new ParameterBase();
        public DynamicParameter parameterdynamic = new DynamicParameter();


        [ConfigSelector(paramsSetKey = StringDefines.EmployeeTypeSelectorKey)]
        public string employeeType;

        [ConfigSelector(paramsSetKey = StringDefines.GuestTypeSelectorKey)]



        public string guestType;
        [ConfigSelector(paramsSetKey = StringDefines.MaterialTypeSelectorKey)]

        public string materialType;

        [ConfigSelector(paramsSetKey = StringDefines.ObjectTypeSelectorKey)]

        public string objectType;

        [ConfigSelector(paramsSetKey = StringDefines.MaterialSetSelectorKey)]

        public string materialSet;

        [ConfigSelector(paramsSetKey = StringDefines.BuildObjectSelectorKey)]


        public string defaultBuildObject;

        [ConfigSelector(paramsSetKey = StringDefines.BuildObjectCategorySelectorKey)]

        public string BuildObjectCategoryData;




        [ConfigSelector(paramsSetKey = StringDefines.GameEventSelectorKey)]

        public string gameEvent;

        [ConfigSelector(paramsSetKey = StringDefines.ScriptableEventSelectorKey)]

        public string scriptableEvent;

        [ConfigSelector(paramsSetKey = StringDefines.ThemeUIDataSelectorKey)]
        public string uiThemeData;



        [ConfigSelector(paramsSetKey = StringDefines.BuildObjectParameterSelectorKey)]
        public string buildObjectParameterTypes;

        [ConfigSelector(paramsSetKey = StringDefines.HotelParameterSelectorKey)]

        public string hotelParameterType;


        [ConfigSelector(paramsSetKey = StringDefines.AnyParameterSelectorKey)]

        public string anyParameterType;

        //[ConfigSelector(paramsSetKey = StringDefines.EmployeeSelectorKey)]

        //public string employee;

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