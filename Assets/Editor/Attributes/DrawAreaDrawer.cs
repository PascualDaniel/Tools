using Runtime.Attributes;
using Runtime.Attributes.Base;
using UnityEditor;
using UnityEngine;

namespace Editor.Attributes
{
    [CustomPropertyDrawer(typeof(DrawAreaAttribute))]
    public class DrawAreaDrawer : DrawBaseDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) 
        {
            base.OnGUI(position, property, label);
            
            
            
          
        }
      
    }
}