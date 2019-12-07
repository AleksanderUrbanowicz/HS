using UnityEngine;

namespace ScriptableSystems
{
    [CreateAssetMenu(fileName = "BuildSystem", menuName = "ScriptableSystems/Build System/System Asset")]
    public class ScriptableBuildSystem : ScriptableSystem

    {


        public string buildObjectLayerString;

        public BuildObjectListData buildObjects;
        public Color availableColor = new Color(0, 1.0f, 0, 0.2f);
        public Color unavailableColor = new Color(1.0f, 0, 0, 0.2f);
        public Material previewMaterial;

        public float raycastMaxDistance = 12.0f;
        public float offset = 1.0f;
        public float gridSize = 1.0f;
        public float previewSnapFactor = 1.0f;


        public ScriptableEvent EventPreviewRaycastHit;
        public ScriptableEvent EventPreviewRaycastMiss;
        public int raycastInterval = 1;
        public int updateInterval = 2;
        public bool logs;

        public override void Initialize(GameObject obj)
        {
            //base.Initialize(obj);
            obj.name = id;
            BuildSystemMonoBehaviour buildSystemMonoBehaviour = obj.AddComponent<BuildSystemMonoBehaviour>();
            if (buildSystemMonoBehaviour != null)
            {

                buildSystemMonoBehaviour.Init(this);
            }

            Debug.Log("override ScriptableBuildSystem.Initialize():" + obj.name);


        }



    }

}