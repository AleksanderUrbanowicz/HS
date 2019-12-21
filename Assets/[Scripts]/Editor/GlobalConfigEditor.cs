using Characters;
using ScriptableData;
using Managers;
using System;
using UnityEditor;
using UnityEngine;
using static EditorTools.EditorStaticTools;
using Objects;
using Definitions;

namespace EditorTools
{
    [CustomEditor(typeof(GlobalConfig))]
    public class GlobalConfigEditor : Editor
    {


        private SerializedProperty colorsSetProperty;
        private SerializedProperty guestTypesProperty;
        //private SerializedProperty employeeTypesProperty;
        private SerializedProperty characterDatasProperty;
       // private SerializedProperty employeeDatasProperty;
        private SerializedProperty guestDatasProperty;
        private SerializedProperty employeeColorProperty;
        private SerializedProperty guestColorProperty;
        private SerializedProperty defaultColorProperty;
        private SerializedProperty buildObjectColorProperty;
        private SerializedProperty definitionsTabOpenProperty;
        private SerializedProperty charactersTabOpenProperty;
        private SerializedProperty objectsTabOpenProperty;
        private SerializedProperty initTabOpenProperty;
        private SerializedProperty colorsCustomizerTabOpenProperty;
        private SerializedProperty allSelectorParametersProperty;
        private SerializedProperty selectorParametersProperty;
        private SerializedProperty buildObjectsProperty;

        public Color[] defaultColors = new Color[Enum.GetValues(typeof(ColorPurpose)).Length];
        GameObject sceneObject;
        bool displayObject = false;
        //private static CharacterDataBase characterDataBase;
        private static BuildObjectData buildObjectData;
        private static readonly string[] doNotDrawProperties = new string[]
{
    "Key",
    "buildObjectCategories",
    "buildObjectLists",
    "gameEvents",
    "employeeColor",
    "guestColor",
         "colorsSet",
            "characterTypes",
            "employeeTypes",
            "guestTypes",
           "anySelector",

              "guestDatas",
              "employeeDatas",
              "employeeColor",
              "guestColor",
              "characterDatas",
              "characterTabOpen",
              "definitionsTabOpen",
              "colorsCustomizerTabOpen",
              "selectorParameters",
              "allSelectorParameters",
              "defaultColor",
              "buildObjectColor"

};

        private readonly float smallControlHeight = 16;
        private readonly float mediumControlHeight = 20;
        private readonly float largeControlHeight = 24;
        private readonly float hugeControlHeight = 28;
        private readonly float spaceFloat = 5.0f;

        private void OnEnable()
        {

            serializedObject.Update();
           // employeeTypesProperty = serializedObject.FindProperty("employeeTypes");
           // guestTypesProperty = serializedObject.FindProperty("guestTypes");
            characterDatasProperty = serializedObject.FindProperty("characterDatas");
            buildObjectsProperty = serializedObject.FindProperty("buildObjects");
          //  employeeDatasProperty = serializedObject.FindProperty("employeeDatas");
            guestDatasProperty = serializedObject.FindProperty("guestDatas");
          //  employeeColorProperty = serializedObject.FindProperty("employeeColor");
            guestColorProperty = serializedObject.FindProperty("guestColor");
            buildObjectColorProperty = serializedObject.FindProperty("buildObjectColor");
            defaultColorProperty = serializedObject.FindProperty("defaultColor");
            charactersTabOpenProperty = serializedObject.FindProperty("characterTabOpen");
            objectsTabOpenProperty = serializedObject.FindProperty("objectsTabOpen");
            colorsCustomizerTabOpenProperty = serializedObject.FindProperty("colorsCustomizerTabOpen");
            definitionsTabOpenProperty = serializedObject.FindProperty("definitionsTabOpen");
            initTabOpenProperty = serializedObject.FindProperty("initTabOpen");

            selectorParametersProperty = serializedObject.FindProperty("selectorParameters");
            allSelectorParametersProperty = serializedObject.FindProperty("allSelectorParameters");

            colorsSetProperty = serializedObject.FindProperty("colorsSet");

            if (colorsSetProperty != null)
            {
                for (int i = 0; i < Enum.GetValues(typeof(ColorPurpose)).Length; i++)

                {
                    if (colorsSetProperty.arraySize > i)
                    {
                        Color color = colorsSetProperty.GetArrayElementAtIndex(i).colorValue;
                        defaultColors[i] = color;
                    }
                }
            }
        }
        public override void OnInspectorGUI()
        {

            GUI.color = EditorColorsCustomizer.GetColor(ColorPurpose.NegateColor, ref defaultColors);
            GUI.backgroundColor = EditorColorsCustomizer.GetColor(ColorPurpose.NegateColor, ref defaultColors);



            DrawTab(initTabOpenProperty, "Initialization");

            GUI.color = EditorColorsCustomizer.GetColor(ColorPurpose.MainColor, ref defaultColors);
            GUI.backgroundColor = EditorColorsCustomizer.GetColor(ColorPurpose.BackgroundColorLight, ref defaultColors);
            DrawInitContent();


            DrawTab(definitionsTabOpenProperty, "Definitions");
            DrawDefinitionsContent();
            DrawTab(charactersTabOpenProperty, "Characters");
            DrawCharacterContent();
            DrawTab(colorsCustomizerTabOpenProperty, "Colors");
            DrawCustomizerContent();

            DrawTab(objectsTabOpenProperty, "Objects");
            DrawObjectsContent();


            GUI.color = EditorColorsCustomizer.GetColor(ColorPurpose.MainColor, ref defaultColors);
            GUI.backgroundColor = EditorColorsCustomizer.GetColor(ColorPurpose.BackgroundColorLight, ref defaultColors);
            DrawPropertiesExcluding(serializedObject, doNotDrawProperties);
            serializedObject.ApplyModifiedProperties();
        }

