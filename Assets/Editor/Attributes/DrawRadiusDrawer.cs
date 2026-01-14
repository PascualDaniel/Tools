using Runtime.Attributes;
using UnityEditor;
using UnityEngine;

namespace Tools.Editor.Attributes
{
    [CustomPropertyDrawer(typeof(DrawRadiusAttribute))]
    public class DrawRadiusDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.PropertyField(position, property, label);

          
        }
    }
}