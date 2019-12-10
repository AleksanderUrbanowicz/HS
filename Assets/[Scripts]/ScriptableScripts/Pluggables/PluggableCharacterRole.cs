using EditorTools;
using System.Collections;
using System.Collections.Generic;
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

        public  PluggableParams AccumulatedParams
        {
            get { return (this as IPluggableParameters).GetAccumulatedParameters(); }
           

        }
        void OnEnable()
        {
            Debug.LogError("CharacterRoleOnEnable");
            accumulatedParams = (this as IPluggableParameters).GetAccumulatedParameters();
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
                    accumulatedParams.staticParameters[index].value += par.value;
                }
                else
                {
                    accumulatedParams.staticParameters.Add(par);

                }

            }
            foreach (ParameterBase par in characterBaseParameters.dynamicParameters)
            {
                int index = accumulatedParams.GetIndexOfDynamic(par.id);
                if (index != -1)

                // if (accumulatedParams.staticBaseParameters.Contains(par))
                {
                    accumulatedParams.dynamicParameters[index].value += par.value;
                }
                else
                {
                    accumulatedParams.dynamicParameters.Add(par);

                }

            }
        }

        private void AddIndividualParams()
        {

            foreach (ParameterBase par in individualRoleParams.staticParameters)
            {
                int index = accumulatedParams.GetIndexOfStatic(par.id);
               if(index!=-1)
                
                // if (accumulatedParams.staticBaseParameters.Contains(par))
                {
                    accumulatedParams.staticParameters[index].value += par.value;
                }
                else
                {
                    accumulatedParams.staticParameters.Add(par);

                }

            }
            foreach (ParameterBase par in individualRoleParams.dynamicParameters)
            {
                int index = accumulatedParams.GetIndexOfDynamic(par.id);
                if (index != -1)

                // if (accumulatedParams.staticBaseParameters.Contains(par))
                {
                    accumulatedParams.dynamicParameters[index].value += par.value;
                }
                else
                {
                    accumulatedParams.dynamicParameters.Add(par);

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
                    accumulatedParams.staticParameters[index].value += par.value;
                }
                else
                {
                    accumulatedParams.staticParameters.Add(par);

                }

            }
            foreach (ParameterBase par in characterTypeParams.dynamicParameters)
            {
                int index = accumulatedParams.GetIndexOfDynamic(par.id);
                if (index != -1)

                // if (accumulatedParams.staticBaseParameters.Contains(par))
                {
                    accumulatedParams.dynamicParameters[index].value += par.value;
                }
                else
                {
                    accumulatedParams.dynamicParameters.Add(par);

                }

            }

        }
    }
}
