using System.Collections.Generic;
using Core;
using Entities;
using Managers;
using UnityEngine;

namespace Data
{
    public class Queen : Piece
    {
        
        public Queen(GameObject prefab, PlayerColor playerColor, GameObject handler = null) : base(prefab, playerColor, handler)
        {
        }
    
        public override List<Vector2Int> GetAvailableMoves()
        {
            Vector2Int position = GameManager.Instance.SelectedPiecePosition;

            List<Vector2Int> availableMoves = new List<Vector2Int>();

            int[] xDirections = { 1, -1, 0, 0, 1, -1, 1, -1 };
            int[] yDirections = { 0, 0, 1, -1, 1, -1, -1, 1 };

            for (int i = 0; i < 8; i++)
            {
                for (int distance = 1; distance <= 7; distance++)
                {
                    int newX = position.x + xDirections[i] * distance;
                    int newY = position.y + yDirections[i] * distance;

                    Piece piece;
                    
                    if (!IsWithinChessboardBounds(newX, newY)) break;
                    
                    piece = ChessBoard.GetTile(newX, newY);

                    if (piece != null)
                    {
                        if (piece.PlayerColor == GameManager.Instance.Opponent)
                        {
                            availableMoves.Add(new Vector2Int(newX, newY));
                        }
                        break;
                    }

                    if (ChessBoard.GetTile(newX,newY) == null)
                    {
                        Debug.Log(position);
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