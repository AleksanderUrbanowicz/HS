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
              
                (this as IPluggableParameters).AddIndividualActives();

            }
            return accumulatedParams;


        }

        void OnEnable()
        {
            (this as IPluggableParameters).GetAccumulatedParameters();
        }


        

        void IPluggableParameters.AddIndividualActives()
        {
            int index;
            foreach (ParameterBase par in individualParams.activeParameters)
            {
                index = accumulatedParams.GetIndexOfActive(par.id);
                if (index != -1)
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