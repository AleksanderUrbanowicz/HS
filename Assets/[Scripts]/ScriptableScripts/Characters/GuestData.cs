using EditorTools;
using System.Collections.Generic;
using UnityEngine;

namespace Characters
{
    [CreateAssetMenu(fileName = "GuestData", menuName = "Characters/Guest Data")]
    public class GuestData : CharacterDataBase
    {
        public GuestTypeData guestTypeData;
        [RangeAttribute(0.0f, 100.0f)]
        public float generousity;
        [RangeAttribute(0.0f, 100.0f)]
        public float politeness;


        //[ConfigSelector(paramsSetKey = StringDefines.GuestParameterSelectorKey)]

        //additional requirements, besides requirements based on GuestType
        //move to  guestTypeData.dynamicGuestTypeModifiers ?
        public List<ParameterBase> requirements = new List<ParameterBase>();

        public GuestData()
        {
            characterType = "Guest";
        }

        List<ParameterBase> GetAccumulatedDynamicParameters()
        {
            List<ParameterBase> accumulatedParams = base.dynamicParameters;
            foreach (ParameterBase par in guestTypeData.dynamicGuestTypeModifiers)
            {
                if (accumulatedParams.Contains(par))
                {
                    accumulatedParams[accumulatedParams.IndexOf(par)].value += par.value;
                }
                else
                {
                    accumulatedParams.Add(par);

                }

            }
            return accumulatedParams;
        }

        List<ParameterBase> GetAccumulatedStaticParameters()
        {

            List<ParameterBase> accumulatedParams = base.staticParameters;
            foreach (ParameterBase par in guestTypeData.staticGuestTypeModifiers)
            {
                if (accumulatedParams.Contains(par))
                {
                    accumulatedParams[accumulatedParams.IndexOf(par)].value += par.value;
                }
                else
                {
                    accumulatedParams.Add(par);

                }

            }
            return accumulatedParams;
        }

    }
}