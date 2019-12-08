

#define HIDE
//#define LOGS
using Characters;
using ScriptableSystems;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace EditorTools
{

    [Serializable]
    [CreateAssetMenu(fileName = "GlobalConfig", menuName = "Config/Global Config")]
    public class GlobalConfig : ConfigBase
    {

        /// //////////////////////////////////Settings/Selectors///////////////////////////////////////////////////////////

        new public const string Key = "GlobalConfig";
        private  bool isInitialized;
        

        [ConfigSelector]
        public string anySelector;

        public static  string[] autoIncludeParams ={ "Receptionist","Waiter", "Maid", "Comfort","Hygiene", "Affordability", "Renown","Personel","Durability", "Cleanness","Wood", "Cloth"};

      /// <summary>
      /// //////////////////////////////////Scriptable Objects///////////////////////////////////////////////////////////
      /// </summary>

#if HIDE
        [HideInInspector]
        #endif
        public List<EmployeeData> employeeDatas = new List<EmployeeData>();
#if HIDE
        [HideInInspector]
#endif
        public List<GuestData> guestDatas = new List<GuestData>();
#if HIDE
        [HideInInspector]
#endif
        public List<CharacterDataBase> characterDatas = new List<CharacterDataBase>();
#if HIDE
        [HideInInspector]
#endif
        public BuildObjectData[] buildObjects;
#if HIDE
        [HideInInspector]
#endif
        public BuildObjectCategoryData[] buildObjectCategories;
#if HIDE
        [HideInInspector]
#endif
        public BuildObjectListData[] buildObjectLists;
#if HIDE
        [HideInInspector]
#endif
        public GameEvent[] gameEvents;
#if HIDE
        [HideInInspector]
#endif
        public ScriptableEvent[] scriptableEvents;
#if HIDE
        [HideInInspector]
#endif
        public ThemeUIData[] uiThemes;
#if HIDE
        [HideInInspector]
#endif
        public BuildObjectMaterialSet[] materialSets;

        /// <summary>
        /// ////////////////////////////////////////Color Customizer////////////////////////////////////////////////////////
        /// </summary>
        public Color[] colorsSet;
        public Color guestColor;
        public Color employeeColor;
        public Color buildObjectColor;
        public Color defaultColor;
        /// //////////////////////////////////Tabs///////////////////////////////////////////////////////////


#if HIDE
        [HideInInspector]
#endif
        public bool characterTabOpen;
#if HIDE
        [HideInInspector]
#endif
        public bool colorsCustomizerTabOpen;
#if HIDE
        [HideInInspector]
#endif
        public bool definitionsTabOpen;

#if HIDE
        [HideInInspector]
#endif
        public bool objectsTabOpen;

        /// /////////////////////////////////////////////////////////////////////////////////////////////



        //public List<CharacterType> characterTypes = new List<CharacterType>();
        public List<EmployeeType> employeeTypes = new List<EmployeeType>();
        public List<GuestType> guestTypes = new List<GuestType>();



        private void Awake()
        {
#if LOGS
            Debug.LogError("GlobalConfig.Awake");
#endif
            InitSelectors();
        }

        public void InitSelectors()
        {
#if UNITY_EDITOR
            if (!isInitialized)
            {
               // Debug.LogError("GlobalConfig.InitSelectors");
                if (selectorParameters.FirstOrDefault(x => x.id == StringDefines.EmployeeParameterSelectorKey) == null)
                {
                    selectorParameters.Add(new ParamsList(StringDefines.EmployeeParameterSelectorKey, new List<string>()));
                }
                if (selectorParameters.FirstOrDefault(x => x.id == StringDefines.GuestParameterSelectorKey) == null)
                {
                    selectorParameters.Add(new ParamsList(StringDefines.GuestParameterSelectorKey, new List<string>()));
                }
                if (selectorParameters.FirstOrDefault(x => x.id == StringDefines.HotelParameterSelectorKey) == null)
                {
                    selectorParameters.Add(new ParamsList(StringDefines.HotelParameterSelectorKey, new List<string>()));
                }
                if (selectorParameters.FirstOrDefault(x => x.id == StringDefines.BuildObjectParameterSelectorKey) == null)
                {
                    selectorParameters.Add(new ParamsList(StringDefines.BuildObjectParameterSelectorKey, new List<string>()));
                }
                if (selectorParameters.FirstOrDefault(x => x.id == StringDefines.BuildObjectSelectorKey) == null)
                {
                    selectorParameters.Add(new ParamsList(StringDefines.BuildObjectSelectorKey, new List<string>()));

                }
                if (selectorParameters.FirstOrDefault(x => x.id == StringDefines.BuildObjectCategorySelectorKey) == null)
                {
                    selectorParameters.Add(new ParamsList(StringDefines.BuildObjectCategorySelectorKey, new List<string>()));

                }
                if (selectorParameters.FirstOrDefault(x => x.id == StringDefines.BuildObjectsListSelectorKey) == null)
                {
                    selectorParameters.Add(new ParamsList(StringDefines.BuildObjectsListSelectorKey, new List<string>()));
                }
                if (selectorParameters.FirstOrDefault(x => x.id == StringDefines.MaterialSetSelectorKey) == null)
                {
                    selectorParameters.Add(new ParamsList(StringDefines.MaterialSetSelectorKey, new List<string>()));
                }
                if (selectorParameters.FirstOrDefault(x => x.id == StringDefines.GameEventSelectorKey) == null)
                {
                    selectorParameters.Add(new ParamsList(StringDefines.GameEventSelectorKey, new List<string>()));
                }
                selectorParameters.Add(new ParamsList(StringDefines.ThemeUIDataSelectorKey, new List<string>()));
                selectorParameters.Add(new ParamsList(StringDefines.ScriptableEventSelectorKey, new List<string>()));
                selectorParameters.Add(new ParamsList(StringDefines.EmployeeTypeSelectorKey, new List<string>()));
                selectorParameters.Add(new ParamsList(StringDefines.GuestTypeSelectorKey, new List<string>()));
                selectorParameters.Add(new ParamsList(StringDefines.ObjectTypeSelectorKey, new List<string>()));
                selectorParameters.Add(new ParamsList(StringDefines.MaterialTypeSelectorKey, new List<string>()));
               foreach(string s in autoIncludeParams)
                {
                    if (!allSelectorParameters.Contains(s))
                    {



                        allSelectorParameters.Add(s);
                    }
                }
                isInitialized = true;
            }
#endif
        }


        private void OnEnable()
        {
#if LOGS
            Debug.LogError("GlobalConfig.OnEnable");
#endif

            OnEnableMethod();
        }

        public void OnEnableMethod()
        {
#if UNITY_EDITOR


            UpdateScriptableSelectors();
            UpdateCharacters();
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

            employeeDatas = EditorStaticTools.GetAllInstances<EmployeeData>().ToList();
            AddOrEditSelectorParams(StringDefines.EmployeeSelectorKey, employeeDatas.Select(x => x.id).ToList());

            guestDatas = EditorStaticTools.GetAllInstances<GuestData>().ToList();
            AddOrEditSelectorParams(StringDefines.GuestSelectorKey, guestDatas.Select(x => x.id).ToList());



#endif
        }


        public void UpdateCharacters()
        {

            SetSelectorParameters(StringDefines.EmployeeTypeSelectorKey, employeeTypes.Select(x => x.id).ToList());
            SetSelectorParameters(StringDefines.GuestTypeSelectorKey, guestTypes.Select(x => x.id).ToList());
        }

        public List<string> GetSelectorParameters(string key)
        {
           ParamsList paramsList= selectorParameters.FirstOrDefault(x => x.id == key);
            if(paramsList!=null)
            {

                return paramsList.parameters;
            }
            return new List<string>();

        }

        public void SetSelectorParameters(string _key, List<string> _parameters)
        {
            if(_parameters==null)
            {
                return;

            }
            ParamsList selectorParams = selectorParameters.FirstOrDefault(x => x.id == _key);
            if(selectorParams!=null)
            {
              
                foreach (string s in _parameters)
                {
                    if (!allSelectorParameters.Contains(s) )
                    {

                        allSelectorParameters.Add(s);
                        #if LOGS
                        Debug.LogError("GlobalConfig.SetSelectorParameters.Add: " + s);
#endif
                    }

                }

                selectorParams.parameters = _parameters;
               
            }

        }

        public void AddOrEditSelectorParams(ParamsList _paramsList)
        {
            if(GetSelectorParameters(_paramsList.id)==null)
            {
                selectorParameters.Add(_paramsList);
                foreach(string s in _paramsList.parameters)
                {
                    if(!allSelectorParameters.Contains(s))
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
            //Debug.LogError("GlobalConfig.AddOrEditSelectorParams, _key,  count: " + _key+","+_parameters.Count); 
            if(_parameters==null)
            {
                _parameters = new List<string>();

            }
            foreach (string s in _parameters)
            {
                if (!allSelectorParameters.Contains(s))
                {

                    allSelectorParameters.Add(s);
#if LOGS
                    Debug.LogError("GlobalConfig.AddOrEditSelectorParams.Add: " + s);
#endif

                }

            }
            if (GetSelectorParameters(_key) == null)
            {
                selectorParameters.Add(new ParamsList(_key,_parameters));
                
            }
            else
            {
                SetSelectorParameters(_key, _parameters);

            }



        }

    }
}