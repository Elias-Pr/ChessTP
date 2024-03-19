using System.Collections.Generic;
using Core;
using Entities;
using Managers;
using UnityEngine;

namespace Data
{
    public class Pawn : Piece
    {
        
        public Pawn(GameObject prefab, PlayerColor playerColor, GameObject handler = null) : base(prefab, playerColor, handler)
        {
        }

        public override int Score => 1;

        public override List<Vector2Int> GetAvailableMoves(Vector2Int position)
        {
            //Vector2Int position = GameManager.Instance.SelectedPiecePosition;
    
            List<Vector2Int> availableMoves = new List<Vector2Int>();

            int forwardDirection = (PlayerColor == PlayerColor.White) ? 1 : -1;

            int newX = position.x + forwardDirection;
            int newY = position.y;
            
            if (IsWithinChessboardBounds(newX, newY))
            {
                availableMoves.Add(new Vector2Int(newX, newY));
            }

            if ((PlayerColor == PlayerColor.White && position.x == 1) || (PlayerColor == PlayerColor.Black && position.x == 6))
            {
                int doubleMoveX = position.x + 2 * forwardDirection;
                if (IsWithinChessboardBounds(doubleMoveX, newY))
                {
                    availableMoves.Add(new Vector2Int(doubleMoveX, newY));
                }
            }

            int[] captureYDirections = { -1, 1 };
            
            foreach (int captureDirection in captureYDirections)
            {
                int captureX = position.x + forwardDirection;
                int captureY = position.y + captureDirection;

                if (IsWithinChessboardBounds(captureX, captureY) && !GameManager.Instance.IsPositionEmpty(captureX, captureY))
                {
                    Piece pieceToCapture = ChessBoard.Matrix[captureX, captureY];
                    if (pieceToCapture != null && pieceToCapture.PlayerColor != PlayerColor)
                    {
                        availableMoves.Add(new Vector2Int(captureX, captureY));
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
