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


    }
}