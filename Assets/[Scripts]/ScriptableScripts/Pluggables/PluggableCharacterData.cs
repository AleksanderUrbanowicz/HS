using EditorTools;
using UnityEngine;

namespace Characters
{
    [CreateAssetMenu(fileName = "CharacterData", menuName = "Characters/Pluggable Character Data")]

    public class PluggableCharacterData : PluggableCharacterBase, IPluggableParameters
    {
        public PluggableParams accumulatedParams;
        public PluggableParams individualParams;
        public PluggableCharacterRole characterRole;

        PluggableParams IPluggableParameters.GetAccumulatedParameters()
        {
            accumulatedParams = new PluggableParams();
            if (characterRole != null)
            {
                accumulatedParams = characterRole.AccumulatedParams;
                AddIndividualParams();
            }
            return accumulatedParams;


        }

        void OnEnable()
        {
            //  Debug.LogError("CharacterDataOnEnable");
            (this as IPluggableParameters).GetAccumulatedParameters();
        }




        private void AddIndividualParams()
        {

            foreach (ParameterBase par in individualParams.passiveParameters)
            {
                if (accumulatedParams.GetIndexOfStatic(par.id) != -1)
                {
                    accumulatedParams.passiveParameters[accumulatedParams.GetIndexOfStatic(par.id)].value += par.value;
                }
                else
                {
                    accumulatedParams.passiveParameters.Add(new ParameterBase(par.id, par.value));

                }

            }
            foreach (ParameterBase par in individualParams.activeParameters)
            {

                if (accumulatedParams.GetIndexOfDynamic(par.id) != -1)
                {
                    accumulatedParams.activeParameters[accumulatedParams.GetIndexOfDynamic(par.id)].value += par.value;
                }
                else
                {
                    accumulatedParams.activeParameters.Add(new ParameterBase(par.id, par.value));

                }

            }
        }

        public void CreateInstance(GameObject go, Vector3 position)
        {
           // Debug.LogError("CreateInstance,go.name: " + go.name);
            GameObject instance = GameObject.Instantiate(prefab, position, Quaternion.identity, go.transform);
            instance.name = id;
           // Debug.LogError("CreateInstance,instance.name: " + instance.name);
            instance.GetComponent<PluggableCharacterMonoBehaviour>().Init(this);
           // return instance;
        }

    }
}