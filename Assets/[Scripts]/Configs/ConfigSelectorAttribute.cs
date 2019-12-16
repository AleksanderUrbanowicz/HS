using System;
using System.Linq;
using UnityEditor;
using UnityEngine;


namespace EditorTools
{
    public class ConfigSelectorAttribute : PropertyAttribute
    {
        public string configKey;
        public string paramsSetKey;
        public ConfigBase config;
        public string[] parameters;

        public delegate string[] GetStringList();
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

        protected void UpdateParameters()
        {

#if UNITY_EDITOR
            if (config == null)
            {
                //configBase = EditorStaticTools.GetFirstInstance<Definitions>();
                if (string.IsNullOrEmpty(configKey))
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
                            if (configKey == configs[i].Key)
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
                if (String.IsNullOrEmpty(paramsSetKey) || paramsSetKey == StringDefines.AnyParameterSelectorKey)
                {
                    parameters = config.allSelectorParameters.ToArray();

                }
                else
                {
                    ParamsList plist = config.selectorParameters.FirstOrDefault(x => x.id == paramsSetKey);
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
                // int index = Mathf.Max(0, Array.IndexOf(list, property.stringValue));
                // index = EditorGUI.Popup(position, property.displayName, index, list);

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