using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldLoader : WorldBuilder
{
    public MapData MapData;
    public WorldLoader(int renderDistance, Vector3 chunkSize, Transform transform) : base(renderDistance, chunkSize, transform) { }

    public override GameObject GetChunk(int GlobalX, int GlobalY)
    {
        ChunkData chunk = MapData.Chunks[GlobalX + RenderDistance][GlobalY + RenderDistance];

        GameObject result = Resources.Load("ChunkTypes/" + chunk.Type) as GameObject;

        return result;
    }

    public override void AddChunk(int GlobalX, int GlobalY, GameObject Chunk)
    {
        Chunks[GlobalX + RenderDistance][GlobalY + RenderDistance] = Chunk;
    }
    public override GameObject[][] GetMap()
    {
        return Chunks;
    }

    public override void SetMapData(MapData mapData) 
    {
        MapData = mapData;
        RenderDistance = MapData.RenderDistance;
        ChunkSize = new Vector3(mapData.ChunkSizeX, mapData.ChunkSizeY, mapData.ChunkSizeZ);
    }
}
