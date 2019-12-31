

#define HIDE
//#define LOGS
using Definitions;
using EditorTools;
using Objects;
using StateMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using UI;
using UnityEngine;

namespace ScriptableData
{

    [Serializable]
    [CreateAssetMenu(fileName = "GlobalConfig", menuName = "Config/Global Config")]
    public class GlobalConfig : ConfigBase
    {

        /// //////////////////////////////////Settings/Selectors///////////////////////////////////////////////////////////

        new public const string Key = "GlobalConfig";
        [ConfigSelector]
        public List<string> interactionParameters = new List<string>();
        public List<string> bonusParameters = new List<string>();

        public TransformRuntimeCollection AllPluggableTransforms;

        public PluggableRuntimeCollection AllPluggables;

        public PluggableRuntimeCollection AllPasiveInteractables;
        public PluggableRuntimeCollection AllActiveInteractables;

        private bool isInitialized;


        public static string[] autoIncludeParams = { "Receptionist", "Waiter", "Maid", "Comfort", "Hygiene", "Affordability", "Renown", "Personel", "Durability", "Cleanness", "Wood", "Cloth" };

        /// <summary>
        ///Scriptable Objects///////////////////////////////////////////////////////////
        /// </summary>

        [HideInInspector] public BuildObjectData[] buildObjects;
        [HideInInspector] public BuildObjectCategoryData[] buildObjectCategories;
        [HideInInspector] public BuildObjectListData[] buildObjectLists;
        [HideInInspector] public GameEvent[] gameEvents;
        [HideInInspector] public ScriptableEvent[] scriptableEvents;
        [HideInInspector] public ThemeUIData[] uiThemes;
        [HideInInspector] public BuildObjectMaterialSet[] materialSets;

        /// <summary>
        /// Color Customizer////////////////////////////////////////////////////////
        /// </summary>
        public Color[] colorsSet;
        public Color guestColor = Color.green;
        public Color employeeColor = Color.red;
        public Color buildObjectColor = Color.blue;
        public Color defaultColor = Color.black;
        /// //////////////////////////////////Tabs///////////////////////////////////////////////////////////

        [HideInInspector] public bool initTabOpen;
        [HideInInspector] public bool characterTabOpen;
        [HideInInspector] public bool colorsCustomizerTabOpen;
        [HideInInspector] public bool definitionsTabOpen;
        [HideInInspector] public bool objectsTabOpen;


        private void Awake()
        {
#if UNITY_EDITOR
            InitColors();
            InitSelectors();
#endif
            //  Debug.LogError("GlobalConfig Awake");

        }


