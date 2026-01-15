using Runtime.Attributes;
using Runtime.Attributes.Base;
using UnityEditor;
using UnityEngine;

namespace Editor.Attributes
{
    [CustomPropertyDrawer(typeof(DrawRadiusAttribute))]
    public class DrawRadiusDrawer : DrawBaseDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) 
        {
          //  base.OnGUI(position, property, label);
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
      
    }
}