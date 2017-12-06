using UnityEngine;

public static class TerrainGenerator
{

    public static Mesh Generate(ref Datas datas, Vector3 pos)
    {
        Mesh mesh = HexMeshGenerator.GenerateMesh(ref datas.tVars);

        AddNoise(ref datas.tVars, ref datas.nVars, mesh, pos);

        return mesh;
    }

    private static void AddNoise(ref TerrainVars tVars,
        ref NoiseVars nVars, Mesh mesh, Vector3 pos)
    {
        Vector3[] vertices = mesh.vertices;
        Color[] colors = new Color[vertices.Length];

        Gradient gradient = tVars.gradient;
        float height = tVars.Height;

        float[] noise = NoiseGenerator.noise(vertices, pos, ref nVars);

        for (int i = 0; i < vertices.Length; i++)
        {
            Vector3 currentVertex = vertices[i];
            colors[i] = gradient.Evaluate(noise[i]);
            vertices[i].y = (noise[i] * 2 - 1) * height; 
        }

        mesh.vertices = vertices;
        mesh.colors = colors;
        mesh.RecalculateNormals();
    }

}
