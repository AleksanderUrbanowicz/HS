using EditorTools;
using Interfaces;
using StateMachine;
using UnityEngine;

namespace Characters
{
    [CreateAssetMenu(fileName = "PluggableCharacterRole", menuName = "Characters/Pluggable Character Role")]

    public class PluggableCharacterRole : ScriptableObject, IPluggableParameters
    {
        public string id, displayName;
        public PluggableParamsData characterBaseParameters;
       // public PluggableParamsData[] baseTypeParameters=new PluggableParamsData[2];
         public PluggableParamsData characterTypeParams;
        //public PluggableParams[] individualAccumulatedParameters = new PluggableParams[2];

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
            AddBasePassives();
            AddTypeActives();
            AddTypePassives();
            (this as IPluggableParameters).AddIndividualActives();
            (this as IPluggableParameters).AddIndividualPassives();


            return accumulatedParams;
        }

     
    
     
        private void AddBaseActives()
        {
            if (characterBaseParameters != null)
            {
                foreach (ParameterBase par in characterBaseParameters.activeParameters)
                {
                    int index = accumulatedParams.GetIndexOfActive(par.id);
                    if (index != -1)

                    // if (accumulatedParams.staticBaseParameters.Contains(par))
                    {
                        accumulatedParams.activeParameters[index].value += par.value;
                    }
                    else
                    {
                        accumulatedParams.activeParameters.Add(new ParameterBase(par));

                    }

                }
            }
        }

        private void AddBasePassives()
        {
            if (characterBaseParameters != null)
            {
                foreach (ParameterBase par in characterBaseParameters.passiveParameters)
                {
                    int index = accumulatedParams.GetIndexOfPassive(par.id);
                    if (index != -1)

                    // if (accumulatedParams.staticBaseParameters.Contains(par))
                    {
                        accumulatedParams.passiveParameters[index].value += par.value;
                    }
                    else
                    {
                        accumulatedParams.passiveParameters.Add(new ParameterBase(par));

                    }

                }
            }
        }

         void IPluggableParameters.AddIndividualPassives()
        {

            foreach (ParameterBase par in individualRoleParams.passiveParameters)
            {
                int index = accumulatedParams.GetIndexOfPassive(par.id);
                if (index != -1)

                // if (accumulatedParams.staticBaseParameters.Contains(par))
                {
                    accumulatedParams.passiveParameters[index].value += par.value;
                }
                else
                {
                    accumulatedParams.passiveParameters.Add(new ParameterBase(par));

                }

            }
        
        }

         void IPluggableParameters.AddIndividualActives()
        {

       
            foreach (ParameterBase par in individualRoleParams.activeParameters)
            {
                int index = accumulatedParams.GetIndexOfActive(par.id);
                if (index != -1)

                // if (accumulatedParams.staticBaseParameters.Contains(par))
                {
                    accumulatedParams.activeParameters[index].value += par.value;
                }
                else
                {
                    accumulatedParams.activeParameters.Add(new ParameterBase(par));

                }

            }
        }

        private void AddTypePassives()
        {
            if (characterTypeParams != null)
            {
                foreach (ParameterBase par in characterTypeParams.passiveParameters)
                {
                    int index = accumulatedParams.GetIndexOfPassive(par.id);
                    if (index != -1)

                    // if (accumulatedParams.staticBaseParameters.Contains(par))
                    {
                        accumulatedParams.passiveParameters[index].value += par.value;
                    }
                    else
                    {
                        accumulatedParams.passiveParameters.Add(new ParameterBase(par));

                    }

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
                        accumulatedParams.activeParameters[index].value += par.value;
                    }
                    else
                    {
                        accumulatedParams.activeParameters.Add(new ParameterBase(par));

                    }

                }
            }

        }
    }
}
