using Editor.Gizmos;
using Runtime.Attributes;
using UnityEditor;
using UnityEngine;

namespace Editor.Windows
{
    public class GizmoDebuggerWindow : EditorWindow
    {
        private bool globalToggle = true;

        [MenuItem("Tools/Gizmo Debugger")]
        static void Open() => GetWindow<GizmoDebuggerWindow>("Gizmo Debugger");

        private void OnGUI()
        {
            GUILayout.Label("Gizmo Fields in Scene", EditorStyles.boldLabel);

            globalToggle = EditorGUILayout.Toggle("Show All Gizmos", globalToggle);

            foreach (var item in RuntimeGizmoRenderer.GetCachedFields())
            {
                EditorGUILayout.BeginHorizontal();

                // Mostrar nombre + toggle individual
                EditorGUILayout.LabelField(item.owner.name + "." + item.field.Name);

                if (globalToggle)
                    item.enabled = EditorGUILayout.Toggle(item.enabled);
                else
                    item.enabled = false;

                // Mostrar rectángulo de color
                EditorGUI.DrawRect(EditorGUILayout.GetControlRect(false, 16, GUILayout.Width(20)), 
                    GetColor(item.attr.Color));

                EditorGUILayout.EndHorizontal();
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