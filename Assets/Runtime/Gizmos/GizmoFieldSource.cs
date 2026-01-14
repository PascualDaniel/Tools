using System.Collections.Generic;
using System.Reflection;
using Runtime.Attributes;
using Runtime.Gizmos.DrawCommands;
using UnityEngine;

namespace Runtime.Gizmos
{
    public class GizmoFieldSource : MonoBehaviour
    {
        /// <summary>
        /// Recorre campos con [DrawRadius] y genera requests.
        /// NO dibuja nada.
        /// </summary>
        public void CollectGizmos(List<RuntimeGizmoRequest> list)
        {
            var fields = this.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (var field in fields)
            {
                var attr = field.GetCustomAttribute<DrawRadiusAttribute>();
                if (attr == null) continue;

                Vector3 position = transform.position;
                float radius = 1f;

                if (field.FieldType == typeof(float))
                    radius = (float)field.GetValue(this);
                else if (field.FieldType == typeof(Vector3))
                    position += (Vector3)field.GetValue(this);
                else
                    continue;

                list.Add(new RuntimeGizmoRequest
                {
                    Shape = GizmoShape.Sphere,
                    Position = position,
                    Radius = radius,
                    Color = attr.Color
                });
            }
        }
        
    }
}