using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace EditorTools
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

                    for (; emptyLayers > 0; emptyLayers--) layers.Add("Layer " + (i - emptyLayers));
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
            for (int i = 0; i < layerNames.Length; i++) layerNames[i] = layers[i];

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
            //Debug.LogWarning("typeof(T): " + typeof(T));
           // Debug.LogWarning("typeof(T).name: " + typeof(T).Name);
            string guid = AssetDatabase.FindAssets("t:" + typeof(T).Name)[0];
            T a;

            string path = AssetDatabase.GUIDToAssetPath(guid);
            a = AssetDatabase.LoadAssetAtPath<T>(path);


            return a;

        }




        public static string[] GetAllScenes()
        {
            var temp = new List<string>();
            foreach (UnityEditor.EditorBuildSettingsScene S in UnityEditor.EditorBuildSettings.scenes)
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

}