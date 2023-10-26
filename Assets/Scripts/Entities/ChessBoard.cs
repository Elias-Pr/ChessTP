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
    
        private static Piece[,] _matrix;

        public static Piece[,] Matrix => _matrix;

        //private GameObject[,] _tileMatrix;

        public GameObject TilePrefab;

        public static GameObject TilePrefabStatic;


        public static Transform TileParentStatic;
        

        public Transform PieceParent;

        public Transform TileParent;
        
        

        private void Awake()
        {
            TilePrefabStatic = TilePrefab;
            TileParentStatic = TileParent;
            
            InitMatrix();
            DisplayMatrix();
        }

        private void Start()
        {
            //Debug.Log(GameManager.Instance.toto);
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
            List<PieceHandler> Childrens = new List<PieceHandler>(FindObjectsOfType<PieceHandler>());
            foreach (PieceHandler handler in Childrens)
            {
                if (handler!=null)
                {
                    Destroy(handler.gameObject);
                }
            }
            
            // Instantiate all pieces
            
            for (int x = 0; x < 8; x++) {
                for (int z = 0; z < 8; z++)
                {
                    if (_matrix[x, z] != null) {
                        Vector3 position = new Vector3(x , 0, z );
                        _matrix[x,z].Behaviour = Instantiate(_matrix[x, z].Prefab, position, Quaternion.identity, PieceParent);
                        
                    }
                }
            }
        }

        /*private void InitTileMatrix(List<Vector2Int> availableMoves)
        {
            
            _tileMatrix = new GameObject[_tileCountX, _tileCountZ];
            
            DestroyOldTile();
            

            foreach (Vector2Int move in availableMoves)
            {
                Vector3 pos = new Vector3(move.x, 0, move.y);
                _tileMatrix[move.x, move.y] = Instantiate(TilePrefab, pos, Quaternion.identity, TileParent);
            }

        }*/


        public static void GenerateTiles(List<Vector2Int> tilesPosition)
        {
            foreach (Vector2Int item in tilesPosition)
            {
                Vector3 worldPosition = new Vector3(item.x, 0, item.y);
                Instantiate(TilePrefabStatic, worldPosition, Quaternion.identity, TileParentStatic);
            }
        }


        private void DestroyOldTile()
        {
            List<TileHandler> tiles = new List<TileHandler>(TileParent.GetComponentsInChildren<TileHandler>());

            foreach (TileHandler tileToDestroy in tiles)
            {
                Destroy(tileToDestroy.gameObject);
            }
        }



        private void Update()
        {
             
        }

        /*private void SetPrefabsList()
        {
            foreach (GameObject prefab in AllPieces)
            {
                PrefabsList.Add(prefab.name, prefab);
            }   
        }*/
        
    
    }
}


