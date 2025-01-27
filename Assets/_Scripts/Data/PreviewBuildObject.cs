﻿using BaseLibrary.Interfaces;
using Managers;
using System;
using UnityEngine;

namespace Data
{
    [Serializable]
    public class PreviewBuildObject : MonoBehaviour, IPreviewObject
    {
        public BuildObjectData buildObjectData;
        private BoxCollider previewCollider;
        private MeshRenderer previewRenderer;
        public float userRotationF;
        //private bool isPreviewObjectVisible;
        public void Init(BuildObjectData _buildObjectData)
        {
            buildObjectData = _buildObjectData;
            //Debug.Log("PreviewBuildObject.Init(ISpawnableBuildObject _spawnableBuildObject)");
            AddPreviewComponents(_buildObjectData);

        }
        private void AddPreviewComponents(BuildObjectData buildObjectData=null)
        {

            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);


            cube.transform.SetParent(GameObjectInstance.transform);

            cube.transform.localScale = new Vector3(buildObjectData.gridSize.x, buildObjectData.gridSize.y, buildObjectData.gridSize.z);
            Vector3 moveVector = new Vector3((buildObjectData.gridSize.x / 2.0f) + buildObjectData.actualSize.x, -(buildObjectData.gridSize.y / 2.0f) + buildObjectData.actualSize.y, (buildObjectData.gridSize.z / 2.0f) + buildObjectData.actualSize.z);
            /*if (buildObjectData.orientationVector == Vector3.forward)
            {
                cube.transform.localPosition = new Vector3(0, 0, -(buildObjectData.gridSize.z / 2.0f) + buildObjectData.actualSize.z) + buildObjectData.offset;


            }
            else if (buildObjectData.orientationVector == Vector3.up)
            {

                cube.transform.localPosition = new Vector3(0, buildObjectData.gridSize.y / 2.0f, 0) + buildObjectData.offset;

            }
            */
            moveVector.x*= buildObjectData.orientationVector.x;
            moveVector.y *= buildObjectData.orientationVector.y;
            moveVector.z *= buildObjectData.orientationVector.z;
            cube.transform.localPosition = moveVector + buildObjectData.offset;

            previewRenderer = cube.gameObject.GetComponent<MeshRenderer>();
            previewRenderer.material = SingletonBuildManager.PreviewData.previewMaterial;
            previewCollider = cube.GetComponent<BoxCollider>();
            previewCollider.isTrigger = true;
            ToggleVisibility(false);

        }
        public void SetPreviewColor(bool? _b = null)
        {
           // Debug.Log("PreviewBuildObject.SetPreviewColor();");

            bool b = _b == null ? CheckAvailability() : (bool)_b;
            SingletonBuildManager.BuildPreviewExecutor.PreviewHelper.IsAvailable = b;
            PreviewRenderer.material.color = b ? SingletonBuildManager.PreviewData.availableColor : SingletonBuildManager.PreviewData.unavailableColor;
        }

        public void ToggleVisibility(bool b)
        {
           // Debug.Log("PreviewBuildObject.ToggleVisibility("+b+");");
            // PreviewRenderer.enabled = b;
          //  isPreviewObjectVisible = b;
        GameObjectInstance.SetActive(b);
        }

        public bool CheckAvailability()
        {

            // collisionCenterDebug = PreviewTransform.position + PreviewObject.PreviewCollider.center;
            Vector3 halfEx = PreviewCollider.bounds.extents * 0.9f;
            Collider[] hitColliders = Physics.OverlapBox(transform.position + PreviewCollider.center, halfEx, PreviewCollider.transform.rotation, SpawnableBuildObject.BuildObjectData.obstacleLayers);
            int i = 0;


            while (i < hitColliders.Length)
            {
                Collider hitCollider = hitColliders[i];

                if (hitCollider.gameObject != gameObject && hitCollider.gameObject.layer != SpawnableBuildObject.BuildObjectData.layersToBuildOn)
                {
                    
                    return false;
                }

                i++;
            }

            return true;

        }
        public MeshRenderer PreviewRenderer { get => previewRenderer; set => previewRenderer = value; }
        public BoxCollider PreviewCollider { get => previewCollider; set => previewCollider = value; }
        public ISpawnableBuildObject SpawnableBuildObject { get => buildObjectData; set => buildObjectData = value as BuildObjectData; }

        public GameObject GameObjectInstance => gameObject;

    }
}