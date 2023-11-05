using System.Collections.Generic;
using Core;
using Managers;
using UnityEngine;

namespace Data
{
    public class Pawn : Piece
    {
        public Pawn(GameObject prefab, PlayerColor playerColor, GameObject handler = null) : base(prefab, playerColor, handler)
        {
        }

        public override List<Vector2Int> GetAvailableMoves()
        {
            Vector2Int position = GameManager.Instance.SelectedPiecePosition;
    
            List<Vector2Int> availableMoves = new List<Vector2Int>();

            int forwardDirection = (PlayerColor == PlayerColor.White) ? 1 : -1;

            // Pawn can move forward one square
            int newX = position.x + forwardDirection;
            int newY = position.y;
            
            if (IsWithinChessboardBounds(newX, newY))
            {
                availableMoves.Add(new Vector2Int(newX, newY));
            }

            // Pawn can make a double move on its first turn
            if ((PlayerColor == PlayerColor.White && position.x == 1) || (PlayerColor == PlayerColor.Black && position.x == 6))
            {
                int doubleMoveX = position.x + 2 * forwardDirection;
                if (IsWithinChessboardBounds(doubleMoveX, newY))
                {
                    availableMoves.Add(new Vector2Int(doubleMoveX, newY));
                }
            }

            // Pawn can capture diagonally
            int[] captureYDirections = { -1, 1 };
            
            foreach (int captureDirection in captureYDirections)
            {
                int captureX = position.x + forwardDirection;
                int captureY = position.y + captureDirection;
                
                if (IsWithinChessboardBounds(captureX, captureY))
                {
                    availableMoves.Add(new Vector2Int(captureX, captureY));
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
