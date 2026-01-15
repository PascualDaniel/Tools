using Runtime.Gizmos.DrawCommands;
using UnityEngine;

namespace Runtime.Attributes.Base
{
    public abstract class DrawGizmoAttribute : PropertyAttribute
    {
        public DrawColor Color;
        public bool DrawInPlayMode;
        public GizmoShape Shape;

        protected DrawGizmoAttribute(
            GizmoShape shape,
            DrawColor color = DrawColor.Green,
            bool drawInPlayMode = true)
        {
            Shape = shape;
            Color = color;
            DrawInPlayMode = drawInPlayMode;
        }
    }
}