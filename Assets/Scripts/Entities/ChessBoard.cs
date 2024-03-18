using System.Collections.Generic;
using Core;
using Data;
using Tile;
using UnityEngine;

namespace Entities
{
    public class ChessBoard : MonoBehaviour
    {
        private static GameObject _tilePrefab;

        private static Transform _pieceParent;

        private static Transform _tileParent;

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

        public GameObject tilePrefab;

        public Transform pieceParent;

        public Transform tileParent;
        private List<GameObject> _allPieces;
        public static Piece[,] Matrix { get; set; }
        
        


        private void Awake()
        {
            _pieceParent = pieceParent;
            _tileParent = tileParent;
            _tilePrefab = tilePrefab;

            // BaseMatrix();
            TestMatrix();
            InitAllPiecesBehaviours();
        }

        private void BaseMatrix()
        {
            Matrix = new Piece[,]
            {
                {
                    new Rook(whiteRookPrefab, PlayerColor.White), new Knight(whiteKnightPrefab, PlayerColor.White),
                    new Bishop(whiteBishopPrefab, PlayerColor.White), new King(whiteKingPrefab, PlayerColor.White),
                    new Queen(whiteQueenPrefab, PlayerColor.White), new Bishop(whiteBishopPrefab, PlayerColor.White),
                    new Knight(whiteKnightPrefab, PlayerColor.White), new Rook(whiteRookPrefab, PlayerColor.White)
                },
                {
                    new Pawn(whitePawnPrefab, PlayerColor.White), new Pawn(whitePawnPrefab, PlayerColor.White),
                    new Pawn(whitePawnPrefab, PlayerColor.White), new Pawn(whitePawnPrefab, PlayerColor.White),
                    new Pawn(whitePawnPrefab, PlayerColor.White), new Pawn(whitePawnPrefab, PlayerColor.White),
                    new Pawn(whitePawnPrefab, PlayerColor.White), new Pawn(whitePawnPrefab, PlayerColor.White)
                },
                { null, null, null, null, null, null, null, null },
                { null, null, null, null, null, null, null, null },
                { null, null, null, null, null, null, null, null },
                { null, null, null, null, null, null, null, null },
                {
                    new Pawn(blackPawnPrefab, PlayerColor.Black), new Pawn(blackPawnPrefab, PlayerColor.Black),
                    new Pawn(blackPawnPrefab, PlayerColor.Black), new Pawn(blackPawnPrefab, PlayerColor.Black),
                    new Pawn(blackPawnPrefab, PlayerColor.Black), new Pawn(blackPawnPrefab, PlayerColor.Black),
                    new Pawn(blackPawnPrefab, PlayerColor.Black), new Pawn(blackPawnPrefab, PlayerColor.Black)
                },
                {
                    new Rook(blackRookPrefab, PlayerColor.Black), new Knight(blackKnightPrefab, PlayerColor.Black),
                    new Bishop(blackBishopPrefab, PlayerColor.Black), new King(blackKingPrefab, PlayerColor.Black),
                    new Queen(blackQueenPrefab, PlayerColor.Black), new Bishop(blackBishopPrefab, PlayerColor.Black),
                    new Knight(blackKnightPrefab, PlayerColor.Black), new Rook(blackRookPrefab, PlayerColor.Black)
                }
            };
        }
        
        private void TestMatrix()
        {
            Matrix = new Piece[,]
            {
                {
                    new Rook(whiteRookPrefab, PlayerColor.White), new Knight(whiteKnightPrefab, PlayerColor.White),
                    new Bishop(whiteBishopPrefab, PlayerColor.White), new King(whiteKingPrefab, PlayerColor.White),
                    new Queen(whiteQueenPrefab, PlayerColor.White), new Bishop(whiteBishopPrefab, PlayerColor.White),
                    new Knight(whiteKnightPrefab, PlayerColor.White), new Rook(whiteRookPrefab, PlayerColor.White)
                },
                {
                    new Pawn(whitePawnPrefab, PlayerColor.White), new Pawn(whitePawnPrefab, PlayerColor.White),
                    new Pawn(whitePawnPrefab, PlayerColor.White), new Pawn(whitePawnPrefab, PlayerColor.White),
                    new Pawn(whitePawnPrefab, PlayerColor.White), new Pawn(whitePawnPrefab, PlayerColor.White),
                    new Pawn(whitePawnPrefab, PlayerColor.White), new Pawn(whitePawnPrefab, PlayerColor.White)
                },
                { null, null, null, null, null, null, null, null },
                { null, null, null, null, null, null, null, null },
                { null, null, null, null, null, null, null, null },
                { null, null, null, null, null, null, null, null },
                {
                    new Pawn(blackPawnPrefab, PlayerColor.Black), new Pawn(blackPawnPrefab, PlayerColor.Black),
                    new Pawn(blackPawnPrefab, PlayerColor.Black), new Pawn(blackPawnPrefab, PlayerColor.Black),
                    new Pawn(blackPawnPrefab, PlayerColor.Black), new Pawn(blackPawnPrefab, PlayerColor.Black),
                    new Pawn(blackPawnPrefab, PlayerColor.Black), new Pawn(blackPawnPrefab, PlayerColor.Black)
                },
                {
                    new Rook(blackRookPrefab, PlayerColor.Black), new Knight(blackKnightPrefab, PlayerColor.Black),
                    new Bishop(blackBishopPrefab, PlayerColor.Black), new King(blackKingPrefab, PlayerColor.Black),
                    new Queen(blackQueenPrefab, PlayerColor.Black), new Bishop(blackBishopPrefab, PlayerColor.Black),
                    new Knight(blackKnightPrefab, PlayerColor.Black), new Rook(blackRookPrefab, PlayerColor.Black)
                }
            };
        }

        private void InitAllPiecesBehaviours()
        {
            for (var x = 0; x < 8; x++)
            for (var z = 0; z < 8; z++)
            {
                if (Matrix[x, z] == null) continue;

                var position = new Vector3(x, 0, z);
                Matrix[x, z].Behaviour = Instantiate(Matrix[x, z].Prefab, position, Quaternion.identity, _pieceParent);
            }
        }

        private void DestroyAllPiece()
        {
            var children = new List<PieceHandler>(_pieceParent.GetComponentsInChildren<PieceHandler>());
            foreach (var handler in children)
                if (handler != null)
                    Destroy(handler.gameObject);
        }

        public static void GenerateTiles(List<Vector2Int> tilesPosition)
        {
            DestroyOldTiles();
            foreach (var item in tilesPosition)
            {
                var worldPosition = new Vector3(item.x, 0, item.y);
                Instantiate(_tilePrefab, worldPosition, Quaternion.identity, _tileParent);
            }
        }

        public static void DestroyOldTiles()
        {
            var children = new List<TileHandler>(_tileParent.GetComponentsInChildren<TileHandler>());
            foreach (var handler in children)
                if (handler != null)
                    Destroy(handler.gameObject);
        }


        public static Piece GetTile(Vector2Int coordinates)
        {
            var col = coordinates.x;
            var row = coordinates.y;

            return Matrix[col, row];
        }

        public static Piece GetTile(int col, int row)
        {
            return Matrix[col, row];
        }
    }
}