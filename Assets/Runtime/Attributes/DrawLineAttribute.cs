using Runtime.Attributes.Base;
using Runtime.Gizmos.DrawCommands;

namespace Runtime.Attributes
{
    public class DrawLineAttribute : DrawGizmoAttribute
    {
        public DrawLineAttribute(
            DrawColor color = DrawColor.White,
            bool drawInPlayMode = true)
            : base(GizmoShape.Line, color, drawInPlayMode) {}
    }
}