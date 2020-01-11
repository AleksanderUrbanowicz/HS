using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

//Author: internet
namespace Data.Containers
{

    public class EditorStaticTools
    {
#if UNITY_EDITOR
        static List<string> layers;
        static string[] layerNames;


        public static LayerMask LayerMaskField(string label, LayerMask selected)
        {

            if (layers == null)
            {
                layers = new List<string>();
                layerNames = new string[4];
            }
            else
            {
                layers.Clear();
            }

            int emptyLayers = 0;
            for (int i = 0; i < 32; i++)
            {
                string layerName = LayerMask.LayerToName(i);

                if (layerName != "")
                {

                    for (; emptyLayers > 0; emptyLayers--)
                    {
                        layers.Add("Layer " + (i - emptyLayers));
                    }
                    layers.Add(layerName);
                }
                else
                {
                    emptyLayers++;
                }
            }

            if (layerNames.Length != layers.Count)
            {
                layerNames = new string[layers.Count];
            }
            for (int i = 0; i < layerNames.Length; i++)
            {
                layerNames[i] = layers[i];
            }

            selected.value = EditorGUILayout.MaskField(label, selected.value, layerNames);

            return selected;
        }


        public static T[] GetAllInstances<T>() where T : ScriptableObject
        {
            string[] guids = AssetDatabase.FindAssets("t:" + typeof(T).Name);
            // Debug.LogError("GetAllInstances: typeof(T): " + typeof(T)+", name: "+ typeof(T).Name+" length: "+guids.Length);
            T[] a = new T[guids.Length];
            for (int i = 0; i < guids.Length; i++)
            {
                string path = AssetDatabase.GUIDToAssetPath(guids[i]);
                a[i] = AssetDatabase.LoadAssetAtPath<T>(path);
            }

            return a;

        }

        public static T GetFirstInstance<T>() where T : ScriptableObject
        {
            //Debug.LogWarning("typeof(T).name: " + typeof(T).Name);
            string[] assets = AssetDatabase.FindAssets("t:" + typeof(T).Name);
            T a;
            string guid = "";
            if (assets.Length > 0)
            {
                guid = AssetDatabase.FindAssets("t:" + typeof(T).Name)[0];
            }

            string path = AssetDatabase.GUIDToAssetPath(guid);
            a = AssetDatabase.LoadAssetAtPath<T>(path);

            return a;

        }

        public static class EditorColorsCustomizer
        {

            public static Color GetColor(ColorPurpose _purpose, ref Color[] _colorsSet)
            {

                int colorPurposeInt = (int)_purpose;
                if (_colorsSet != null && _colorsSet.Length > colorPurposeInt)
                {

                    return _colorsSet[colorPurposeInt];
                }
                return Color.white;
            }

        }


        public static string[] GetAllScenes()
        {
            var temp = new List<string>();
            foreach (EditorBuildSettingsScene S in EditorBuildSettings.scenes)
            {
                if (S.enabled)
                {
                    string name = S.path.Substring(S.path.LastIndexOf('/') + 1);
                    name = name.Substring(0, name.Length - 6);  //".unity" cut
                    temp.Add(name);
                }
            }
            return temp.ToArray();
        }


#endif
    }


    public static class EditorList
    {
#if UNITY_EDITOR
        public static void Show(SerializedProperty list, EditorListOption options = EditorListOption.Default)
        {

            bool
                showListLabel = (options & EditorListOption.ListLabel) != 0,
                showListSize = (options & EditorListOption.ListSize) != 0;

            if (showListLabel)
            {
                EditorGUILayout.PropertyField(list);
                EditorGUI.indentLevel += 1;
            }


            if (!showListLabel || list.isExpanded)
            {
                if (showListSize)
                {

                    EditorGUILayout.PropertyField(list.FindPropertyRelative("Array.size"));

                }
                ShowElements(list, options);


            }

            if (showListLabel)
            {
                EditorGUI.indentLevel -= 1;
            }

        }



        private static void ShowElements(SerializedProperty list, EditorListOption options)
        {
            bool showElementLabels = (options & EditorListOption.ElementLabels) != 0;

            for (int i = 0; i < list.arraySize; i++)
            {
                if (showElementLabels)
                {
                    EditorGUILayout.PropertyField(list.GetArrayElementAtIndex(i));
                }
                else
                {
                    EditorGUILayout.PropertyField(list.GetArrayElementAtIndex(i), GUIContent.none);
                }
            }
        }
#endif

    }
}