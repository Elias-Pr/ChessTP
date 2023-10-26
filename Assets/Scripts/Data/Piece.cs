using System.Collections.Generic;
using Core;
using Entities;
using UnityEngine;

namespace Data
{
    public abstract class Piece {
        
        public GameObject Behaviour { get; set; }
        public GameObject Prefab;
        public PlayerColor PlayerColor;

        protected Piece(GameObject prefab, PlayerColor playerColor, GameObject handler = null)
        {
            Behaviour = handler;
            Prefab = prefab;
            PlayerColor = playerColor;
        }

        //ToRemove
        public virtual List<Vector2Int> GetAvailableMoves()
        {
            List<Vector2Int> availableMoves = new List<Vector2Int>
            {
                new (0,0), new (0,1), new (0,2), new (0,3), new (0,4), new (0,5), new (0,6), new (0,7),
                new (1,0), new (1,1), new (1,2), new (1,3), new (1,4), new (1,5), new (1,6), new (1,7),
                new (2,0), new (2,1), new (2,2), new (2,3), new (2,4), new (2,5), new (2,6), new (2,7),
                new (3,0), new (3,1), new (3,2), new (3,3), new (3,4), new (3,5), new (3,6), new (3,7),
                new (4,0), new (4,1), new (4,2), new (4,3), new (4,4), new (4,5), new (4,6), new (4,7),
                new (5,0), new (5,1), new (5,2), new (5,3), new (5,4), new (5,5), new (5,6), new (5,7),
                new (6,0), new (6,1), new (6,2), new (6,3), new (6,4), new (6,5), new (6,6), new (6,7),
                new (7,0), new (7,1), new (7,2), new (7,3), new (7,4), new (7,5), new (7,6), new (7,7)
            };

            return availableMoves;
        }
        
        public abstract List<Vector2Int> PossibleMovements(ChessBoard board);
        public abstract void ExecuteMove(ChessBoard board, Vector2Int vector2Int);

    }
}