using Editor.Gizmos;
using UnityEditor;
using UnityEngine;

public class GizmoDebuggerWindow : EditorWindow
{
    [MenuItem("Tools/Gizmo Debugger")]
    static void Open() => GetWindow<GizmoDebuggerWindow>();

    private void OnGUI()
    {
        GUILayout.Label("Gizmo Fields in Scene");
        foreach (var item in RuntimeGizmoRenderer.GetCachedFields())
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField(item.owner.name + "." + item.field.Name);
           // item.enabled = EditorGUILayout.Toggle(item.enabled);
            EditorGUILayout.EndHorizontal();
        }
    }
}