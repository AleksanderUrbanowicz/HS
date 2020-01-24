using BaseLibrary.Data;
using Data;
using Managers;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UI
{


    public class BuildManagerUI : MonoBehaviour
    {
        public UIBuildObjectPopulator<BuildObjectData> buildObjectsUIPopulator;
        public RectTransform objectsParent;
        public RectTransform categoriesParent;
        public GameObject UIPrefab;
        public RectTransform ObjectsParent { get { 
                if(objectsParent==null)
                {
                    objectsParent= new GameObject("Objects", typeof(RectTransform)).GetComponent<RectTransform>();
                }
                return objectsParent; } set => objectsParent = value; }
        public RectTransform CategoriesParent { get {
                if (categoriesParent == null)
                {
                    categoriesParent = new GameObject("categoriesParent", typeof(RectTransform)).GetComponent<RectTransform>();
                }
                return categoriesParent; } set => categoriesParent = value; }

        private void Awake()
        {
            
            // buildObjectsUIPopulator.Init(SingletonBuildManager.BuildObjectsHelper.BuildObjectsData.ToList<ISpawnable>(), ObjectsParent, UIPrefab);
        }

        private void Start()
        {
            buildObjectsUIPopulator = new UIBuildObjectPopulator<BuildObjectData>();
            buildObjectsUIPopulator.Init(SingletonBuildManager.BuildObjectsHelper.BuildObjectsData, ObjectsParent, UIPrefab);

            // buildObjectsUIPopulator.Init(SingletonBuildManager.BuildObjectsHelper.BuildObjectsData.ToList<ISpawnable>(), ObjectsParent, UIPrefab);
        }
    }
}