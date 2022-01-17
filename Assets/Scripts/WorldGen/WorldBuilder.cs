using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WorldBuilder
{
    public int RenderDistance = 1;
    public Vector3 ChunkSize = new Vector3(10, 10, 10);
    public Transform Transform;
    protected GameObject[][] Chunks;

    protected WorldBuilder(int RenderDistance, Vector3 ChunkSize, Transform transform)
    {
        this.RenderDistance = RenderDistance;
        this.ChunkSize = ChunkSize;
        this.Transform = transform;
        Chunks = new GameObject[RenderDistance * 2 + 1][];
        for (int i = 0; i < Chunks.Length; i++)
        {
            Chunks[i] = new GameObject[RenderDistance * 2 + 1];
        }
    }

    public GameObject InstanceChunk(GameObject prefab, int i, int j)
    {
        string name = prefab.name;
        GameObject gameObject = MonoBehaviour.Instantiate(prefab);

        gameObject.transform.position = new Vector3(i * ChunkSize.x * ChunkSize.x, 0, j * ChunkSize.z * ChunkSize.z);
        gameObject.transform.parent = Transform;
        gameObject.transform.localScale = ChunkSize;
        gameObject.name = name;

        return gameObject;
    }

    public abstract void SetMapData(MapData mapData);
    public abstract GameObject GetChunk(int GlobalX, int GlobalY);
    public abstract void AddChunk(int GlobalX, int GlobalY, GameObject Chunk);
    public abstract GameObject[][] GetMap();
}
