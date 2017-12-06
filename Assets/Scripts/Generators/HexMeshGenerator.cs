using System.Collections.Generic;
using UnityEngine;

public static class HexMeshGenerator
{

    public static Mesh GenerateMesh(ref TerrainVars tVars)
    {
        Mesh mesh = new Mesh();

        List<Vector3> vertices = new List<Vector3>();
        List<int> triangles = new List<int>();

        CreateVertices(ref tVars, vertices);
        CreateTriangles(ref tVars, triangles);

        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();

        return mesh;
    }

    private static void CreateVertices(ref TerrainVars tVars,
        List<Vector3> vertices)
    {
        int size = tVars.Size;
        int scale = tVars.Scale;

        for (int z = 0; z <= size; z++)
        {
            int xSize = size + z;

            for (int x = 0; x <= xSize; x++)
            {
                vertices.Add(new Vector3(x - Hex.cos60 * z - size / 2f,
                    0, (z - size) * Hex.sin60) * scale);
            }
        }
        for (int z = size + 1, i = 0; z <= 2 * size; z++, i++)
        {
            int xSize = 2 * size - i - 1;

            for (int x = 0; x <= xSize; x++)
            {
                vertices.Add(new Vector3(x - (size - 1 - i) * Hex.cos60 - size / 2f,
                    0, (z - size) * Hex.sin60) * scale);
            }
        }
    }

    private static void CreateTriangles(ref TerrainVars tVars,
        List<int> triangles)
    {
        int i = 0;
        int size = tVars.Size;

        for (int z = 0; z < size; z++, i++)
        {
            int xSize = size + z;

            for (int x = 0; x < xSize; x++, i++)
            {
                triangles.Add(i);
                triangles.Add(i + xSize + 1);
                triangles.Add(i + xSize + 2);

                triangles.Add(i);
                triangles.Add(i + xSize + 2);
                triangles.Add(i + 1);

                if (x == xSize - 1)
                {
                    triangles.Add(i + 1);
                    triangles.Add(i + xSize + 2);
                    triangles.Add(i + xSize + 3);
                }
            }
        }

        for (int z = 0; z < size; z++, i++)
        {
            int xSize = 2 * size - z;

            for (int x = 0; x < xSize; x++, i++)
            {
                triangles.Add(i);
                triangles.Add(i + xSize + 1);
                triangles.Add(i + 1);

                if (x != xSize - 1)
                {
                    triangles.Add(i + 1);
                    triangles.Add(i + xSize + 1);
                    triangles.Add(i + xSize + 2);
                }
            }
        }
    }
	
}
