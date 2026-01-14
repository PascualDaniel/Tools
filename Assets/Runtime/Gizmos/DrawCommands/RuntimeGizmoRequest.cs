using UnityEngine;

namespace Runtime.Gizmos.DrawCommands
{
        public enum GizmoShape
        {
            Sphere,
            Line
        }

        public struct RuntimeGizmoRequest
        {
            public GizmoShape Shape;
            public Vector3 Position;
            public Vector3 EndPosition;
            public float Radius;
            public Color Color;
        }
    
}
