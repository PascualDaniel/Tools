using Runtime.Attributes;
using Runtime.Attributes.Base;
using UnityEditor;
using UnityEngine;

namespace Editor.Attributes
{
    [CustomPropertyDrawer(typeof(DrawGizmoAttribute))]
    public class DrawBaseDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.PropertyField(position, property, label);
            if (property.propertyType == SerializedPropertyType.Float)
            {
                DrawGizmoAttribute attr = (DrawGizmoAttribute)attribute;
                Rect previewRect = new Rect(position.xMax - 20, position.y, 20, position.height);

                EditorGUI.DrawRect(previewRect, GetColor(attr.Color));
            }
            if (property.propertyType == SerializedPropertyType.Vector3)
            {
                DrawGizmoAttribute attr = (DrawGizmoAttribute)attribute;
                Rect previewRect = new Rect(position.xMax - 20, position.y, 20, position.height); 
                EditorGUI.DrawRect(previewRect, GetColor(attr.Color));
                    
                
            }
          
        }
        protected Color GetColor(DrawColor colorEnum)
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