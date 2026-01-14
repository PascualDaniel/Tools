using System.Collections.Generic;
using Runtime.Gizmos.DrawCommands;
using UnityEngine;

namespace Runtime.Gizmos.RuntimeState
{
    public class RadiusGizmoSource : GizmoSource
    {
        public float radius = 2f;
        public Color color = Color.green;

        public override void CollectGizmos(List<RuntimeGizmoRequest> list)
        {
            list.Add(new RuntimeGizmoRequest
            {
                Shape = GizmoShape.Sphere,
                Position = transform.position,
                Radius = radius,
                Color = color
            });
        }
    }
}
