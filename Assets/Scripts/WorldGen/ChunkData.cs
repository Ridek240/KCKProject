using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ChunkData
{
    public int GlobalX;
    public int GlobalY;
    public string Type;
    public ChunkData(int x, int y, string type)
    {
        GlobalX = x;
        GlobalY = y;
        Type = type;
    }
}
