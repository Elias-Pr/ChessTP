using System.Collections.Generic;
using Core;
using Entities;
using UnityEngine;

namespace Data
{
    public class Queen : Piece
    {
        
        public Queen(GameObject prefab, PlayerColor playerColor, GameObject handler = null) : base(prefab, playerColor, handler)
        {
        }
    
        
    }
}