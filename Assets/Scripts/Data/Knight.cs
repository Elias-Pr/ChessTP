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
            oppositPosValues = new int[]
            {
                -10, -5, -5, -5, -5, -5, -5, -10,
                -5, 0, 0, 0, 0, 0, 0, -5,
                -5, 0, 10, 10, 10, 10, 0, -5,
                -5, 5, 10, 20, 20, 10, 5, -5,
                -5, 0, 10, 20, 20, 10, 0, -5,
                -5, 5, 5, 10, 10, 5, 5, -5,
                -5, 0, 5, 5, 5, 5, 0, -5,
                -10, -5, -5, -5, -5, -5, -5, -10
            };

            positionalValues = new int[]
            {
                -10, -5, -5, -5, -5, -5, -5, -10,
                -5, 0, 5, 5, 5, 5, 0, -5,
                -5, 5, 5, 10, 10, 5, 5, -5,
                -5, 0, 10, 20, 20, 10, 0, -5,
                -5, 5, 10, 20, 20, 10, 5, -5,
                -5, 0, 10, 10, 10, 10, 0, -5,
                -5, 0, 0, 0, 0, 0, 0, -5,
                -10, -5, -5, -5, -5, -5, -5, -10
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