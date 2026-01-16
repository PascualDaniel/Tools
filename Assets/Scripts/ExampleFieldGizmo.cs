using System;
using Runtime.Attributes;
using Runtime.Attributes.Base;
using Runtime.Gizmos;
using Runtime.Gizmos.DrawCommands;
using UnityEditor;
using UnityEngine;

public class ExampleFieldGizmo : MonoBehaviour
{
    // Float → radio, color rojo
    [DrawLabel("Range", 0.5f)]
    public double attackRange = 3f;
    
    [DrawShape(GizmoShape.Cube, DrawColor.Cyan, true , false, GizmoSpace.World , Usage = Usage.Size)]
    public Vector3 asd234 = Vector3.forward * 2f;

    // Vector3 offset → usa attackRange como radio, color azul
    [DrawRadius("attackRange", DrawColor.Blue)]
    public Vector3 effectOffset = Vector3.forward * 2f;

    // Float → radio verde
    [DrawArea(DrawColor.Green)]
    public float detectionRange = 5f;

    // Vector3 offset → radio propio, color yellow
    [DrawCube(DrawColor.Yellow)]
    public Vector3 warningArea = new Vector3(1, 0, -2);


    private void Update()
    {
        attackRange+= Time.deltaTime*1;
    }
}