
using Managers;
using System;
using UnityEditor;
using UnityEngine;

namespace UI
{
    public class PluggableAssetSelector : PropertyAttribute
    {
        //private string configKey;
        private string assetTypeKey;
        private SingletonUIManager config;
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

        //   public string ConfigKey { get => configKey; set => configKey = value; }
        public string AssetTypeKey { get => assetTypeKey; set => assetTypeKey = value; }

        protected void UpdateParameters()
        {

#if UNITY_EDITOR
            if (config == null)
            {
                config = SingletonUIManager.EditorInstance;
            }




#endif

            if (config != null)
            {
                if (String.IsNullOrEmpty(AssetTypeKey) || AssetTypeKey == "Color")
                {

                    parameters = config.colors.ToArray();
                    //Debug.LogError("UpdateParameters.colors: "+parameters.Length);
                }
                else if (AssetTypeKey == "Sprite")
                {
                    parameters = config.sprites.ToArray();
                    //Debug.LogError("UpdateParameters.sprites: " + parameters.Length);
                }

            }

        }
    }


#if UNITY_EDITOR
    [CustomPropertyDrawer(typeof(PluggableAssetSelector))]
    public class PluggableAssetSelectorDrawer : PropertyDrawer
    {

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            //var stringInList = attribute as PluggableAssetSelector;
            var list = (attribute as PluggableAssetSelector).Elements;
            if (property.propertyType == SerializedPropertyType.String)
            {


                if (list == null || list.Length == 0)
                {

                    property.stringValue = "null";
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