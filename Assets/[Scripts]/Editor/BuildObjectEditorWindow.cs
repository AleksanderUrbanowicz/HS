﻿using Definitions;
using EditorTools;
using Objects;
using StateMachine;
using UnityEditor;
using UnityEngine;

namespace BuildObjects
{

    public class BuildObjectEditorWindow : EditorWindow
    {

        #region Layout

        Texture2D headerTexture;
        Color headerColor = new Color(0.23f, 0, 0.5f, 0.5f);
        Rect headerSection;

        Texture2D mainTexture;
        Color mainColor = new Color(0.83f, 0.5f, 0.5f, 0.9f);
        Color backgroundColor = Color.white;

        Rect mainSection;
        Rect previewGeneratorSection;
        private void OnGUI()
        {
            GUI.backgroundColor = backgroundColor;
            DrawLayouts();
            DrawHeader();
            DrawObjectsGenerator();
            if (displayObject)
            {

                DrawObjectPreview();

            }

        }

        private void DrawLayouts()
        {
            headerSection.x = 0;
            headerSection.y = 0;
            headerSection.width = Screen.width;
            headerSection.height = Screen.height / 3.0f;

            previewGeneratorSection.x = 0;
            previewGeneratorSection.y = Screen.height / 3.0f;
            previewGeneratorSection.width = Screen.width;
            previewGeneratorSection.height = Screen.height / 3.0f;

            mainSection.x = 0;
            mainSection.y = 2 * (Screen.height / 3.0f);
            mainSection.width = Screen.width;
            mainSection.height = Screen.height / 3.0f;
        }

        #endregion Layout

        #region Window
        [MenuItem("Tools/BuildSystem/Object creator")]
        static void OpenWindow()
        {
            BuildObjectEditorWindow window = (BuildObjectEditorWindow)GetWindow(typeof(BuildObjectEditorWindow));
            window.minSize = new Vector2(360, 240);
            window.Show();
        }

        private void OnEnable()
        {

            InitTextures();
            InitData();
        }

        private void InitTextures()
        {
            headerTexture = new Texture2D(1, 1);
            headerTexture.SetPixel(0, 0, headerColor);
            headerTexture.Apply();
            mainTexture = new Texture2D(1, 1);
            mainTexture.SetPixel(0, 0, mainColor);
            mainTexture.Apply();
        }

        private void InitData()
        {
            buildObjectData = (BuildObjectData)CreateInstance(typeof(BuildObjectData));
        }

        #endregion Window

        #region Settings
        string scriptableObjectsPath = "Assets/AutoGeneratedAssets/ScriptableObjects/BuildObjects/";
        string prefabsPath = "Assets/AutoGeneratedAssets/Prefabs/";

        string scriptableObjectSuffix = "_scriptableObject";
        string prefabSuffix = "_prefab";
        LayerMask defaultObstaclesLayer;
        float gridSize = 1.0f;
        float boundsEpsilon = 0.2f;

        #endregion Settings
        public static BuildObjectData BuildObjectInfo { get { return buildObjectData; } }
        GameObject sceneObject;
        bool displayObject = false;
        static BuildObjectData buildObjectData;


        private void DrawHeader()
        {
            GUILayout.BeginArea(headerSection);

            GUILayout.Label("Settings:\nGridSize: " + gridSize + "\nSO path: " + scriptableObjectsPath + "\nSO file suffix: " + scriptableObjectSuffix + "\nBounds epsilon: " + boundsEpsilon + "\nprebfab path: " + prefabsPath + "\nprebfab suffix: " + prefabSuffix + "\n");
            defaultObstaclesLayer = EditorStaticTools.LayerMaskField("Default obstacles mask", defaultObstaclesLayer);
            GUILayout.EndArea();
        }

