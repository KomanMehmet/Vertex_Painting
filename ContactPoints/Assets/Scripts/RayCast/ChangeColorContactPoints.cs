using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class ChangeColorContactPoints : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.transform.gameObject.CompareTag("Cube"))
                {
                    MeshFilter meshFilter = hit.collider.gameObject.GetComponent<MeshFilter>();

                    Mesh mesh = meshFilter.mesh;
                    Color[] colors = mesh.colors;
                    Vector3[] vertices = mesh.vertices;

                    if (colors.Length != mesh.vertexCount)
                    {
                        Color[] newColors = new Color[mesh.vertexCount];
                        for (int i = 0; i < Mathf.Min(mesh.vertexCount, colors.Length); i++)
                        {
                            newColors[i] = colors[i];
                        }
                        colors = newColors;
                    }

                    int[] triangles = mesh.triangles;

                    int vertexIndex = triangles[hit.triangleIndex * 3 + 0];

                    colors[vertexIndex] = Color.white;
                    mesh.colors = colors;
                    meshFilter.mesh = mesh;
                }
            }
        }
    }
}
