using Runtime.Attributes.Base;
using Runtime.Gizmos.DrawCommands;
using UnityEngine;

namespace Runtime.Attributes
{
    /// <summary>
    /// Coloca un radio en SceneView alrededor de un objeto.
    /// Funciona con float o Vector3.
    /// </summary>
    public class DrawShapeAttribute : DrawGizmoAttribute
    {   

  
        public DrawShapeAttribute(
            GizmoShape shape,
            DrawColor color = DrawColor.Green,
            bool drawInPlayMode = true,bool useTransformRotation = true, GizmoSpace space = GizmoSpace.World, Usage usage = Usage.Size)
            : base(GizmoShape.Radius ,  color, drawInPlayMode,useTransformRotation,space, usage ){
            Shape = shape;
            Color = color;
            DrawInPlayMode = drawInPlayMode;
            Space = space;
            UseTransformRotation = useTransformRotation;
            Usage = usage;
        }
       
    }
}