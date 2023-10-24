using System;
using System.Collections.Generic;
using Core;
using Data;
using Managers;
using Shame;
using UnityEngine;
using Object = System.Object;

namespace Entities
{
    public class ChessBoard : MonoBehaviour
    {
        List<GameObject> AllPieces;
        public static Dictionary<string, GameObject> PrefabsList;
    
        private const int _tileCountX = 8;
        private const int _tileCountZ = 8;
    
    
        //private const int _lockY = 0;
        [SerializeField] private GameObject WhitePawnPrefab;
        [SerializeField] private GameObject WhiteRookPrefab;
        [SerializeField] private GameObject WhiteKnightPrefab;
        [SerializeField] private GameObject WhiteBishopPrefab;
        [SerializeField] private GameObject WhiteKingPrefab;
        [SerializeField] private GameObject WhiteQueenPrefab;
    
        [SerializeField] private GameObject BlackPawnPrefab;
        [SerializeField] private GameObject BlackRookPrefab;
        [SerializeField] private GameObject BlackKnightPrefab;
        [SerializeField] private GameObject BlackBishopPrefab;
        [SerializeField] private GameObject BlackKingPrefab;
        [SerializeField] private GameObject BlackQueenPrefab;
    
        //...
    
        private Piece[,] _matrix;

        public GameObject TilePrefab;

        private void Awake()
        {
            InitMatrix();
            DisplayMatrix();
            // PrefabsList = new();
            // SetPrefabsList();
            // TilesCreation(1, _tileCountX, _tileCountZ);
            // PiecesCreation(1, _tileCountX, _tileCountZ);
        }

        private void Start()
        {
            Debug.Log(GameManager.Instance.toto);
        }

        private void InitMatrix() {
            _matrix = new Piece[,] {
                { new Rook(WhiteRookPrefab, PlayerColor.White), new Knight(WhiteKnightPrefab, PlayerColor.White), new Bishop(WhiteBishopPrefab, PlayerColor.White), new King(WhiteKingPrefab, PlayerColor.White), new Queen(WhiteQueenPrefab, PlayerColor.White), new Bishop(WhiteBishopPrefab,PlayerColor.White), new Knight(WhiteKnightPrefab,PlayerColor.White), new Rook(WhiteRookPrefab,PlayerColor.White) },
                { new Pawn(WhitePawnPrefab, PlayerColor.White), new Pawn(WhitePawnPrefab, PlayerColor.White), new Pawn(WhitePawnPrefab, PlayerColor.White), new Pawn(WhitePawnPrefab, PlayerColor.White), new Pawn(WhitePawnPrefab, PlayerColor.White), new Pawn(WhitePawnPrefab, PlayerColor.White), new Pawn(WhitePawnPrefab, PlayerColor.White), new Pawn(WhitePawnPrefab, PlayerColor.White) },
                { null, null, null, null, null, null, null, null },
                { null, null, null, null, null, null, null, null },
                { null, null, null, null, null, null, null, null },
                { null, null, null, null, null, null, null, null },
                { new Pawn(BlackPawnPrefab, PlayerColor.Black), new Pawn(BlackPawnPrefab, PlayerColor.Black), new Pawn(BlackPawnPrefab, PlayerColor.Black), new Pawn(BlackPawnPrefab, PlayerColor.Black), new Pawn(BlackPawnPrefab, PlayerColor.Black), new Pawn(BlackPawnPrefab, PlayerColor.Black), new Pawn(BlackPawnPrefab, PlayerColor.Black), new Pawn(BlackPawnPrefab, PlayerColor.Black) },
                { new Rook(BlackRookPrefab, PlayerColor.Black), new Knight(BlackKnightPrefab, PlayerColor.Black), new Bishop(BlackBishopPrefab, PlayerColor.Black), new King(BlackKingPrefab, PlayerColor.Black), new Queen(BlackQueenPrefab, PlayerColor.Black), new Bishop(BlackBishopPrefab, PlayerColor.Black), new Knight(BlackKnightPrefab, PlayerColor.Black), new Rook(BlackRookPrefab, PlayerColor.Black) }
            };
        }

        private void DisplayMatrix() {
            // Destroy all current pieces
            GameObject.FindObjectsOfType<PieceHandler>();
            /*foreach (Piece piece in _matrix)
            {
                if (piece!=null)
                {
                    DestroyImmediate(piece.Prefab, true);
                }
            }*/
            
            // Instantiate all pieces
            
            for (int x = 0; x < 8; x++) {
                for (int z = 0; z < 8; z++)
                {
                    if (_matrix[x, z] != null) {
                        Vector3 position = new Vector3(x , 0, z );
                        Instantiate(_matrix[x, z].Prefab, position, Quaternion.identity, transform);
                    }
                }
            }
        }

        

        private void Update()
        {
            /*if (PieceHandler.SelectedPiece && Tiles.SelectedTile)
            {
                PieceHandler.pieceTransform.position = Tiles.tileTransform.position;
                Debug.Log("je bouge");
                PieceHandler.SelectedPiece = false;
                Tiles.SelectedTile = false;
            }*/
        }

        /*private void SetPrefabsList()
        {
            foreach (GameObject prefab in AllPieces)
            {
                PrefabsList.Add(prefab.name, prefab);
            }   
        }*/
    
        /*private void PiecesCreation(float tilesize, int tileCountX, int tileCountZ)
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
                
    }*/
    
    }
}


