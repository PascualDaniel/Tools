using Runtime.Attributes;
using Runtime.Gizmos;
using UnityEngine;

public class ExampleFieldGizmo : MonoBehaviour
{
    // Float → radio, color rojo
    [DrawRadius(DrawColor.Red)]
    public float attackRange = 3f;

    // Vector3 offset → usa attackRange como radio, color azul
    [DrawRadius("attackRange", DrawColor.Blue)]
    public Vector3 effectOffset = Vector3.forward * 2f;

    // Float → radio verde
    [DrawRadius(DrawColor.Green)]
    public float detectionRange = 5f;

    // Vector3 offset → radio propio, color yellow
    [DrawRadius(DrawColor.Yellow)]
    public Vector3 warningArea = new Vector3(1, 0, -2);

}