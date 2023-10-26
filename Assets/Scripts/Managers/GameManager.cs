using System.Collections.Generic;
using Core;
using Data;
using Entities;
using UnityEngine;
using UnityEngine.UIElements;

namespace Managers {
    public class GameManager : MonoBehaviourSingleton<GameManager> {

        //public int a;
        //public string toto;
        
        private static Piece SelectedPiece;
        private static Vector2Int SelectedTile;
        public static bool PieceIsSelected;
        public static bool TileIsSelected;
        private static Vector2Int SelectedPiecePosition;

        public static void SelectPiece(Transform piece)
        {
            SelectedPiecePosition = new Vector2Int((int)piece.position.x, (int)piece.position.z);

            SelectedPiece = ChessBoard.Matrix[SelectedPiecePosition.x, SelectedPiecePosition.y];
            
            Debug.Log("I am a selected Piece at " + SelectedPiecePosition.x + SelectedPiecePosition.y + " !");

            PieceIsSelected = true;

            List<Vector2Int> availableMoves = SelectedPiece.GetAvailableMoves();
            
            ChessBoard.GenerateTiles(availableMoves);
        }

        public static void SelectTile(Transform tile)
        {
            Vector2Int position = new Vector2Int((int)tile.position.x, (int)tile.position.z);

            if (SelectedPiece == null) return;

            SelectedTile = position;
            
            Debug.Log("I am a selected Tile at " + position.x + position.y + " !");

            TileIsSelected = true;

            if (PieceIsSelected && TileIsSelected) Move();
        }
        
        private static void Move()
        {
            if (SelectedPiece != null)
            {
                ChessBoard.Matrix[SelectedPiecePosition.x, SelectedPiecePosition.y] = null;
                ChessBoard.Matrix[SelectedTile.x, SelectedTile.y] = SelectedPiece;

                Vector3 newPosition = new Vector3(SelectedTile.x,0,SelectedTile.y);
                SelectedPiece.Behaviour.transform.position = newPosition;
                    
                PieceIsSelected = false;
                TileIsSelected = false;

                Debug.Log("Piece moved to " + SelectedTile.x + ", " + SelectedTile.y);
            }
            else
            {
                    Debug.Log("Invalid move!");
            }
        }
    }
}
