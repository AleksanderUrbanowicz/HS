using Data;
using Data.Containers;
using Data.Definitions;
using HotelSimulator.Data;
using System;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace EditorUtilities
{
    public class ConfigSelectorAttribute : PropertyAttribute
    {
        private string configKey;
        private string paramsSetKey;
        private ConfigBase config;
        private string[] parameters;

        public string[] Elements
        {
            get
            {
                if (parameters != null)
                {
                    return parameters;
                }

                UpdateParameters();
                return parameters;
            }
        }

        public string ConfigKey { get => configKey; set => configKey = value; }
        public string ParamsSetKey { get => paramsSetKey; set => paramsSetKey = value; }

        protected void UpdateParameters()
        {

#if UNITY_EDITOR
            if (config == null)
            {
                if (string.IsNullOrEmpty(ConfigKey))
                {
                    config = EditorStaticTools.GetFirstInstance<GlobalConfig>();

                }
                else
                {
                    ConfigBase[] configs = EditorStaticTools.GetAllInstances<ConfigBase>();
                    if (configs != null && configs.Length > 0)
                    {
                        for (int i = 0; i < configs.Length; i++)
                        {
                            if (ConfigKey == configs[i].Key)
                            {
                                config = configs[i];

                            }

                        }


                    }
                }

            }

#endif

            if (config != null)
            {
                if (String.IsNullOrEmpty(ParamsSetKey) || ParamsSetKey == StringDefines.AnyParameterSelectorKey)
                {
                    parameters = config.allSelectorParameters.ToArray();

                }
                else
                {
                    ParamsList plist = config.selectorParameters.FirstOrDefault(x => x.id == ParamsSetKey);
                    if (plist != null && plist.parameters != null)
                    {
                        parameters = plist.parameters.ToArray();

                    }
                }

            }

        }
    }


#if UNITY_EDITOR
    [CustomPropertyDrawer(typeof(ConfigSelectorAttribute))]
    public class BuildObjectStaticParameterTypeSelectorDrawer : PropertyDrawer
    {

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var stringInList = attribute as ConfigSelectorAttribute;
            var list = stringInList.Elements;
            if (property.propertyType == SerializedPropertyType.String)
            {


                if (list == null || list.Length == 0)
                {

                    property.stringValue = "";
                }
                else
                {
                    int index = Mathf.Max(0, Array.IndexOf(list, property.stringValue));
                    index = EditorGUI.Popup(position, property.displayName, index, list);
                    property.stringValue = list[index];
                }
            }

            else
            {
                base.OnGUI(position, property, label);
            }
        }
    }
#endif

}