using System;
using UnityEngine;

[Serializable]
public struct TerrainVars
{
    [Range(1, 145)]
    [SerializeField] private int size;
    [SerializeField] private int scale;
    [SerializeField] private float height;

    public int Size { get { return size >= 1 ? size : 1; } }
    public int Scale { get { return scale >= 1 ? scale : 1; } }
    public float Height { get { return height; } }

    public Gradient gradient;
}

[Serializable]
public struct NoiseVars
{
    [SerializeField] private float frequency;
    [Range(1, 8)]
    [SerializeField] private int octaves;
    [Range(1f, 4f)]
    [SerializeField] private float lacunarity;
    [Range(0f, 1f)]
    [SerializeField] private float persistence;
    [SerializeField] private int seed;

    public float Frequency { get { return frequency; } }
    public int Octaves { get { return octaves >= 1 ? octaves : 1; } }
    public float Lacunarity { get { return lacunarity >= 1f ? lacunarity : 1f; } }
    public float Persistence { get { return persistence; } }
    public int Seed { get { return seed; } }
}