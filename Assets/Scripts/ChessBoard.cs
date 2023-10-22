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
        GameObject prefabPL = PrefabsList["PawnLight"];
        GameObject prefabBL = PrefabsList["BishopLight"];
        GameObject prefabKL = PrefabsList["KnightLight"];
        GameObject prefabRL = PrefabsList["RookLight"];
        GameObject prefabQueenL = PrefabsList["QueenLight"];
        GameObject prefabKingL = PrefabsList["KingLight"];

        GameObject PawnL0 = Instantiate(prefabPL, new Vector3(0, 0, 1), Quaternion.identity, this.transform);
        GameObject PawnL1 = Instantiate(prefabPL, new Vector3(1, 0, 1), Quaternion.identity, this.transform);
        GameObject PawnL2 = Instantiate(prefabPL, new Vector3(2, 0, 1), Quaternion.identity, this.transform);
        GameObject PawnL3 = Instantiate(prefabPL, new Vector3(3, 0, 1), Quaternion.identity, this.transform);
        GameObject PawnL4 = Instantiate(prefabPL, new Vector3(4, 0, 1), Quaternion.identity, this.transform);
        GameObject PawnL5 = Instantiate(prefabPL, new Vector3(5, 0, 1), Quaternion.identity, this.transform);
        GameObject PawnL6 = Instantiate(prefabPL, new Vector3(6, 0, 1), Quaternion.identity, this.transform);
        GameObject PawnL7 = Instantiate(prefabPL, new Vector3(7, 0, 1), Quaternion.identity, this.transform);
        GameObject BishopL1 = Instantiate(prefabBL, new Vector3(2, 0, 0), Quaternion.identity, this.transform);
        GameObject BishopL2 = Instantiate(prefabBL, new Vector3(5, 0, 0), Quaternion.identity, this.transform);
        GameObject KnightL1 = Instantiate(prefabKL, new Vector3(1, 0, 0), Quaternion.identity, this.transform);
        GameObject KnightL2 = Instantiate(prefabKL, new Vector3(6, 0, 0), Quaternion.identity, this.transform);
        GameObject RookL1 = Instantiate(prefabRL, new Vector3(0, 0, 0), Quaternion.identity, this.transform);
        GameObject RookL2 = Instantiate(prefabRL, new Vector3(7, 0, 0), Quaternion.identity, this.transform);
        GameObject QueenL = Instantiate(prefabQueenL, new Vector3(3, 0, 0), Quaternion.identity, this.transform);
        GameObject KingL = Instantiate(prefabKingL, new Vector3(4, 0, 0), Quaternion.identity, this.transform);
        
        GameObject prefabPD = PrefabsList["PawnDark"];
        GameObject prefabBD = PrefabsList["BishopDark"];
        GameObject prefabKD = PrefabsList["KnightDark"];
        GameObject prefabRD = PrefabsList["RookDark"];
        GameObject prefabQueenD = PrefabsList["QueenDark"];
        GameObject prefabKingD = PrefabsList["KingDark"];
        
        GameObject PawnD0 = Instantiate(prefabPD, new Vector3(0, 0, 6), Quaternion.Euler(0,180,0), this.transform);
        GameObject PawnD1 = Instantiate(prefabPD, new Vector3(1, 0, 6), Quaternion.Euler(0,180,0), this.transform);
        GameObject PawnD2 = Instantiate(prefabPD, new Vector3(2, 0, 6), Quaternion.Euler(0,180,0), this.transform);
        GameObject PawnD3 = Instantiate(prefabPD, new Vector3(3, 0, 6), Quaternion.Euler(0,180,0), this.transform);
        GameObject PawnD4 = Instantiate(prefabPD, new Vector3(4, 0, 6), Quaternion.Euler(0,180,0), this.transform);
        GameObject PawnD5 = Instantiate(prefabPD, new Vector3(5, 0, 6), Quaternion.Euler(0,180,0), this.transform);
        GameObject PawnD6 = Instantiate(prefabPD, new Vector3(6, 0, 6), Quaternion.Euler(0,180,0), this.transform);
        GameObject PawnD7 = Instantiate(prefabPD, new Vector3(7, 0, 6), Quaternion.Euler(0,180,0), this.transform);
        GameObject BishopD1 = Instantiate(prefabBD, new Vector3(2, 0,7), Quaternion.Euler(0,180,0), this.transform);
        GameObject BishopD2 = Instantiate(prefabBD, new Vector3(5, 0,7), Quaternion.Euler(0,180,0), this.transform);
        GameObject KnightD1 = Instantiate(prefabKD, new Vector3(1, 0,7), Quaternion.Euler(0,180,0), this.transform);
        GameObject KnightD2 = Instantiate(prefabKD, new Vector3(6, 0,7), Quaternion.Euler(0,180,0), this.transform);
        GameObject RookD1 = Instantiate(prefabRD, new Vector3(0, 0,7), Quaternion.Euler(0,180,0), this.transform);
        GameObject RookD2 = Instantiate(prefabRD, new Vector3(7, 0,7), Quaternion.Euler(0,180,0), this.transform);
        GameObject QueenD = Instantiate(prefabQueenD, new Vector3(3, 0,7), Quaternion.Euler(0,180,0), this.transform);
        GameObject KingD = Instantiate(prefabKingD, new Vector3(4, 0,7), Quaternion.Euler(0,180,0), this.transform);
                
    }

    private void Update()
    {
        if (Pieces.SelectedPiece && Tiles.SelectedTile)
        {
            Pieces.pieceTransform.position = Tiles.tileTransform.position;
            Debug.Log("je bouge");
            Pieces.SelectedPiece = false;
            Tiles.SelectedTile = false;
        }
    }

    private void SetPrefabsList()
    {
        foreach (GameObject prefab in AllPieces)
        {
            PrefabsList.Add(prefab.name, prefab);
        }   
    }
}
