using Runtime.Attributes.Base;
using Runtime.Gizmos.DrawCommands;

namespace Runtime.Attributes
{
    public class DrawAreaAttribute : DrawGizmoAttribute
    {
        public DrawAreaAttribute(
            DrawColor color = DrawColor.Green,
            bool drawInPlayMode = true)
            : base(GizmoShape.Sphere,color, drawInPlayMode) {}
    }
}