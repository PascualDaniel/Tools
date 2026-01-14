using System.Collections.Generic;
using Runtime.Gizmos.DrawCommands;
using UnityEngine;

namespace Runtime.Gizmos
{
    public abstract class GizmoSource : MonoBehaviour
    {
        public abstract void CollectGizmos(List<RuntimeGizmoRequest> list);
    }
}