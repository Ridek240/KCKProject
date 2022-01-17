using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldController : MonoBehaviour
{
    public Vector3 ChunkSize = new Vector3(10, 10, 10);
    public int RenderDistance = 1;
    public bool LoadWorld = false;

    void Start()
    {
        WorldBuilder builder;
        if (LoadWorld)
            builder = new WorldLoader(RenderDistance, ChunkSize, transform);
        else
            builder = new WorldGenerator(RenderDistance, ChunkSize, transform);
        WorldDirector director = new WorldDirector(builder);
        director.LoadWorld();
        director.CreateMap();
        director.SaveWorld();
    }
}
