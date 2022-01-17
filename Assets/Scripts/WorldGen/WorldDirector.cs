using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class WorldDirector
{
    public WorldBuilder WorldBuilder;

    public WorldDirector(WorldBuilder builder)
    {
        this.WorldBuilder = builder;
    }

    public void CreateMap()
    {
        for (int i = -WorldBuilder.RenderDistance; i < WorldBuilder.RenderDistance + 1; i++)
        {
            for (int j = -WorldBuilder.RenderDistance; j < WorldBuilder.RenderDistance + 1; j++)
            {
                GameObject prefab = WorldBuilder.GetChunk(i, j);
                GameObject gameObject = WorldBuilder.InstanceChunk(prefab, i, j);
                WorldBuilder.AddChunk(i, j, gameObject);
            }
        }
    }

    public void SaveWorld()
    {
        string destination = Application.persistentDataPath + "/save.dat";
        FileStream file;

        if (File.Exists(destination)) file = File.OpenWrite(destination);
        else file = File.Create(destination);

        MapData data = new MapData(WorldBuilder.RenderDistance, WorldBuilder.ChunkSize);
        GameObject[][] map = WorldBuilder.GetMap();
        data.CopyChunks(map);
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(file, data);
        file.Close();
    }

    public void LoadWorld()
    {
        string destination = Application.persistentDataPath + "/save.dat";
        FileStream file;

        if (File.Exists(destination)) file = File.OpenRead(destination);
        else
        {
            Debug.LogError("File not found");
            return;
        }

        BinaryFormatter bf = new BinaryFormatter();
        MapData data = (MapData)bf.Deserialize(file);
        file.Close();

        WorldBuilder.SetMapData(data);
    }
}
