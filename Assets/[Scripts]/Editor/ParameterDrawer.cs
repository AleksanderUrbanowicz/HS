
using UnityEditor;
using UnityEngine;

namespace EditorTools
{

    //[CustomPropertyDrawer(typeof(ParameterBase))]
    public class ParameterDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {

            EditorGUI.BeginProperty(position, label, property);


            position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

            var indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;

            var idRect = new Rect(position.x, position.y, 90, position.height);
            var valueRect = new Rect(position.x + 95, position.y, 130, position.height);

            property.FindPropertyRelative("id").stringValue = EditorGUI.TextField(idRect, property.FindPropertyRelative("id").stringValue);
            property.FindPropertyRelative("value").floatValue = EditorGUI.FloatField(valueRect, property.FindPropertyRelative("value").floatValue);

            EditorGUI.indentLevel = indent;

            EditorGUI.EndProperty();
        }
    }


    //  [CustomPropertyDrawer(typeof(DynamicParameter))]
    public class DynamicParameterDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {

            EditorGUI.BeginProperty(position, label, property);


            position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

            var indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;

            var idRect = new Rect(position.x, position.y, 90, position.height);
            var valueRect = new Rect(position.x + 95, position.y, 130, position.height);
            var changeRateRect = new Rect(position.x + 255, position.y, 100, position.height);

            property.FindPropertyRelative("id").stringValue = EditorGUI.TextField(idRect, property.FindPropertyRelative("id").stringValue);
            property.FindPropertyRelative("value").floatValue = EditorGUI.FloatField(valueRect, property.FindPropertyRelative("value").floatValue);
            property.FindPropertyRelative("changeRate").floatValue = EditorGUI.FloatField(changeRateRect, property.FindPropertyRelative("changeRate").floatValue);

            EditorGUI.indentLevel = indent;

            EditorGUI.EndProperty();
        }
    }
}