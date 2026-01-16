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
            public bool enabled;
        }

        private static void InitializeCache()
        {
            cache.Clear();
            foreach (var mb in Object.FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None))
            {
                foreach (var f in mb.GetType()
                             .GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
                {
                    var attr = f.GetCustomAttribute<DrawGizmoAttribute>();
                    if (attr != null)
                    {
                        cache.Add(new CachedField
                        {
                            owner = mb,
                            field = f,
                            attr = attr,
                            enabled = true,
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
                if (!item.enabled || item.owner == null || !item.owner.gameObject.activeInHierarchy)
                    continue;

                if (!item.attr.DrawInPlayMode && Application.isPlaying)
                    continue;

                var t = item.owner.transform;

                Vector3 localPosition = Vector3.zero;
                Vector3 worldPosition = t.position;
                
                Vector3 direction = Vector3.forward;
                Vector3 size = Vector3.one;
                float radius = 1f;

                object value = item.field.GetValue(item.owner);


                if (value is float f )
                {
                    radius = f;
                    size = Vector3.one * radius;
                    direction = Vector3.forward * radius;
                }
                if (value is double a )
                {
                    radius = (float)a;
                    size = Vector3.one * radius;
                    direction = Vector3.forward * radius;
                }
                else if (value is Vector3 v)
                {
                    switch (item.attr.Usage)
                    {
                        case Usage.Size:
                            size = v;
                            break;

                        case Usage.Direction:
                            direction = v;
                            break;

                        case Usage.Offset:
                            if (item.attr.Space == GizmoSpace.Local)
                                localPosition = v;
                            else
                                worldPosition = v; 
                            break;
                        
                    }
                }
                else if (value is Bounds b)
                {
                    size = b.size;
                }
                else
                {
                    continue;
                }


                Handles.color = GetColor(item.attr.Color);
                Matrix4x4 matrix;
                Vector3 drawPosition;
               

                if (item.attr.Space == GizmoSpace.Local)
                {
                    matrix = item.attr.UseTransformRotation
                        ? Matrix4x4.TRS(t.position, t.rotation, Vector3.one)
                        : Matrix4x4.TRS(t.position, Quaternion.identity, Vector3.one);

                    drawPosition = localPosition;
                  
                }
                else
                {
                    matrix = Matrix4x4.identity;
                    drawPosition = worldPosition;
                  
                }
                Vector3 drawDirection = direction;

                if (item.attr.UseTransformRotation)
                {
                    drawDirection = t.rotation * drawDirection;
                }

                Handles.color = GetColor(item.attr.Color);

                using (new Handles.DrawingScope(Handles.color, matrix))
                {
                    switch (item.attr.Shape)
                    {
                        case GizmoShape.Line:
                            Handles.DrawLine(drawPosition, drawPosition + drawDirection);
                            break;

                        case GizmoShape.Cube:
                            if (item.attr.UseTransformRotation)
                            {
                                using (new Handles.DrawingScope(
                                           Handles.color,
                                           Matrix4x4.TRS(
                                               matrix.GetColumn(3),
                                               t.rotation,
                                               Vector3.one)))
                                {
                                    Handles.DrawWireCube(Vector3.zero, size);
                                }
                            }
                            else
                            {
                                Handles.DrawWireCube(drawPosition, size);
                            }
                            break;

                        case GizmoShape.Radius:
                            Handles.DrawWireDisc(drawPosition, Vector3.up, radius);
                            break;

                        case GizmoShape.Sphere:
                            Handles.DrawWireDisc(drawPosition, Vector3.up, radius);
                            Handles.DrawWireDisc(drawPosition, Vector3.right, radius);
                            Handles.DrawWireDisc(drawPosition, Vector3.forward, radius);
                            break;
                        case GizmoShape.Label:
                            DrawLabelAttribute lbattr = (DrawLabelAttribute)item.attr;
                            
                            Handles.Label(drawPosition+ lbattr.LabelOffset, lbattr.CustomLabel +": "+ value.ToString());
                            break;
                    }
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