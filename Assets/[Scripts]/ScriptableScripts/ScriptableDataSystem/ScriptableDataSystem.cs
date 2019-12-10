using UnityEngine;
namespace ScriptableSystems
{
    [CreateAssetMenu(fileName = "DataSystem", menuName = "ScriptableSystems/Data System/System Asset")]

    public class ScriptableDataSystem : ScriptableSystem
    {

        public string playerDataFilename = "/playerData.dat";
        public string objectsDataFilename = "/objectsData.dat";

        public string objectsTag = "Object";
        public string playerPrefsCashKey = "Cash";

        public override void Initialize(GameObject obj)
        {
            //base.Initialize(obj);
            obj.name = id;
            DataSystemMonoBehaviour dataSystemMonoBehaviour = obj.AddComponent<DataSystemMonoBehaviour>();
            if (dataSystemMonoBehaviour != null)
            {

                dataSystemMonoBehaviour.Init(this);
            }

            Debug.Log("override ScriptableDataSystem.Initialize():" + obj.name);


        }


    }

}