using Characters;
using ScriptableSystems;
using UnityEngine;

namespace EditorTools
{
    //[CreateAssetMenu(fileName = "Definitions", menuName = "Settings/Definitions")]
    public class Definitions : ConfigBase
    {
        new public  string Key = "DefinitionsConfig";
        public string[] materialTypes;
       // public ObjectType[] objectTypes;
        
        public BuildObjectData[] buildObjects;
        public BuildObjectCategoryData[] buildObjectCategories;
        public BuildObjectListData[] buildObjectLists;
        public GameEvent[] gameEvents;
        public ScriptableEvent[] scriptableEvents;
        public ThemeUIData[] uiThemes;
        public BuildObjectMaterialSet[] materialSets;

        

        private void OnEnable()
        {
            OnEnableMethod();
        }

        public void OnEnableMethod()
        {
#if UNITY_EDITOR
            buildObjects = EditorStaticTools.GetAllInstances<BuildObjectData>();
            buildObjectCategories = EditorStaticTools.GetAllInstances<BuildObjectCategoryData>();
            buildObjectLists = EditorStaticTools.GetAllInstances<BuildObjectListData>();

            gameEvents = EditorStaticTools.GetAllInstances<GameEvent>();
            scriptableEvents = EditorStaticTools.GetAllInstances<ScriptableEvent>();

            uiThemes = EditorStaticTools.GetAllInstances<ThemeUIData>();
            materialSets = EditorStaticTools.GetAllInstances<BuildObjectMaterialSet>();


            

#endif
        }

    }
}
