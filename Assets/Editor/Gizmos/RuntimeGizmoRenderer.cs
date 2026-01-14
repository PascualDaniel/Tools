using System.Collections.Generic;
using Runtime.Gizmos;
using Runtime.Gizmos.DrawCommands;
using UnityEditor;
using UnityEngine;

namespace Editor.Gizmos
{
    [InitializeOnLoad]
    public static class RuntimeGizmoRenderer
    {
        static readonly List<RuntimeGizmoRequest> gizmoBuffer = new();
        static GizmoSource[] sources;

        static RuntimeGizmoRenderer()
        {
            SceneView.duringSceneGui += OnSceneGUI;
            EditorApplication.playModeStateChanged += _ => SceneView.RepaintAll();
        }

        static void OnSceneGUI(SceneView sceneView)
        {
            if (!Application.isPlaying && !sceneView.drawGizmos)
                return;

            CollectGizmos();
            DrawGizmos();
        }

        static void CollectGizmos()
        {
            gizmoBuffer.Clear();
            sources = Object.FindObjectsByType<GizmoSource>(FindObjectsSortMode.None);

            foreach (var source in sources)
            {
                if (source == null) continue;
                source.CollectGizmos(gizmoBuffer);
            }
        }

        static void DrawGizmos()
        {
            Handles.zTest = UnityEngine.Rendering.CompareFunction.LessEqual;

            foreach (var gizmo in gizmoBuffer)
            {
                Handles.color = gizmo.Color;

                switch (gizmo.Shape)
                {
                    case GizmoShape.Sphere:
                        Handles.DrawWireDisc(
                            gizmo.Position,
                            Vector3.up,
                            gizmo.Radius
                        );
                        break;

                    case GizmoShape.Line:
                        Handles.DrawLine(
                            gizmo.Position,
                            gizmo.EndPosition
                        );
                        break;
                }
            }
        }
    }
}