        public void InitColors()
        {
            colorsSet = Enumerable.Repeat(Color.white, Enum.GetValues(typeof(ColorPurpose)).Length).ToArray();
        }
        //Rework whole concept
        public void InitSelectors()
        {

            if (!isInitialized)
            {
                // Debug.LogError("GlobalConfig.InitSelectors");
                //if (selectorParameters.FirstOrDefault(x => x.id == StringDefines.EmployeeParameterSelectorKey) == null)
                // {
                selectorParameters.Add(new ParamsList(StringDefines.EmployeeParameterSelectorKey, new List<string>()  {
            StringDefines.EmployeeParameterSelectorKey+"1",
            StringDefines.EmployeeParameterSelectorKey+"2",
            StringDefines.EmployeeParameterSelectorKey+"3"
        }));
                //  }
                if (selectorParameters.FirstOrDefault(x => x.id == StringDefines.GuestParameterSelectorKey) == null)
                {
                    selectorParameters.Add(new ParamsList(StringDefines.GuestParameterSelectorKey, new List<string>(){
            StringDefines.GuestParameterSelectorKey+"1",
            StringDefines.GuestParameterSelectorKey+"2",
            StringDefines.GuestParameterSelectorKey+"3"
        }));
                }
                // if (selectorParameters.FirstOrDefault(x => x.id == StringDefines.HotelParameterSelectorKey) == null)
                //  {
                selectorParameters.Add(new ParamsList(StringDefines.HotelParameterSelectorKey, new List<string>(){
            StringDefines.HotelParameterSelectorKey+"1",
            StringDefines.HotelParameterSelectorKey+"2",
            StringDefines.HotelParameterSelectorKey+"3"
        }));
                //   }
                //if (selectorParameters.FirstOrDefault(x => x.id == StringDefines.BuildObjectParameterSelectorKey) == null)
                // {
                selectorParameters.Add(new ParamsList(StringDefines.BuildObjectParameterSelectorKey, new List<string>(){
            StringDefines.BuildObjectParameterSelectorKey+"1",
            StringDefines.BuildObjectParameterSelectorKey+"2",
            StringDefines.BuildObjectParameterSelectorKey+"3"
        }));
                //   }
                if (selectorParameters.FirstOrDefault(x => x.id == StringDefines.BuildObjectSelectorKey) == null)
                {
                    selectorParameters.Add(new ParamsList(StringDefines.BuildObjectSelectorKey, new List<string>(){
            StringDefines.BuildObjectSelectorKey+"1",
            StringDefines.BuildObjectSelectorKey+"2",
            StringDefines.BuildObjectSelectorKey+"3"
        }));

                }
                if (selectorParameters.FirstOrDefault(x => x.id == StringDefines.BuildObjectCategorySelectorKey) == null)
                {
                    selectorParameters.Add(new ParamsList(StringDefines.BuildObjectCategorySelectorKey, new List<string>(){
            StringDefines.BuildObjectCategorySelectorKey+"1",
            StringDefines.BuildObjectCategorySelectorKey+"2",
            StringDefines.BuildObjectCategorySelectorKey+"3"
        }));

                }
                if (selectorParameters.FirstOrDefault(x => x.id == StringDefines.BuildObjectsListSelectorKey) == null)
                {
                    selectorParameters.Add(new ParamsList(StringDefines.BuildObjectsListSelectorKey, new List<string>(){
            StringDefines.BuildObjectsListSelectorKey+"1",
            StringDefines.BuildObjectsListSelectorKey+"2",
            StringDefines.BuildObjectsListSelectorKey+"3"
        }));
                }
                if (selectorParameters.FirstOrDefault(x => x.id == StringDefines.MaterialSetSelectorKey) == null)
                {
                    selectorParameters.Add(new ParamsList(StringDefines.MaterialSetSelectorKey, new List<string>(){
            StringDefines.MaterialSetSelectorKey+"1",
            StringDefines.MaterialSetSelectorKey+"2",
            StringDefines.MaterialSetSelectorKey+"3"
        }));
                }
                if (selectorParameters.FirstOrDefault(x => x.id == StringDefines.GameEventSelectorKey) == null)
                {
                    selectorParameters.Add(new ParamsList(StringDefines.GameEventSelectorKey, new List<string>(){
            StringDefines.GameEventSelectorKey+"1",
            StringDefines.GameEventSelectorKey+"2",
            StringDefines.GameEventSelectorKey+"3"
        }));
                }


                selectorParameters.Add(new ParamsList(StringDefines.EmployeeTypeSelectorKey, new List<string>(){
            StringDefines.EmployeeTypeSelectorKey+"1",
            StringDefines.EmployeeTypeSelectorKey+"6",
            StringDefines.EmployeeTypeSelectorKey+"6"
        }));
                selectorParameters.Add(new ParamsList(StringDefines.GuestTypeSelectorKey, new List<string>(){
            StringDefines.GuestTypeSelectorKey+"1",
            StringDefines.GuestTypeSelectorKey+"6",
            StringDefines.GuestTypeSelectorKey+"9"
        }));
                selectorParameters.Add(new ParamsList(StringDefines.ObjectTypeSelectorKey, new List<string>(){
            StringDefines.ObjectTypeSelectorKey+"1",
            StringDefines.ObjectTypeSelectorKey+"6",
            StringDefines.ObjectTypeSelectorKey+"9"
        }));
                selectorParameters.Add(new ParamsList(StringDefines.MaterialTypeSelectorKey, new List<string>(){
            "Default"
        }));
                foreach (string s in autoIncludeParams)
                {
                    if (!allSelectorParameters.Contains(s))
                    {



                        allSelectorParameters.Add(s);
                    }
                }
                isInitialized = true;
            }

        }