        /////////////////////////////////////Draw//////////////////////////////////////////////
        public void DrawTab(SerializedProperty _TabOpenProperty, string label)
        {
            string tabText;
            if (_TabOpenProperty.boolValue)
            {
                GUI.color = EditorColorsCustomizer.GetColor(ColorPurpose.WarningColor, ref defaultColors);

                tabText = " Close ";
            }
            else
            {
                GUI.color = EditorColorsCustomizer.GetColor(ColorPurpose.ConfirmColor, ref defaultColors);

                tabText = " Open ";
            }

            EditorGUILayout.BeginHorizontal();

            _TabOpenProperty.boolValue = GUILayout.Toggle(_TabOpenProperty.boolValue,
                tabText + label, "button", GUILayout.ExpandWidth(true),
                GUILayout.Height(hugeControlHeight));
            GUI.color = EditorColorsCustomizer.GetColor(ColorPurpose.MainColor, ref defaultColors);

            if (GUILayout.Button("?", GUILayout.Height(hugeControlHeight), GUILayout.Width(hugeControlHeight)))
            {
                var activatorRect = GUILayoutUtility.GetLastRect();
                EditorGUILayout.HelpBox(
                                    "Help text",
                                    MessageType.Info, true);


            }

            EditorGUILayout.EndHorizontal();


        }

        public void DrawInitContent()
        {
            EditorGUILayout.BeginHorizontal();
            if (initTabOpenProperty.boolValue)
            {

                EditorGUILayout.LabelField("DrawInitContent");
                bool b = true;
                for (int i = 0; i < selectorParametersProperty.arraySize; i++)
                {

                    SerializedProperty parameters = selectorParametersProperty.GetArrayElementAtIndex(i).FindPropertyRelative("parameters");
                    if (parameters == null || parameters.arraySize == 0)
                    {

                        b = false;
                        break;
                    }
                    else
                    {
                        for (int j = 0; j < parameters.arraySize; j++)
                        {
                            string id = parameters.GetArrayElementAtIndex(j).stringValue;
                            if (string.IsNullOrEmpty(id))
                            {
                                b = false;
                                break;

                            }
                        }

                    }
                }
                if (b)
                {
                    if (GUILayout.Button("Create Config"))
                    {

                        ScriptableObject.CreateInstance<GameSettings>();
                    }
                    else
                    {
                        if (GUILayout.Button("Fill parameters !"))
                        {


                        }

                    }

                }


                if (GUILayout.Button("Refresh"))
                {
                    AssetDatabase.Refresh();

                }
            }
            EditorGUILayout.EndHorizontal();
        }

