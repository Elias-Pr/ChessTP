using System.Collections.Generic;
using Core;
using Entities;
using UnityEngine;

namespace Data
{
    public class Pawn : Piece {
    
        public Pawn(GameObject prefab, PlayerColor playerColor, GameObject handler = null) : base(prefab, playerColor, handler)
        {
        }
    
        public override List<Vector2Int> PossibleMovements(ChessBoard board)
        {
            List<Vector2Int> possibleMoves = new List<Vector2Int>();
            
            for (int x = 0; x < 8; x++)
            {
                for (int z = 0; z < 8; z++)
                {
                    // Add each coordinate to the list of possible moves
                    possibleMoves.Add(new Vector2Int(x, z));
                }
            }

            return possibleMoves;

        }

        public override void ExecuteMove(ChessBoard board, Vector2Int vector2Int)
        {
            throw new System.NotImplementedException();
        }


        
    }
}