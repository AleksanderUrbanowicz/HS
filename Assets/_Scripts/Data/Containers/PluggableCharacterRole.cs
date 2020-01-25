using BaseLibrary.StateMachine;
using UnityEngine;
namespace Data
{
    [CreateAssetMenu(fileName = "CharacterRole_", menuName = "Characters/Character Role")]

    public class PluggableCharacterRole : ScriptableObject, IPluggableParameters
    {
        public string id, displayName;
        public PluggableParams characterBaseParameters;
        public PluggableParamsData characterTypeParams;

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

            AddBaseActives();

            AddTypeActives();

            (this as IPluggableParameters).AddIndividualParameters();



            return accumulatedParams;
        }




        private void AddBaseActives()
        {
            if (characterBaseParameters != null)
            {
                foreach (ParameterBase par in characterBaseParameters.parameters)
                {
                    int index = accumulatedParams.GetIndexOfActive(par.id);
                    if (index != -1)

                    // if (accumulatedParams.staticBaseParameters.Contains(par))
                    {
                        accumulatedParams.parameters[index].value += par.value;
                    }
                    else
                    {
                        accumulatedParams.parameters.Add(new ParameterBase(par));

                    }

                }
            }
        }





        void IPluggableParameters.AddIndividualParameters()
        {


            foreach (ParameterBase par in individualRoleParams.parameters)
            {
                int index = accumulatedParams.GetIndexOfActive(par.id);
                if (index != -1)

                // if (accumulatedParams.staticBaseParameters.Contains(par))
                {
                    accumulatedParams.parameters[index].value += par.value;
                }
                else
                {
                    accumulatedParams.parameters.Add(new ParameterBase(par));

                }

            }
        }




        private void AddTypeActives()
        {
            if (characterTypeParams != null)
            {
                foreach (ParameterBase par in characterTypeParams.activeParameters)
                {
                    int index = accumulatedParams.GetIndexOfActive(par.id);
                    if (index != -1)

                    // if (accumulatedParams.staticBaseParameters.Contains(par))
                    {
                        accumulatedParams.parameters[index].value += par.value;
                    }
                    else
                    {
                        accumulatedParams.parameters.Add(new ParameterBase(par));

                    }

                }
            }

        }




    }
}
