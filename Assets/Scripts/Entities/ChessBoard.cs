using System.Collections.Generic;
using Core;
using Data;
using Tile;
using UnityEngine;



namespace Entities
{
    public class ChessBoard : MonoBehaviour
    {
        private List<GameObject> _allPieces;

        [SerializeField] private GameObject whitePawnPrefab;
        [SerializeField] private GameObject whiteRookPrefab;
        [SerializeField] private GameObject whiteKnightPrefab;
        [SerializeField] private GameObject whiteBishopPrefab;
        [SerializeField] private GameObject whiteKingPrefab;
        [SerializeField] private GameObject whiteQueenPrefab;
    
        [SerializeField] private GameObject blackPawnPrefab;
        [SerializeField] private GameObject blackRookPrefab;
        [SerializeField] private GameObject blackKnightPrefab;
        [SerializeField] private GameObject blackBishopPrefab;
        [SerializeField] private GameObject blackKingPrefab;
        [SerializeField] private GameObject blackQueenPrefab;
    
        
    
        private static Piece[,] _matrix;

        public static Piece[,] Matrix => _matrix;

        public GameObject tilePrefab;

        public Transform pieceParent;

        public Transform tileParent;

        private static Transform _pieceParent;

        private static Transform _tileParent;
        
        

        private void Awake()
        {
            _pieceParent = pieceParent;
            _tileParent = tileParent;
            
            InitMatrix();
            InitAllPiecesBehaviours();
        }

        private void InitMatrix() {
            _matrix = new Piece[,] {
                { new Rook(whiteRookPrefab, PlayerColor.White), new Knight(whiteKnightPrefab, PlayerColor.White), new Bishop(whiteBishopPrefab, PlayerColor.White), new King(whiteKingPrefab, PlayerColor.White), new Queen(whiteQueenPrefab, PlayerColor.White), new Bishop(whiteBishopPrefab,PlayerColor.White), new Knight(whiteKnightPrefab,PlayerColor.White), new Rook(whiteRookPrefab,PlayerColor.White) },
                { new Pawn(whitePawnPrefab, PlayerColor.White), new Pawn(whitePawnPrefab, PlayerColor.White), new Pawn(whitePawnPrefab, PlayerColor.White), new Pawn(whitePawnPrefab, PlayerColor.White), new Pawn(whitePawnPrefab, PlayerColor.White), new Pawn(whitePawnPrefab, PlayerColor.White), new Pawn(whitePawnPrefab, PlayerColor.White), new Pawn(whitePawnPrefab, PlayerColor.White) },
                { null, null, null, null, null, null, null, null },
                { null, null, null, null, null, null, null, null },
                { null, null, null, null, null, null, null, null },
                { null, null, null, null, null, null, null, null },
                { new Pawn(blackPawnPrefab, PlayerColor.Black), new Pawn(blackPawnPrefab, PlayerColor.Black), new Pawn(blackPawnPrefab, PlayerColor.Black), new Pawn(blackPawnPrefab, PlayerColor.Black), new Pawn(blackPawnPrefab, PlayerColor.Black), new Pawn(blackPawnPrefab, PlayerColor.Black), new Pawn(blackPawnPrefab, PlayerColor.Black), new Pawn(blackPawnPrefab, PlayerColor.Black) },
                { new Rook(blackRookPrefab, PlayerColor.Black), new Knight(blackKnightPrefab, PlayerColor.Black), new Bishop(blackBishopPrefab, PlayerColor.Black), new King(blackKingPrefab, PlayerColor.Black), new Queen(blackQueenPrefab, PlayerColor.Black), new Bishop(blackBishopPrefab, PlayerColor.Black), new Knight(blackKnightPrefab, PlayerColor.Black), new Rook(blackRookPrefab, PlayerColor.Black) }
            };
        }

        private void InitAllPiecesBehaviours()
        {
            for (int x = 0; x < 8; x++) {
                for (int z = 0; z < 8; z++)
                {
                    if (_matrix[x, z] == null) continue;
                    
                    Vector3 position = new Vector3(x , 0, z );
                    _matrix[x,z].Behaviour = Instantiate(_matrix[x, z].Prefab, position, Quaternion.identity, _pieceParent);

                }
            }
        }

        private void DestroyAllPiece()
        {
            List<PieceHandler> children = new List<PieceHandler>(_pieceParent.GetComponentsInChildren<PieceHandler>());
            foreach (PieceHandler handler in children)
            {
                if (handler!=null)
                {
                    Destroy(handler.gameObject);
                }
            }
        }
        
        public static void GenerateTiles(List<Vector2Int> tilesPosition)
        {
            DestroyOldTiles();
            foreach (Vector2Int item in tilesPosition)
            {
                Vector3 worldPosition = new Vector3(item.x, 0, item.y);
                Instantiate(_tileParent, worldPosition, Quaternion.identity, _tileParent);
            }
        }

        private static void DestroyOldTiles()
        {
            List<TileHandler> children = new List<TileHandler>(_tileParent.GetComponentsInChildren<TileHandler>());
            foreach (TileHandler handler in children)
            {
                if (handler!=null)
                {
                    Destroy(handler.gameObject);
                }
            }
        }
        
        


    }
}