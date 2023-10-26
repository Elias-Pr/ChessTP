using System.Collections.Generic;
using Core;
using Entities;
using UnityEngine;

namespace Data
{
    public abstract class Piece {

        public GameObject Prefab;
        public PlayerColor PlayerColor;

        protected Piece(GameObject prefab, PlayerColor playerColor) {
            Prefab = prefab;
            PlayerColor = playerColor;
        }

        //ToRemove
        public virtual List<Vector2Int> GetAvailableMoves()
        {
            List<Vector2Int> availableMoves = new List<Vector2Int>
            {
                new (2,0), new (2,1), new (2,2), new (2,3), new (2,4), new (2,5), new (2,6), new (2,7),
                new (3,0), new (3,1), new (3,2), new (3,3), new (3,4), new (3,5), new (3,6), new (3,7),
                new (4,0), new (4,1), new (4,2), new (4,3), new (4,4), new (4,5), new (4,6), new (4,7),
                new (5,0), new (5,1), new (5,2), new (5,3), new (5,4), new (5,5), new (5,6), new (5,7)
            };

            return availableMoves;
        }
        
        public abstract List<Vector2Int> PossibleMovements(ChessBoard board);
        public abstract void ExecuteMove(ChessBoard board, Vector2Int vector2Int);

    }
}