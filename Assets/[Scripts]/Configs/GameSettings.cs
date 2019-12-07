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


        [ConfigSelector(paramsSetKey ="CharacterType")]
        public string characterType;



        [ConfigSelector(paramsSetKey = "EmployeeType")]

        public string employeeType;

        [ConfigSelector(paramsSetKey = "GuestTypeSelector")]

        
        public string guestType;

        //  [MaterialTypeSelector]
        //  public string materialType;

        //  [ObjectTypeSelector]
        // public string objectType;

        //[BuildObjectMaterialSetSelector]
        //  public string materialSet;

        [ConfigSelector(paramsSetKey = "BuildObject")]
    
        public string defaultBuildObject;

       /// [BuildObjectCategorySelector]
       // public string BuildObjectCategoryData;

       // [SceneSelector]
        public string scene;

      //  [LevelSelector]
        public string level;


      //  [GameEventSelector]
        public string gameEvent;

       // [ScriptableEventSelector]
        public string scriptableEvent;

      //  [ThemeUIDataSelector]
        public string uiThemeData;

   

    //    [BuildObjectDynamicParameterTypeSelector]
        public string buildObjectDynamicParameterTypes;

        [ConfigSelector(paramsSetKey = "HtoelParameter")]
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