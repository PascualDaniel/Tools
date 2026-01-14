using Runtime.Attributes;
using UnityEditor;
using UnityEngine;

namespace Editor.Attributes
{
    [CustomPropertyDrawer(typeof(DrawRadiusAttribute))]
    public class DrawRadiusDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.PropertyField(position, property, label);
            if (property.propertyType == SerializedPropertyType.Float)
            {
                DrawRadiusAttribute attr = (DrawRadiusAttribute)attribute;
                Rect previewRect = new Rect(position.xMax - 20, position.y, 20, position.height);

                EditorGUI.DrawRect(previewRect, GetColor(attr.Color));
            }
            if (property.propertyType == SerializedPropertyType.Vector3)
            {
                DrawRadiusAttribute attr = (DrawRadiusAttribute)attribute;
                if (!string.IsNullOrEmpty(attr.radiusField))
                {
                    SerializedProperty radiusProp = property.serializedObject.FindProperty(attr.radiusField);
                    if (radiusProp != null && radiusProp.propertyType == SerializedPropertyType.Float)
                    {
                        float radius = radiusProp.floatValue;
                        Rect previewRect = new Rect(position.xMax - 20, position.y, 20, position.height);
                        EditorGUI.DrawRect(previewRect, GetColor(attr.Color));
                        EditorGUI.LabelField(previewRect, radius.ToString("F1")); // mostrar valor de radio
                    }
                }
            }
          
        }
        private Color GetColor(DrawColor colorEnum)
        {
            return colorEnum switch
            {
                DrawColor.Red => Color.red,
                DrawColor.Blue => Color.blue,
                DrawColor.Green => Color.green,
                DrawColor.Yellow => Color.yellow,
                DrawColor.Magenta => Color.magenta,
                DrawColor.Cyan => Color.cyan,
                DrawColor.White => Color.white,
                _ => Color.white
            };
        }
    }
}