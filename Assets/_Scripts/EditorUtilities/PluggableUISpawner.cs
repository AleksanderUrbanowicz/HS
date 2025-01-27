﻿using UnityEditor;
using UnityEngine;

namespace EditorUtilities
{
    public class PluggableUISpawner : Editor
    {
        [MenuItem("GameObject/PluggableUI/Button", priority = 0)]
        public static void AddButton()
        {
            Create("ThemeButton");

        }

        [MenuItem("GameObject/PluggableUI/Panel", priority = 0)]

        public static void AddPanel()
        {
            Create("PluggablePanel");

        }

        [MenuItem("GameObject/PluggableUI/Slider", priority = 0)]

        public static void AddSlider()
        {
            Create("ThemeSlider");

        }

        [MenuItem("GameObject/PluggableUI/Labelled Bar", priority = 0)]

        public static void AddLabelledBar()
        {
            Create("ThemeLabelledBar");

        }

        public static GameObject selectedObject;

        private static GameObject Create(string name)
        {
            GameObject res = Resources.Load<GameObject>(name);
            if (res == null)
            {
                // Debug.LogError(name + " does not exist");
                return res;

            }
            GameObject instance = Instantiate(res);

            instance.name = name;
            selectedObject = UnityEditor.Selection.activeObject as GameObject;
            if (selectedObject != null)
            {
                instance.transform.SetParent(selectedObject.transform, false);

            }

            return instance;

        }
    }
}