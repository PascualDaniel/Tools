using System.Collections.Generic;
using Runtime.Attributes;
using Runtime.Gizmos.DrawCommands;
using UnityEngine;

namespace Runtime.Gizmos.RuntimeState
{
    public class RadiusGizmoSource : GizmoSource
    {
        public float radius = 2f;
        public DrawColor color = DrawColor.Green;

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
