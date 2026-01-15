using Runtime.Attributes.Base;
using Runtime.Gizmos.DrawCommands;
using UnityEngine;

namespace Runtime.Attributes
{
    /// <summary>
    /// Coloca un radio en SceneView alrededor de un objeto.
    /// Funciona con float o Vector3.
    /// </summary>
    public class DrawRadiusAttribute : DrawGizmoAttribute
    {
        public string radiusField = null;  // opcional si Vector3
        

        public DrawRadiusAttribute(string radiusField, DrawColor color = DrawColor.Green, bool drawInPlayMode = true): base(GizmoShape.Radius ,  color, drawInPlayMode)
        {
            this.radiusField = radiusField;
            this.Color = color;
            this.DrawInPlayMode = drawInPlayMode;
        }
        public DrawRadiusAttribute( DrawColor color = DrawColor.Green, bool drawInPlayMode = true): base(GizmoShape.Radius ,color, drawInPlayMode)
        {
            this.DrawInPlayMode = drawInPlayMode;
            this.Color = color;
            
        }
       
    }
}