using Runtime.Attributes;
using Runtime.Gizmos;
using UnityEngine;

public class ExampleFieldGizmo : MonoBehaviour
{
    [DrawRadius()]
    public float attackRange = 3f;

    [DrawRadius(DrawColor.Blue)]
    public Vector3 effectOffset = Vector3.forward * 2f;
}