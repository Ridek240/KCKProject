using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[System.Serializable]
public class MapData
{
    public int RenderDistance;
    public float ChunkSizeX;
    public float ChunkSizeY;
    public float ChunkSizeZ;
    public ChunkData[][] Chunks;

    public MapData(int RenderDistance, Vector3 ChunkSize)
    {
        this.RenderDistance = RenderDistance;
        this.ChunkSizeX = ChunkSize.x;
        this.ChunkSizeY = ChunkSize.y;
        this.ChunkSizeZ = ChunkSize.z;
        Chunks = new ChunkData[RenderDistance * 2 + 1][];
        for (int i = 0; i < Chunks.Length; i++)
        {
            Chunks[i] = new ChunkData[RenderDistance * 2 + 1];
        }
    }

    public void CopyChunks(GameObject[][] map)
    {
        for (int i = 0; i < RenderDistance * 2 + 1; i++)
        {
            for (int j = 0; j < RenderDistance * 2 + 1; j++)
            {
                //var prefabGameObject = EditorUtility.GetPrefabParent(map[i][j]);
                //var prefabGameObject = PrefabUtility.GetCorrespondingObjectFromSource(map[i][j]);
                Chunks[i][j] = new ChunkData(i - RenderDistance, j - RenderDistance, map[i][j].name);
                Debug.Log(map[i][j].name);
            }
        }
    }
}
