using System.Collections.Generic;
using Core;
using Entities;
using Managers;
using UnityEngine;

namespace Data
{
    public class King : Piece
    {
        public King(GameObject prefab, PlayerColor playerColor, GameObject handler = null) : base(prefab, playerColor, handler)
        {
        }

        public override List<Vector2Int> GetAvailableMoves()
        {
            Vector2Int position = GameManager.Instance.SelectedPiecePosition;

            List<Vector2Int> availableMoves = new List<Vector2Int>();

            // Define the eight possible directions a king can move (horizontal, vertical, and diagonal) with a distance of 1
            int[] xDirections = { 1, -1, 0, 0, 1, -1, 1, -1 };
            int[] yDirections = { 0, 0, 1, -1, 1, -1, -1, 1 };

            for (int i = 0; i < 8; i++)
            {
                int newX = position.x + xDirections[i];
                int newY = position.y + yDirections[i];

                if (IsWithinChessboardBounds(newX, newY))
                {
                    availableMoves.Add(new Vector2Int(newX, newY));
                }
            }

            return availableMoves;
        }

        private bool IsWithinChessboardBounds(int x, int y)
        {
            return x >= 0 && x <= 7 && y >= 0 && y <= 7;
        }

        // Check if the king is exposed to check from opponent's pieces
        public bool IsKingExposed()
        {
            PlayerColor opponentColor = (PlayerColor == PlayerColor.White) ? PlayerColor.Black : PlayerColor.White;
            List<Piece> opponentPieces = FindPiecesOfOpponent(opponentColor);

            Vector2Int kingPosition = GameManager.Instance.SelectedPiecePosition;

            foreach (Piece opponentPiece in opponentPieces)
            {
                List<Vector2Int> availableMoves = opponentPiece.GetAvailableMoves();

                if (availableMoves.Contains(kingPosition))
                {
                    return true; // King is exposed to check
                }
            }

            return false; // King is not exposed to check
        }

        private List<Piece> FindPiecesOfOpponent(PlayerColor opponentColor)
        {
            List<Piece> opponentPieces = new List<Piece>();

            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    if (ChessBoard.Matrix[x, y] != null && ChessBoard.Matrix[x, y].PlayerColor == opponentColor)
                    {
                        opponentPieces.Add(ChessBoard.Matrix[x, y]);
                    }
                }
            }

            return opponentPieces;
        }
    }
}