        public void DrawDefinitionsContent()
        {
            EditorGUILayout.BeginVertical();
            if (definitionsTabOpenProperty.boolValue)
            {

                EditorGUILayout.PropertyField(allSelectorParametersProperty, true);
                EditorGUILayout.PropertyField(selectorParametersProperty, true);

              //  EditorGUILayout.PropertyField(employeeTypesProperty, true);
              //  EditorGUILayout.PropertyField(guestTypesProperty, true);


            }
            EditorGUILayout.EndVertical();
        }
        public void DrawCharacterContent()
        {
            EditorGUILayout.BeginVertical();
            if (charactersTabOpenProperty.boolValue)
            {
                //DrawCharacterCreator();



            }
            EditorGUILayout.EndVertical();
        }
        public void DrawCustomizerContent()
        {
            if (colorsCustomizerTabOpenProperty.boolValue)
            {
                for (int i = 0; i < colorsSetProperty.arraySize; i++)
                {
                    EditorGUILayout.BeginHorizontal();

                    GUI.backgroundColor = colorsSetProperty.GetArrayElementAtIndex(i).colorValue;
                    EditorGUILayout.LabelField((ColorPurpose)i + " :", GUILayout.Height(smallControlHeight));
                    colorsSetProperty.GetArrayElementAtIndex(i).colorValue =
                        EditorGUILayout.ColorField(colorsSetProperty.GetArrayElementAtIndex(i).colorValue);

                    defaultColors[i] = colorsSetProperty.GetArrayElementAtIndex(i).colorValue;
                    EditorGUILayout.EndHorizontal();
                }


                EditorGUILayout.BeginHorizontal();

                GUI.backgroundColor = guestColorProperty.colorValue;
                EditorGUILayout.LabelField(" Guest:", GUILayout.Height(smallControlHeight));
                guestColorProperty.colorValue =
                    EditorGUILayout.ColorField(guestColorProperty.colorValue);

                EditorGUILayout.EndHorizontal();
                EditorGUILayout.BeginHorizontal();

                GUI.backgroundColor = employeeColorProperty.colorValue;
                EditorGUILayout.LabelField(" Employee:", GUILayout.Height(smallControlHeight));
                employeeColorProperty.colorValue =
                    EditorGUILayout.ColorField(employeeColorProperty.colorValue);

                EditorGUILayout.EndHorizontal();
                EditorGUILayout.BeginHorizontal();

                GUI.backgroundColor = buildObjectColorProperty.colorValue;
                EditorGUILayout.LabelField(" Object:", GUILayout.Height(smallControlHeight));
                buildObjectColorProperty.colorValue =
                    EditorGUILayout.ColorField(buildObjectColorProperty.colorValue);

                EditorGUILayout.EndHorizontal();
                EditorGUILayout.BeginHorizontal();

                GUI.backgroundColor = defaultColorProperty.colorValue;
                EditorGUILayout.LabelField(" Default:", GUILayout.Height(smallControlHeight));
                defaultColorProperty.colorValue =
                    EditorGUILayout.ColorField(defaultColorProperty.colorValue);
                EditorGUILayout.EndHorizontal();
                GUI.backgroundColor =
                    EditorColorsCustomizer.GetColor(ColorPurpose.BackgroundColorLight, ref defaultColors);


            }


        }
        /*

        public void DrawCharactersList()
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.BeginVertical(GUI.skin.GetStyle("HelpBox"), GUILayout.Width(Screen.width / 4));
           // DrawEmployeesList();
           // DrawGuestsList();
            DrawcharacterButtons();
            EditorGUILayout.EndVertical();
           // DrawCharacterDisplay(characterDataBase);
            EditorGUILayout.EndHorizontal();
        }
        
        public void DrawCharacterData(CharacterDataBase characterData)
        {
            characterData.prefab = (GameObject)EditorGUILayout.ObjectField(characterData.prefab, typeof(GameObject), false, GUILayout.Height(smallControlHeight));

            characterData.id = EditorGUILayout.TextField(new GUIContent("Id: "), characterData.id, GUILayout.Height(smallControlHeight));

            characterData.displayName = EditorGUILayout.TextField(new GUIContent("Name: "), characterData.displayName, GUILayout.Height(smallControlHeight));

        }

        public void DrawcharacterButtons()
        {
            EditorGUILayout.BeginHorizontal();
            GUI.backgroundColor = EditorColorsCustomizer.GetColor(ColorPurpose.ConfirmColor, ref defaultColors);

            if (GUILayout.Button("Add"))
            {

                Debug.LogWarning("Add");
            }
            GUI.backgroundColor = EditorColorsCustomizer.GetColor(ColorPurpose.NegateColor, ref defaultColors);

            if (GUILayout.Button("Remove selected"))
            {

                Debug.LogWarning("Remove selected");


            }
            GUI.backgroundColor = EditorColorsCustomizer.GetColor(ColorPurpose.MainColor, ref defaultColors);
            EditorGUILayout.EndHorizontal();


        }

        public void DrawGuestData(CharacterDataBase characterData)
        {
            
            if (characterData is GuestData)
            {

                GuestData guestData = (characterData as GuestData);
                EditorGUILayout.TextField(new GUIContent("Type: "), guestData.guestTypeData.id, GUILayout.Height(smallControlHeight));


                guestData.generousity = EditorGUILayout.FloatField(new GUIContent("Generosity: "), guestData.generousity, GUILayout.Height(smallControlHeight));
                guestData.politeness = EditorGUILayout.FloatField(new GUIContent("Politeness: "), guestData.politeness, GUILayout.Height(smallControlHeight));



                EditorGUILayout.LabelField("Requirements: ");

                foreach (ParameterBase pb in guestData.requirements)
                {
                    EditorGUILayout.BeginHorizontal(GUI.skin.GetStyle("HelpBox"), GUILayout.ExpandWidth(true));

                    pb.id = EditorGUILayout.TextField(pb.id, GUILayout.Height(smallControlHeight));

                    pb.value = EditorGUILayout.FloatField(pb.value, GUILayout.Height(smallControlHeight));
                    EditorGUILayout.EndHorizontal();


                }


                if (GUILayout.Button("Add requirement", GUILayout.Height(hugeControlHeight), GUILayout.Width(Screen.width / 8.0f)))
                {

                    guestData.requirements.Add(new ParameterBase());
                }

            }
           

    }
     

        public void DrawEmployeeData(CharacterDataBase characterData)
        {
            
            if (characterData is EmployeeData)
            {


                EditorGUILayout.TextField(new GUIContent("Type: "), (characterData as EmployeeData).employeeType, GUILayout.Height(smallControlHeight));

                (characterData as EmployeeData).salary = EditorGUILayout.FloatField(new GUIContent("Wage: "), (characterData as EmployeeData).salary, GUILayout.Height(smallControlHeight));

                (characterData as EmployeeData).skill = EditorGUILayout.FloatField(new GUIContent("Skill: "), (characterData as EmployeeData).skill, GUILayout.Height(smallControlHeight));
                (characterData as EmployeeData).speed = EditorGUILayout.FloatField(new GUIContent("Speed: "), (characterData as EmployeeData).speed, GUILayout.Height(smallControlHeight));

            }
            
        }
        public void DrawEmployeesList()
        {
            /*
            GUI.backgroundColor = employeeColorProperty.colorValue;

            EditorGUILayout.BeginVertical(GUI.skin.GetStyle("HelpBox"));

            for (int i = 0; i < employeeDatasProperty.arraySize; i++)
            {
                EmployeeData employeeData = employeeDatasProperty.GetArrayElementAtIndex(i).objectReferenceValue as EmployeeData;

                if (GUILayout.Button(employeeData.displayName, GUILayout.Height(hugeControlHeight), GUILayout.Width(Screen.width / 4.0f)))
                {

                    characterDataBase = employeeData;
                }


            }
            EditorGUILayout.EndVertical();
            GUI.backgroundColor = EditorColorsCustomizer.GetColor(ColorPurpose.BackgroundColorLight, ref defaultColors);
            
        }

        public void DrawGuestsList()
        {
            /*
            GUI.backgroundColor = guestColorProperty.colorValue;
            EditorGUILayout.BeginVertical(GUI.skin.GetStyle("HelpBox"));

            for (int i = 0; i < guestDatasProperty.arraySize; i++)
            {
                GuestData guestData = guestDatasProperty.GetArrayElementAtIndex(i).objectReferenceValue as GuestData;

                if (GUILayout.Button(guestData.displayName, GUILayout.Height(hugeControlHeight), GUILayout.Width(Screen.width / 4.0f)))
                {
                    characterDataBase = guestData;

                }

            }
            EditorGUILayout.EndVertical();
            GUI.backgroundColor = EditorColorsCustomizer.GetColor(ColorPurpose.BackgroundColorLight, ref defaultColors);
            
        }

        public void DrawCharacterDisplay(CharacterDataBase characterData)
        {

            if (characterData == null)
            {

                return;
            }
            EditorGUILayout.BeginVertical(GUI.skin.GetStyle("HelpBox"), GUILayout.ExpandWidth(true));
            DrawCharacterData(characterData);
            DrawEmployeeData(characterData);
            DrawGuestData(characterData);

            EditorGUILayout.EndVertical();
        }

        private void InitCharacterData()
        {
            //characterDataBase = (CharacterDataBase)CreateInstance(typeof(CharacterDataBase));
        }

        public void DrawCharacterCreator()
        {
            DrawCharactersList();

            GUIStyle myStyle = GUI.skin.GetStyle("HelpBox");

            GUILayout.BeginVertical(myStyle);
            GUILayout.Label("Create New");
            sceneObject = (GameObject)EditorGUILayout.ObjectField(label: "SceneGo:", sceneObject, typeof(GameObject), true);

            if (sceneObject != null)
            {
                if (!displayObject)
                {
                    displayObject = !displayObject;
                }
               // if (characterDataBase == null)
              //  {
              //      InitCharacterData();
              //  }

            }
            GUILayout.EndVertical();

        }
        */
        ////////////////////////Objects////////////////////////
        /// <summary>
        /// 
        /// 
        /// </summary>

