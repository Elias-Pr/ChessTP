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

        public abstract void PossibleMovements(ChessBoard board);
        public abstract void ExecuteMove(ChessBoard board, Vector2Int vector2Int);

    }
}