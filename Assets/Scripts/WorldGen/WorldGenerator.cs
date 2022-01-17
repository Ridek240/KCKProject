using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGenerator : WorldBuilder
{
    public WorldGenerator(int renderDistance, Vector3 chunkSize, Transform transform) : base(renderDistance, chunkSize, transform) { }

    public override GameObject GetChunk(int GlobalX, int GlobalY)
    {
        GameObject result;
        if (GlobalX <= -RenderDistance || GlobalX >= RenderDistance || GlobalY <= -RenderDistance || GlobalY >= RenderDistance)
            result = Resources.Load("ChunkTypes/4_Walls") as GameObject;
        else if (GlobalX == 0 && GlobalY == 0)
            result = Resources.Load("ChunkTypes/Plane") as GameObject;
        else
        {
            int random = Random.Range(0, 5);

            switch (random)
            {
                case (0):
                    result = Resources.Load("ChunkTypes/1_Philar") as GameObject;
                    break;
                case (1):
                    result = Resources.Load("ChunkTypes/1_Sphere") as GameObject;
                    break;
                case (2):
                    result = Resources.Load("ChunkTypes/1_Tree") as GameObject;
                    break;
                case (3):
                    result = Resources.Load("ChunkTypes/4_Philars") as GameObject;
                    break;
                case (4):
                    result = Resources.Load("ChunkTypes/4_Walls") as GameObject;
                    break;
                default:
                    result = Resources.Load("ChunkTypes/Plane") as GameObject;
                    break;
            }
        }
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
    public override void SetMapData(MapData mapData) { }
}
