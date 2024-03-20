using System.Collections.Generic;
using Core;
using Entities;
using Managers;
using UnityEngine;

namespace Data
{
    public class Knight : Piece
    {
        public Knight(GameObject prefab, PlayerColor playerColor, GameObject handler = null) : base(prefab, playerColor, handler)
        {
            positionalValues = new int[]
            {
                -200, -100, -50, -50, -50, -50, -100, -200,
                -100, 0, 0, 0, 0, 0, 0, -100,
                -50, 0, 60, 60, 60, 60, 0, -50,
                -50, 0, 30, 60, 60, 30, 0, -50,
                -50, 0, 30, 60, 60, 30, 0, -50,
                -50, 0, 30, 30, 30, 30, 0, -50,
                -100, 0, 0, 0, 0, 0, 0, -100,
                -200, -50, -25, -25, -25, -25, -50, -200
            };
        }

        public override int Score => 3;

        public override List<Vector2Int> GetAvailableMoves(Vector2Int position)
        {
            //Vector2Int position = GameManager.Instance.SelectedPiecePosition;

            List<Vector2Int> availableMoves = new List<Vector2Int>();

            int[] xDirections = { 2, 2, -2, -2, 1, 1, -1, -1 };
            int[] yDirections = { 1, -1, 1, -1, 2, -2, 2, -2 };

            for (int i = 0; i < 8; i++)
            {
                int newX = position.x + xDirections[i];
                int newY = position.y + yDirections[i];

                if (IsWithinChessboardBounds(newX, newY))
                {
                    Piece piece = ChessBoard.GetTile(newX, newY);

                    if (piece == null || piece.PlayerColor == GameManager.Instance.Opponent)
                    {
                        availableMoves.Add(new Vector2Int(newX, newY));
                    }
                }
            }

            return availableMoves;
        
        }
        
        private bool IsWithinChessboardBounds(int x, int y)
        {
            return x >= 0 && x <= 7 && y >= 0 && y <= 7;
        }

    }
}