        private void InitObjectData()
        {
            buildObjectData = (BuildObjectData)CreateInstance(typeof(BuildObjectData));
        }

        public void DrawObjectsList()
        {
            EditorGUILayout.BeginHorizontal(GUI.skin.GetStyle("HelpBox"), GUILayout.Width(Screen.width / 3));
            GUI.backgroundColor = buildObjectColorProperty.colorValue;

            EditorGUILayout.BeginVertical(GUI.skin.GetStyle("HelpBox"));

            for (int i = 0; i < buildObjectsProperty.arraySize; i++)
            {
                BuildObjectData objectData = buildObjectsProperty.GetArrayElementAtIndex(i).objectReferenceValue as BuildObjectData;

                if (GUILayout.Button(objectData.id, GUILayout.Height(hugeControlHeight), GUILayout.Width(Screen.width / 3.0f)))
                {

                    buildObjectData = objectData;
                }


            }
            GUI.backgroundColor = EditorColorsCustomizer.GetColor(ColorPurpose.BackgroundColorLight, ref defaultColors);
            EditorGUILayout.EndVertical();
            EditorGUILayout.EndHorizontal();

        }

        public void DrawObjectsContent()
        {
            if (objectsTabOpenProperty.boolValue)

            {
                if (Selection.activeGameObject)
                {
                    DrawObjectCreator();

                }
                else
                {
                    DrawObjectsList();
                }

            }
        }

        public void DrawObjectData()
        {

        }

        public void DrawSelectedGameObject()
        {

        }

        public void DrawObjectCreator()
        {
            GUIStyle myStyle = GUI.skin.GetStyle("HelpBox");



            EditorGUILayout.BeginVertical(myStyle, GUILayout.Width(Screen.width / 3));
            for (int i = 0; i < Selection.objects.Length; i++)
            {

                GUILayout.Button(Selection.objects[i].name, GUILayout.Height(hugeControlHeight), GUILayout.Width(Screen.width / 3.0f));

            }

            if (Selection.objects.Length == 1)
            {


            }

            EditorGUILayout.EndVertical();


            GUILayout.BeginVertical(myStyle);
            GUILayout.Label("Create New");
            sceneObject = (GameObject)EditorGUILayout.ObjectField(label: "SceneGo:", sceneObject, typeof(GameObject), true);

            if (sceneObject != null)
            {
                if (!displayObject)
                {
                    displayObject = !displayObject;
                }
              //  if (characterDataBase == null)
              //  {
               //     InitObjectData();
              //  }

            }
            GUILayout.EndVertical();

        }

    }



}


