using EditorTools;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Characters {
     [CreateAssetMenu(fileName = "CharacterData", menuName = "Characters/Pluggable Character Data")]

    public class PluggableCharacterData :PluggableCharacterBase, IPluggableParameters
    {
        public PluggableParams accumulatedParams;


        PluggableParams IPluggableParameters.GetAccumulatedParameters()
        {
            if (characterRole != null)
            {
                accumulatedParams = characterRole.AccumulatedParams;
                AddIndividualParams();
            }
            return accumulatedParams;
           

        }

        void OnEnable()
        {
            Debug.LogError("CharacterDataOnEnable");
            accumulatedParams= (this as IPluggableParameters).GetAccumulatedParameters();
        }

        private void AddIndividualParams()
        {

            foreach (ParameterBase par in individualParams.staticParameters)
            {
                if (accumulatedParams.GetIndexOfStatic(par.id) != -1)
                {
                    accumulatedParams.staticParameters[accumulatedParams.GetIndexOfStatic(par.id)].value += par.value;
                }
                else
                {
                    accumulatedParams.staticParameters.Add(par);

                }

            }
            foreach (ParameterBase par in individualParams.dynamicParameters)
            {

                if (accumulatedParams.GetIndexOfDynamic(par.id)!=-1)
                {
                    accumulatedParams.dynamicParameters[accumulatedParams.GetIndexOfDynamic(par.id)].value += par.value;
                }
                else
                {
                    accumulatedParams.dynamicParameters.Add(par);

                }

            }
        }
    }
}