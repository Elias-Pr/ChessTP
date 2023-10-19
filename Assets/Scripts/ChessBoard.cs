using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessBoard : MonoBehaviour
{

    private int TileCountX = 8;
    private int TileCountY = 8;
    private GameObject[,] tiles;

    private void Awake()
    {
        TilesCreation(1, TileCountX, TileCountY);
    }

    private void TilesCreation(float tilesize, int tileCountX, int tileCountY)
    {
        tiles = new GameObject[tileCountX, tileCountY];
        for (int x = 0; x < tileCountX; x++)
            for (int y = 0; y < tileCountY; y++)
                tiles[x, y] = GenerateSingleTile(tilesize, x, y);
    }

    private GameObject GenerateSingleTile (float tilesize,int x, int y)
    {
        GameObject tileObject = new GameObject(string.Format("X:[0], Y:[1]", x, y));
        tileObject.transform.parent = transform;
        
        return tileObject;
    }
    
}
