


using Characters;
using EditorTools;
using ScriptableSystems;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Collections;
using UnityEngine;

namespace EditorTools
{

    [CreateAssetMenu(fileName = "GlobalConfig", menuName = "Config/Global Config")]

    public class GlobalConfig : ConfigBase
    {
        new public string Key = "GlobalConfig";

        public const string EmployeeParameterSelectorKey = "EmployeeParameter";
        public const string GuestParameterSelectorKey = "GuestParameter";
        public const string HotelParameterSelectorKey = "HotelParameter";
        public const string BuildObjectParameterSelectorKey = "HotelParameter";

        public const string BuildObjectSelectorKey = "BuildObject";
        public const string BuildObjectCategorySelectorKey = "BuildObjectCategory";
        public const string BuildObjectsListSelectorKey = "BuildObjectCategory";
        public const string MaterialSetSelectorKey = "MaterialSet";
        public const string ThemeUIDataSelectorKey = "ThemeUIData";

        public const string GameEventSelectorKey = "GameEvent";
        public const string ScriptableEventSelectorKey = "ScriptableEvent";
        public const string EmployeeTypeSelectorKey = "EmployeeType";
        public const string GuestTypeSelectorKey = "GuestType";
        public const string CharacterTypeSelectorKey = "CharacterType";
        public const string ObjectTypeSelectorKey = "ObjectType";
        public const string AnyParameterSelectorKey = "AnyParameter";
        public const string MaterialTypeSelectorKey = "MaterialType";
        public const float spaceFloat = 6.0f;

        public List<CharacterType> characterTypes = new List<CharacterType>();
        public List<EmployeeType> employeeTypes = new List<EmployeeType>();
        public List<GuestType> guestTypes = new List<GuestType>();

        public List<EmployeeData> employeeDatas = new List<EmployeeData>();
        public List<GuestData> guestDatas = new List<GuestData>();
        public List<CharacterDataBase> characterDatas = new List<CharacterDataBase>();
        public BuildObjectData[] buildObjects;
        public BuildObjectCategoryData[] buildObjectCategories;
        public BuildObjectListData[] buildObjectLists;
        public GameEvent[] gameEvents;
        public ScriptableEvent[] scriptableEvents;
        public ThemeUIData[] uiThemes;
        public BuildObjectMaterialSet[] materialSets;
        public Color[] colorsSet;
        public Color guestColor;
        public Color employeeColor;

        

        public bool generatorTabOpen;
        public bool colorsCustomizerTabOpen;
        public bool definitionsTabOpen;


        private void OnEnable()
        {
            OnEnableMethod();
        }

        public void OnEnableMethod()
        {
#if UNITY_EDITOR

            employeeDatas = EditorStaticTools.GetAllInstances<EmployeeData>().ToList();
            guestDatas = EditorStaticTools.GetAllInstances<GuestData>().ToList();
            characterDatas = EditorStaticTools.GetAllInstances<CharacterDataBase>().ToList();

#endif
        }

        public void GetScriptableObjects()
        {
#if UNITY_EDITOR
            buildObjects = EditorStaticTools.GetAllInstances<BuildObjectData>();
            buildObjectCategories = EditorStaticTools.GetAllInstances<BuildObjectCategoryData>();
            buildObjectLists = EditorStaticTools.GetAllInstances<BuildObjectListData>();

            gameEvents = EditorStaticTools.GetAllInstances<GameEvent>();
            scriptableEvents = EditorStaticTools.GetAllInstances<ScriptableEvent>();

            uiThemes = EditorStaticTools.GetAllInstances<ThemeUIData>();
            materialSets = EditorStaticTools.GetAllInstances<BuildObjectMaterialSet>();



            employeeDatas = EditorStaticTools.GetAllInstances<EmployeeData>().ToList();
            guestDatas = EditorStaticTools.GetAllInstances<GuestData>().ToList();
            characterDatas = EditorStaticTools.GetAllInstances<CharacterDataBase>().ToList();
#endif
        }

        public void SetScriptableSelectors()
        {
#if UNITY_EDITOR
            buildObjects = EditorStaticTools.GetAllInstances<BuildObjectData>();
            SetSelectorParameters(BuildObjectSelectorKey, buildObjects.Select(x => x.id).ToList());
            buildObjectCategories = EditorStaticTools.GetAllInstances<BuildObjectCategoryData>();
            buildObjectLists = EditorStaticTools.GetAllInstances<BuildObjectListData>();

            gameEvents = EditorStaticTools.GetAllInstances<GameEvent>();
            scriptableEvents = EditorStaticTools.GetAllInstances<ScriptableEvent>();

            uiThemes = EditorStaticTools.GetAllInstances<ThemeUIData>();
            materialSets = EditorStaticTools.GetAllInstances<BuildObjectMaterialSet>();



            employeeDatas = EditorStaticTools.GetAllInstances<EmployeeData>().ToList();
            guestDatas = EditorStaticTools.GetAllInstances<GuestData>().ToList();
            characterDatas = EditorStaticTools.GetAllInstances<CharacterDataBase>().ToList();



#endif
        }

        public List<string> GetSelectorParameters(string key)
        {
            //List<string> selectorParams=new List<string>();
            return selectorParameters.FirstOrDefault(x => x.id == key).parameters;

        }

        public void SetSelectorParameters(string _key, List<string> _parameters)
        {
            ParamsList selectorParams = selectorParameters.FirstOrDefault(x => x.id == _key);
            if(selectorParams==null)
            {
                selectorParams = new ParamsList(_key, _parameters);
                selectorParameters.Add(selectorParams);

            }

        }

    }
}