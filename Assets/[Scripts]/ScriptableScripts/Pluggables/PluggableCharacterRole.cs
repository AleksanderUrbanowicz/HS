using EditorTools;
using UnityEngine;

namespace Characters
{
    [CreateAssetMenu(fileName = "PluggableCharacterRole", menuName = "Characters/Pluggable Character Role")]

    public class PluggableCharacterRole : ScriptableObject, IPluggableParameters
    {
        public string id, displayName;
        public PluggableParamsData characterBaseParameters;

        public PluggableParamsData characterTypeParams;//Employee, guest  

        public PluggableParams individualRoleParams;

        public PluggableParams accumulatedParams;
        public State startState;
        public PluggableParams AccumulatedParams
        {
            get { return (this as IPluggableParameters).GetAccumulatedParameters(); }


        }
        void OnEnable()
        {
            // Debug.LogError("CharacterRoleOnEnable");
            (this as IPluggableParameters).GetAccumulatedParameters();
        }
        PluggableParams IPluggableParameters.GetAccumulatedParameters()
        {

            accumulatedParams = new PluggableParams();
            AddBaseParams();
            AddTypeParams();
            AddIndividualParams();
            return accumulatedParams;
        }

        private void AddBaseParams()
        {
            foreach (ParameterBase par in characterBaseParameters.staticParameters)
            {
                int index = accumulatedParams.GetIndexOfStatic(par.id);
                if (index != -1)

                // if (accumulatedParams.staticBaseParameters.Contains(par))
                {
                    accumulatedParams.passiveParameters[index].value += par.value;
                }
                else
                {
                    accumulatedParams.passiveParameters.Add(new ParameterBase(par.id, par.value));

                }

            }
            foreach (ParameterBase par in characterBaseParameters.dynamicParameters)
            {
                int index = accumulatedParams.GetIndexOfDynamic(par.id);
                if (index != -1)

                // if (accumulatedParams.staticBaseParameters.Contains(par))
                {
                    accumulatedParams.activeParameters[index].value += par.value;
                }
                else
                {
                    accumulatedParams.activeParameters.Add(new ParameterBase(par.id, par.value));

                }

            }
        }

        private void AddIndividualParams()
        {

            foreach (ParameterBase par in individualRoleParams.passiveParameters)
            {
                int index = accumulatedParams.GetIndexOfStatic(par.id);
                if (index != -1)

                // if (accumulatedParams.staticBaseParameters.Contains(par))
                {
                    accumulatedParams.passiveParameters[index].value += par.value;
                }
                else
                {
                    accumulatedParams.passiveParameters.Add(new ParameterBase(par.id, par.value));

                }

            }
            foreach (ParameterBase par in individualRoleParams.activeParameters)
            {
                int index = accumulatedParams.GetIndexOfDynamic(par.id);
                if (index != -1)

                // if (accumulatedParams.staticBaseParameters.Contains(par))
                {
                    accumulatedParams.activeParameters[index].value += par.value;
                }
                else
                {
                    accumulatedParams.activeParameters.Add(new ParameterBase(par.id, par.value));

                }

            }
        }

        private void AddTypeParams()
        {
            foreach (ParameterBase par in characterTypeParams.staticParameters)
            {
                int index = accumulatedParams.GetIndexOfStatic(par.id);
                if (index != -1)

                // if (accumulatedParams.staticBaseParameters.Contains(par))
                {
                    accumulatedParams.passiveParameters[index].value += par.value;
                }
                else
                {
                    accumulatedParams.passiveParameters.Add(new ParameterBase(par.id, par.value));

                }

            }
            foreach (ParameterBase par in characterTypeParams.dynamicParameters)
            {
                int index = accumulatedParams.GetIndexOfDynamic(par.id);
                if (index != -1)

                // if (accumulatedParams.staticBaseParameters.Contains(par))
                {
                    accumulatedParams.activeParameters[index].value += par.value;
                }
                else
                {
                    accumulatedParams.activeParameters.Add(new ParameterBase(par.id, par.value));

                }

            }

        }
    }
}
