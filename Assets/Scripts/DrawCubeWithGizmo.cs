using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCubeWithGizmos : MonoBehaviour
{
    [Header("Transformaciones")]
    public Vector3 translation = Vector3.zero;
    public Vector3 scale = Vector3.one;

    private Vector3[] vertices;
    private int[,] edges;

    public Transformations transformations;

    private void OnDrawGizmos()
    {
        if (transformations == null)
        {
            Debug.LogError("Transformations no está asignado.");
            return;
        }

        vertices = new Vector3[]
        {
            new Vector3(-0.5f, -0.5f, -0.5f),
            new Vector3(0.5f, -0.5f, -0.5f),
            new Vector3(0.5f, -0.5f, 0.5f),
            new Vector3(-0.5f, -0.5f, 0.5f),
            new Vector3(-0.5f, 0.5f, -0.5f),
            new Vector3(0.5f, 0.5f, -0.5f),
            new Vector3(0.5f, 0.5f, 0.5f),
            new Vector3(-0.5f, 0.5f, 0.5f)
        };

        edges = new int[,]
        {
            {0,1}, {1,2}, {2,3}, {3,0},
            {4,5}, {5,6}, {6,7}, {7,4},
            {0,4}, {1,5}, {2,6}, {3,7}
        };

        Gizmos.color = Color.white;

        foreach (Vector3 v in vertices)
        {
            Vector3 transformed = Vector3.Scale(v, transformations.scaleValue) + transformations.translationValue;
            Gizmos.DrawSphere(transformed, 0.05f);
        }

        Gizmos.color = Color.black;
        for (int i = 0; i < edges.GetLength(0); i++)
        {
            Vector3 start = Vector3.Scale(vertices[edges[i, 0]], transformations.scaleValue) + transformations.translationValue;
            Vector3 end = Vector3.Scale(vertices[edges[i, 1]], transformations.scaleValue) + transformations.translationValue;
            Gizmos.DrawLine(start, end);
        }
    }
}



