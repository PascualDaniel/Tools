using System.Collections.Generic;
using System.Reflection;
using Runtime.Attributes;
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
            public DrawRadiusAttribute attr;
        }

        private static void InitializeCache()
        {
            cache.Clear();
            foreach (var mb in Object.FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None))
            {
                foreach (var f in mb.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
                {
                    var attr = f.GetCustomAttribute<DrawRadiusAttribute>();
                    if (attr != null)
                        cache.Add(new CachedField { owner = mb, field = f, attr = attr });
                }
            }
            isInitialized = true;
        }

        private static void OnSceneGUI(SceneView sceneView)
        {
            if (!isInitialized) InitializeCache();

            foreach (var item in cache)
            {
                if (item.owner == null || !item.owner.gameObject.activeInHierarchy) continue;

                Vector3 position = item.owner.transform.position;
                float radius = 1f;

                if (item.field.FieldType == typeof(float))
                {
                    radius = (float)item.field.GetValue(item.owner);
                }
                else if (item.field.FieldType == typeof(Vector3))
                {
                    Vector3 offset = (Vector3)item.field.GetValue(item.owner);
                    position += offset;

               
                }

                Handles.color = GetColor(item.attr.Color);
                Handles.DrawWireDisc(position, Vector3.up, radius);
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
