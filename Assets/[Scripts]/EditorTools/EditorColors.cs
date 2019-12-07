using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EditorTools
{


    [Serializable]
    public class EditorColors
    {
       


    }
    
    public static class EditorColorsCustomizer
    {
 
        public static Color GetColor(ColorPurpose _purpose,ref Color[] _colorsSet)
        {
            
           int colorPurposeInt = (int) (_purpose);
            if(_colorsSet!=null && _colorsSet.Length>colorPurposeInt)
            {

                return _colorsSet[colorPurposeInt];
            }
            return Color.white;
        }

    }
    
    public enum ColorPurpose
    {
        MainColor=0,
        ConfirmColor=1,
        WarningColor=2,
        NegateColor=3,
        BackgroundColorLight=4
    }

}