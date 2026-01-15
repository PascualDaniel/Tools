using Runtime.Attributes.Base;
using Runtime.Gizmos.DrawCommands;
using UnityEngine;

namespace Runtime.Attributes
{
    public class DrawCubeAttribute : DrawGizmoAttribute
    {
        public DrawCubeAttribute(
            DrawColor color = DrawColor.Cyan,
            bool drawInPlayMode = true)
            : base(GizmoShape.Cube,color, drawInPlayMode) {}
    }
}
