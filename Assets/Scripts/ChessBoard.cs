using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class ChessBoard : MonoBehaviour
{
    public List<GameObject> AllPieces;
    public static Dictionary<string, GameObject> PrefabsList;
    
    private const int _tileCountX = 8;
    private const int _tileCountZ = 8;
    
    
    //private const int _lockY = 0;
    
    
    private Pieces[,] _tiles;

    public GameObject TilePrefab;

    private void Awake()
    {
        PrefabsList = new();
        SetPrefabsList();
        TilesCreation(1, _tileCountX, _tileCountZ);
        PiecesCreation(1, _tileCountX, _tileCountZ);
    }

    private void TilesCreation(float tilesize, int tileCountX, int tileCountZ)
    {
        _tiles = new Pieces[tileCountX,tileCountZ];

        for (int x = 0; x < tileCountX; x++)
        {
            for (int z = 0; z < tileCountZ; z++)
            {
                GameObject prefab = TilePrefab;
                GameObject tile = Instantiate(prefab, new Vector3(x,0,z),Quaternion.identity,this.transform);

                //GameObject tile = Instantiate(TilePrefab, new Vector3(x, 0, z), Quaternion.identity, this.transform);
            }
        }
    }

    private void PiecesCreation(float tilesize, int tileCountX, int tileCountZ)
    {
        GameObject prefab = PrefabsList["BishopLight"];
        GameObject piece = Instantiate(prefab, new Vector3(3, 0, 3), Quaternion.identity, this.transform);
    }

    private void SetPrefabsList()
    {
        foreach (GameObject prefab in AllPieces)
        {
            PrefabsList.Add(prefab.name, prefab);
        }   
    }
}
