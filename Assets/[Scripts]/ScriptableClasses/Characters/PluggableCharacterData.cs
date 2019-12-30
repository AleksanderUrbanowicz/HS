using EditorTools;
using Interfaces;
using UnityEngine;

namespace Characters
{
    [CreateAssetMenu(fileName = "CharacterData", menuName = "Characters/Pluggable Character Data")]

    public class PluggableCharacterData : PluggableCharacterBase, IPluggableParameters
    {

      

        PluggableParams IPluggableParameters.GetAccumulatedParameters()
        {
            
            if (characterRole != null)
            {
                accumulatedParams = characterRole.AccumulatedParams;
              
                (this as IPluggableParameters).AddIndividualParameters();

            }
            return accumulatedParams;


        }

        void OnEnable()
        {
            (this as IPluggableParameters).GetAccumulatedParameters();
        }


        

        void IPluggableParameters.AddIndividualParameters()
        {
            int index;
            foreach (ParameterBase par in individualParams.parameters)
            {
                index = accumulatedParams.GetIndexOfActive(par.id);
                if (index != -1)
                {
                    accumulatedParams.parameters[index].value += par.value;
                }
                else
                {
                    accumulatedParams.parameters.Add(new ParameterBase(par.id, par.value));

                }

            }
        
        }

      

      
    }
}