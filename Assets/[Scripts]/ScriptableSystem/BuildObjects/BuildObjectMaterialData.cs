using EditorTools;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableSystems
{
    [Serializable]
    public class BuildObjectMaterialData 
    {
        public Material defaultMaterial;
        public Texture2D dirtyMask, damagedMask;

        [ConfigSelector(paramsSetKey = StringDefines.MaterialSetSelectorKey)]
        public string materialSet;
    }
}