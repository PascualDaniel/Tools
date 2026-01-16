using Runtime.Gizmos.DrawCommands;
using UnityEngine;

namespace Runtime.Attributes.Base
{
    public abstract class DrawGizmoAttribute : PropertyAttribute
    {
       
        
        
        public DrawColor Color;
        public bool DrawInPlayMode;
        public GizmoShape Shape;
        
        public bool UseTransformRotation = true;
        public GizmoSpace Space = GizmoSpace.World;
        
        public Usage Usage = Usage.Size;

        protected DrawGizmoAttribute(
            GizmoShape shape,
            DrawColor color = DrawColor.Green,
            bool drawInPlayMode = true)
        {
            Shape = shape;
            Color = color;
            DrawInPlayMode = drawInPlayMode;
        }
        protected DrawGizmoAttribute(
            GizmoShape shape,
            DrawColor color = DrawColor.Green,
            bool drawInPlayMode = true,bool useTransformRotation = true, GizmoSpace space = GizmoSpace.Local, Usage usage = Usage.Size)
        {
            Shape = shape;
            Color = color;
            DrawInPlayMode = drawInPlayMode;
            Space = space;
            UseTransformRotation = useTransformRotation;
            Usage = usage;
        }
    }
}