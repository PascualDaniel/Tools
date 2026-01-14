using UnityEngine;

namespace Runtime.Attributes
{
    /// <summary>
    /// Coloca un radio en SceneView alrededor de un objeto.
    /// Funciona con float o Vector3.
    /// </summary>
    public class DrawRadiusAttribute : PropertyAttribute
    {
        public DrawColor Color = DrawColor.Green;
        public bool DrawInPlayMode = true;

        public DrawRadiusAttribute() { }

        public DrawRadiusAttribute( DrawColor color = DrawColor.Green, bool drawInPlayMode = true)
        {
            this.DrawInPlayMode = drawInPlayMode;
            this.Color = color;
            
        }
       
    }
}