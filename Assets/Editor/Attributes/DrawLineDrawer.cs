using Runtime.Attributes;
using Runtime.Attributes.Base;
using UnityEditor;
using UnityEngine;

namespace Editor.Attributes
{
    [CustomPropertyDrawer(typeof(DrawLineAttribute))]
    public class DrawLineDrawer : DrawBaseDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) 
        {
            base.OnGUI(position, property, label);
            
            
            
          
        }
      
    }
}