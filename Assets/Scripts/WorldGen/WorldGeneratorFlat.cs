using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGeneratorFlat : WorldGenerator
{
    public WorldGeneratorFlat(int renderDistance, Vector3 chunkSize, Transform transform) : base(renderDistance, chunkSize, transform) { }

    public override GameObject GetChunk(int GlobalX, int GlobalY)
    {
        GameObject result = Resources.Load("ChunkTypes/Plane") as GameObject;
        return result;
    }
}
