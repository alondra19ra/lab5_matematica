using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxisDrawer : MonoBehaviour
{
    public float axisLength = 2f;
    public Transform originPosition;

    private void OnDrawGizmos()
    {
        if (originPosition == null) return;

        Gizmos.color = Color.red;
        Gizmos.DrawRay(originPosition.position, Vector3.right * axisLength);
        Gizmos.DrawRay(originPosition.position, -Vector3.right * axisLength);

        Gizmos.color = Color.green;
        Gizmos.DrawRay(originPosition.position, Vector3.up * axisLength);
        Gizmos.DrawRay(originPosition.position, -Vector3.up * axisLength);

        Gizmos.color = Color.blue;
        Gizmos.DrawRay(originPosition.position, Vector3.forward * axisLength);
        Gizmos.DrawRay(originPosition.position, -Vector3.forward * axisLength);
    }
}