        private void OnEnable()
        {

            OnEnableMethod();
        }

        public void OnEnableMethod()
        {
#if UNITY_EDITOR


            UpdateScriptableSelectors();

#endif
        }



        public void UpdateScriptableSelectors()
        {
#if UNITY_EDITOR
            buildObjects = EditorStaticTools.GetAllInstances<BuildObjectData>();
            AddOrEditSelectorParams(StringDefines.BuildObjectSelectorKey, buildObjects.Select(x => x.id).ToList());

            buildObjectCategories = EditorStaticTools.GetAllInstances<BuildObjectCategoryData>();
            AddOrEditSelectorParams(StringDefines.BuildObjectCategorySelectorKey, buildObjectCategories.Select(x => x.id).ToList());

            buildObjectLists = EditorStaticTools.GetAllInstances<BuildObjectListData>();
            AddOrEditSelectorParams(StringDefines.BuildObjectsListSelectorKey, buildObjectLists.Select(x => x.id).ToList());

            gameEvents = EditorStaticTools.GetAllInstances<GameEvent>();
            AddOrEditSelectorParams(StringDefines.GameEventSelectorKey, gameEvents.Select(x => x.id).ToList());

            scriptableEvents = EditorStaticTools.GetAllInstances<ScriptableEvent>();
            AddOrEditSelectorParams(StringDefines.ScriptableEventSelectorKey, scriptableEvents.Select(x => x.id).ToList());


            uiThemes = EditorStaticTools.GetAllInstances<ThemeUIData>();
            AddOrEditSelectorParams(StringDefines.ThemeUIDataSelectorKey, uiThemes.Select(x => x.id).ToList());

            materialSets = EditorStaticTools.GetAllInstances<BuildObjectMaterialSet>();
            AddOrEditSelectorParams(StringDefines.MaterialSetSelectorKey, materialSets.Select(x => x.id).ToList());



#endif
        }



        public List<string> GetSelectorParameters(string key)
        {
            ParamsList paramsList = selectorParameters.FirstOrDefault(x => x.id == key);
            if (paramsList != null)
            {

                return paramsList.parameters;
            }
            return new List<string>();

        }

        public void SetSelectorParameters(string _key, List<string> _parameters)
        {
            if (_parameters == null)
            {
                return;

            }
            ParamsList selectorParams = selectorParameters.FirstOrDefault(x => x.id == _key);
            if (selectorParams != null)
            {

                foreach (string s in _parameters)
                {
                    if (!allSelectorParameters.Contains(s))
                    {

                        allSelectorParameters.Add(s);

                    }

                }

                selectorParams.parameters = _parameters;

            }

        }


        public void AddOrEditSelectorParams(ParamsList _paramsList)
        {
            if (GetSelectorParameters(_paramsList.id) == null)
            {
                selectorParameters.Add(_paramsList);
                foreach (string s in _paramsList.parameters)
                {
                    if (!allSelectorParameters.Contains(s))
                    {

                        allSelectorParameters.Add(s);


                    }

                }
            }
            else
            {
                SetSelectorParameters(_paramsList.id, _paramsList.parameters);

            }



        }
        public void AddOrEditSelectorParams(string _key, List<string> _parameters)
        {
            if (_parameters == null)
            {
                _parameters = new List<string>();

            }
            foreach (string s in _parameters)
            {
                if (!allSelectorParameters.Contains(s))
                {

                    allSelectorParameters.Add(s);


                }

            }
            if (GetSelectorParameters(_key) == null)
            {
                selectorParameters.Add(new ParamsList(_key, _parameters));

            }
            else
            {
                SetSelectorParameters(_key, _parameters);

            }



        }

    }
}