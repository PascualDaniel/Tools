using Runtime.Attributes.Base;
using Runtime.Gizmos.DrawCommands;
using UnityEngine;

namespace Runtime.Attributes
{
    public class DrawLabelAttribute : DrawGizmoAttribute
    {
        public bool ShowFieldName ;
        public string CustomLabel;
        public Vector3 LabelOffset;

        public DrawLabelAttribute(string customLabel, float labelOffset,bool showFieldName=true,   DrawColor color = DrawColor.Green, bool drawInPlayMode = true,
            bool useTransformRotation = false
            )
            : base(
                GizmoShape.Label,
                color,
                drawInPlayMode,
                useTransformRotation
            )
        {
            this.CustomLabel = customLabel;
            this.LabelOffset = new Vector3(0.0f, labelOffset, 0.0f);
            this.ShowFieldName = showFieldName;
            
        }
    }
}