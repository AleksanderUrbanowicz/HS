using EditorTools;
using System;
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