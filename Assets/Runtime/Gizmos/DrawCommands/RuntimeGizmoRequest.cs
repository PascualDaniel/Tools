using Runtime.Attributes;
using UnityEngine;

namespace Runtime.Gizmos.DrawCommands
{
        public enum GizmoShape
        {
            Radius,
            Cube,
            Line,
            Sphere
        }

        public struct RuntimeGizmoRequest
        {
            public GizmoShape Shape;
            public Vector3 Position;
            public Vector3 EndPosition;
            public float Radius;
            public DrawColor Color;
        }
    
}
