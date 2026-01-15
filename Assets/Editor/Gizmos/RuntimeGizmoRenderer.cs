using System.Collections.Generic;
using System.Reflection;
using Runtime.Attributes;
using Runtime.Attributes.Base;
using Runtime.Gizmos.DrawCommands;
using UnityEditor;
using UnityEngine;

namespace Editor.Gizmos
{
    [InitializeOnLoad]
    public static class RuntimeGizmoRenderer
    {
        private static List<CachedField> cache = new();
        private static bool isInitialized = false;

        static RuntimeGizmoRenderer()
        {
            EditorApplication.hierarchyChanged += InitializeCache;
            SceneView.duringSceneGui += OnSceneGUI;
        }

        public class CachedField
        {
            public MonoBehaviour owner;
            public FieldInfo field;
            public DrawGizmoAttribute attr;
            public bool enabled = true;
        }

        private static void InitializeCache()
        {
            cache.Clear();
            foreach (var mb in Object.FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None))
            {
                foreach (var f in mb.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
                {
                    var attr = f.GetCustomAttribute<DrawGizmoAttribute>();
                    if (attr != null)
                    {
                        cache.Add(new CachedField
                        {
                            owner = mb,
                            field = f,
                            attr = attr,
                            enabled = true
                        });
                    }

                }
            }
            isInitialized = true;
        }

        private static void OnSceneGUI(SceneView sceneView)
        {
            if (!isInitialized) InitializeCache();

            foreach (var item in cache)
            {
                if (!item.enabled || item.owner == null || !item.owner.gameObject.activeInHierarchy) continue;
                if (!item.attr.DrawInPlayMode && Application.isPlaying) continue;

                Vector3 position = item.owner.transform.position;
                float radius = 1f;
                Vector3 size = Vector3.one;
                Vector3 direction = Vector3.forward;
                
                object value = item.field.GetValue(item.owner);
                
                if (value is float f)
                {
                    radius = f;
                    size = Vector3.one * radius;
                    direction = item.owner.transform.forward * radius;
                }
                else if (value is Vector3 v)
                {
                    position += v;
                    size = v;
                    direction = v;
                }
                else if (value is Bounds b)
                {
                    position += b.center;
                    size = b.size;
                }
                else
                {
                    continue;
                }

                Handles.color = GetColor(item.attr.Color);

                switch (item.attr.Shape)
                {
                    case GizmoShape.Radius:
                        Handles.DrawWireDisc(position, Vector3.up, radius);
                        break;

                    case GizmoShape.Cube:
                        Handles.DrawWireCube(position, size);
                        break;

                    case GizmoShape.Line:
                        Handles.DrawLine(position, position + direction);
                        break;

                    case GizmoShape.Sphere:
                        Handles.DrawWireDisc(position, Vector3.up, radius);
                        Handles.DrawWireDisc(position, Vector3.right, radius);
                        Handles.DrawWireDisc(position, Vector3.forward, radius);
                        break;
                }
            }
        }

        private static Color GetColor(DrawColor colorEnum)
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
        public static List<CachedField> GetCachedFields()
        {
            if (!isInitialized)
                InitializeCache();
            return cache;
        }

    }
}