        private void DrawObjectsGenerator()
        {
            GUILayout.BeginArea(previewGeneratorSection);
            GUILayout.Label("Drag scene object");
            sceneObject = (GameObject)EditorGUILayout.ObjectField(label: "SceneGo:", sceneObject, typeof(GameObject), true);

            if (sceneObject != null)
            {
                if (!displayObject)
                {
                    displayObject = !displayObject;
                }
                if (buildObjectData == null)
                {
                    InitData();
                }
                if (GUILayout.Button("Reset"))
                {
                    Reset();

                    return;
                }

                if (buildObjectData.actualSize == Vector3.zero)
                {
                    Vector3 size = CalculateLocalBounds(sceneObject).size;

                    buildObjectData.actualSize = size;
                    buildObjectData.gridSize = CalculateGridSize(size);
                    buildObjectData.obstacleLayers = defaultObstaclesLayer;
                    buildObjectData.id = sceneObject.name + Random.Range(0, 9);
                }



                GUILayout.Label("Size \nX: " + buildObjectData.actualSize.x + "   Y: " + buildObjectData.actualSize.y + "   Z: " + buildObjectData.actualSize.z);
                GUILayout.Label("Grid size\nX: " + buildObjectData.gridSize.x + "   Y: " + buildObjectData.gridSize.y + "   Z: " + buildObjectData.gridSize.z);


                GUI.backgroundColor = Color.gray;


                if (GUILayout.Button("Calculate Size"))
                {
                    Vector3 size = CalculateLocalBounds(sceneObject).size;

                    buildObjectData.actualSize = size;
                    buildObjectData.gridSize = CalculateGridSize(size);
                    buildObjectData.obstacleLayers = defaultObstaclesLayer;
                }
                GUI.backgroundColor = Color.red;



                if (buildObjectData.gridSize != Vector3.zero)
                {
                    GUI.backgroundColor = Color.green;

                }



                if (GUILayout.Button("Create Prefab"))
                {
                    sceneObject.AddComponent<PluggableObjectMonoBehaviour>();
                    sceneObject.AddComponent<BuildObjectStateControllerMB>();
                    string correctPath = "Assets/" + "AutoGeneratedAssets/Prefabs/" + buildObjectData.id + prefabSuffix + ".prefab";
                    buildObjectData.objectPrefab = PrefabUtility.SaveAsPrefabAsset(sceneObject, correctPath);

                }
                GUI.backgroundColor = Color.red;
                if (buildObjectData.objectPrefab != null)
                {
                    GUI.backgroundColor = Color.green;

                }


                if (GUILayout.Button("Create ScriptableObject"))
                {
                    AssetDatabase.CreateAsset(buildObjectData, scriptableObjectsPath + buildObjectData.id + scriptableObjectSuffix + ".asset");

                }

                GUI.backgroundColor = Color.red;
                if (GUILayout.Button("Delete Object"))
                {


                    AssetDatabase.DeleteAsset(scriptableObjectsPath + buildObjectData.id + scriptableObjectSuffix + ".asset");
                    Reset();
                }



                GUI.backgroundColor = backgroundColor;

            }

            GUILayout.EndArea();
        }

        private void DrawObjectPreview()
        {
            GUILayout.BeginArea(mainSection);
            GUILayout.Label("Display new object:");
            buildObjectData.objectOrientation = (ObjectOrientation)EditorGUILayout.EnumPopup("Orientation: ", buildObjectData.objectOrientation);
            buildObjectData.id = EditorGUILayout.TextField("id", buildObjectData.id);
            buildObjectData.gridSize = EditorGUILayout.Vector3Field(label: "Grid size:", buildObjectData.gridSize);
            buildObjectData.actualSize = EditorGUILayout.Vector3Field(label: "Actual size:", buildObjectData.actualSize);
            buildObjectData.offset = EditorGUILayout.Vector3Field(label: "offset:", buildObjectData.offset);

            buildObjectData.cost = EditorGUILayout.IntField(label: "Cost:", buildObjectData.cost);
            buildObjectData.objectPrefab = (GameObject)EditorGUILayout.ObjectField(label: "Prefab:", buildObjectData.objectPrefab, typeof(GameObject), true);
            buildObjectData.obstacleLayers = EditorStaticTools.LayerMaskField("Obstacles Mask: ", buildObjectData.obstacleLayers);
            GUILayout.EndArea();
        }


        //Utillities
        private Bounds CalculateLocalBounds(GameObject _sceneObject)
        {
            if (_sceneObject == null)
            {
                return new Bounds(Vector3.zero, Vector3.zero);

            }
            Quaternion currentRotation = _sceneObject.transform.rotation;
            _sceneObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);

            Bounds bounds = new Bounds(_sceneObject.transform.position, Vector3.zero);

            Renderer[] array = _sceneObject.GetComponentsInChildren<Renderer>();
            for (int i = 0; i < array.Length; i++)
            {
                Renderer renderer = array[i];
                bounds.Encapsulate(renderer.bounds);
            }

            Vector3 localCenter = bounds.center - _sceneObject.transform.position;
            bounds.center = localCenter;
            Debug.Log("The local bounds of this model is " + bounds);

            _sceneObject.transform.rotation = currentRotation;
            return bounds;
        }

        private Vector3 CalculateGridSize(Vector3 _size)
        {
            bool b = _size == null;
            b = b || _size == Vector3.zero;
            // if (_size == null || _size == Vector3.zero)
            if (b)
            {
                Debug.LogError("BuildObjectEditorWindow.CalculateGridSize(Vector3) Vector3 is null or zero, returning Vector3.zero");
                return Vector3.zero;

            }

            Vector3 floatGridSize = Vector3.zero;
            while (floatGridSize.x < _size.x + boundsEpsilon)
            {
                floatGridSize.x += gridSize;

            }

            while (floatGridSize.y < _size.y + boundsEpsilon)
            {
                floatGridSize.y += gridSize;

            }


            while (floatGridSize.z < _size.z + boundsEpsilon)
            {
                floatGridSize.z += gridSize;

            }



            return floatGridSize;
        }


        private void Reset()
        {
            sceneObject = null;
            displayObject = false;

            InitData();
        }

    }
}
//}