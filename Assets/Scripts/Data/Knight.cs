using System.Collections.Generic;
using Core;
using Entities;
using UnityEngine;

namespace Data
{
    public class Knight : Piece
    {
        public Knight(GameObject prefab, PlayerColor playerColor) : base(prefab, playerColor) { }
        
        public override List<Vector2Int> PossibleMovements(ChessBoard board)
        {
            throw new System.NotImplementedException();
        }

        public override void ExecuteMove(ChessBoard board, Vector2Int vector2Int)
        {
            throw new System.NotImplementedException();
        }
    }
}