using System.Collections.Generic;
using Core;
using Entities;
using UnityEngine;

namespace Data
{
    public abstract class Tile {

        public GameObject TilePrefab;
        public PlayerColor PlayerColor;

        protected Tile(GameObject tileprefab, PlayerColor playerColor) {
            TilePrefab = tileprefab;
        }

        public abstract List<Vector2Int> PossibleMovements(ChessBoard board);
        public abstract void ExecuteMove(ChessBoard board, Vector2Int vector2Int);

    }
}