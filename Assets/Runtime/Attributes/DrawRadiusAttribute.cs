using UnityEngine;

namespace Runtime.Attributes
{
    /// <summary>
    /// Coloca un radio en SceneView alrededor de un objeto.
    /// Funciona con float o Vector3.
    /// </summary>
    public class DrawRadiusAttribute : PropertyAttribute
    {
        public string radiusField = null;  // opcional si Vector3
        public DrawColor Color = DrawColor.Green;
        public bool DrawInPlayMode = true;

        public DrawRadiusAttribute() { }

        public DrawRadiusAttribute(string radiusField, DrawColor color = DrawColor.Green, bool drawInPlayMode = true)
        {
            this.radiusField = radiusField;
            this.Color = color;
            this.DrawInPlayMode = drawInPlayMode;
        }
        public DrawRadiusAttribute( DrawColor color = DrawColor.Green, bool drawInPlayMode = true)
        {
            this.DrawInPlayMode = drawInPlayMode;
            this.Color = color;
            
        }
       
    }
}