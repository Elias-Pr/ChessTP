using System.Collections.Generic;
using Core;
using Data;
using UnityEngine;

namespace MiniMax
{
    public class Node
    {
        
        private Piece[,] _currentBoard;
        private PlayerColor _owner;
        private PlayerColor _turn;

        // If node has no childs then it will return true
        public bool IsTerminal => GetChilds().Count == 0;

        public Node(Piece[,] currentBoard, PlayerColor owner, PlayerColor turn, Vector2Int move)
        {
            _currentBoard = currentBoard;
            _owner = owner;
            _turn = turn;
            
        }

        public List<Node> GetChilds()
        {
            List<Node> nodelist = new List<Node>();
            
            foreach (Piece piece in _currentBoard)
            {
                
                if (piece == null) continue;
                if (piece.PlayerColor != _turn) continue;

                List<Vector2Int> availableMoves = piece.GetAvailableMoves();
            
                foreach (Vector2Int move in availableMoves)
                {
                    Node newNode = new Node(_currentBoard, _owner, _turn, move);
                    nodelist.Add(newNode);
                }

            }

            return nodelist;
        }
        
        /*fonction d'évaluation
        
        Queen = 10
        Rook = 5
        Bishop, Knight = 3
        Pawn = 1
        
        Piece menacing ennemy piece without being menaced = ennemy piece value
                                    while being menaced by an equal piece = null
                                    while being menaced by an higer rated piece = ennemy piece value
                                    while being menaced by a lower rated piece = - current piece value 
                                    
        
        */
        
        public int GetHeuristicValue()
        {
            int heuristicValue = 0;
            
            /*for (int row = 0; row < _currentBoard.GetLength(0); row++)
            {
                for (int column = 0; column < _currentBoard.GetLength(1); column++)
                {*/
            
                    foreach (Piece piece in _currentBoard)
                    {
                        if (piece == null) continue;
                        if (piece.PlayerColor != _turn) continue;
                        
                        
                        heuristicValue += piece.Score;
                        Debug.Log(piece.Score);
                    }
                /*}
            }*/
            return heuristicValue;
        }

    }
}


/*pawnPos = [
   0, 0, 0, 0, 0, 0, 0, 0,
   50, 50, 50, 50, 50, 50, 50, 50,
   10, 10, 20, 30, 30, 20, 10, 10,
   5, 5, 10, 25, 25, 10, 5, 5,
   0, 0, 0, 20, 20, 0, 0, 0,
   5, -5, -10, 0, 0, -10, -5, 5,
   5, 10, 10, -20, -20, 10, 10, 5,
   0, 0, 0, 0, 0, 0, 0, 0
]

knightPos = [
   -200, -100, -50, -50, -50, -50, -100, -200,
   -100, 0, 0, 0, 0, 0, 0, -100,
   -50, 0, 60, 60, 60, 60, 0, -50,
   -50, 0, 30, 60, 60, 30, 0, -50,
   -50, 0, 30, 60, 60, 30, 0, -50,
   -50, 0, 30, 30, 30, 30, 0, -50,
   -100, 0, 0, 0, 0, 0, 0, -100,
   -200, -50, -25, -25, -25, -25, -50, -200
]

bishopPos = [
   -20, -10, -10, -10, -10, -10, -10, -20,
   -10, 0, 0, 0, 0, 0, 0, -10,
   -10, 0, 5, 10, 10, 5, 0, -10,
   -10, 5, 5, 10, 10, 5, 5, -10,
   -10, 0, 10, 10, 10, 10, 0, -10,
   -10, 10, 10, 10, 10, 10, 10, -10,
   -10, 5, 0, 0, 0, 0, 5, -10,
   -20, -10, -10, -10, -10, -10, -10, -20
]

rookPos = [
   0, 0, 0, 0, 0, 0, 0, 0,
   5, 10, 10, 10, 10, 10, 10, 5,
   -5, 0, 0, 0, 0, 0, 0, -5,
   -5, 0, 0, 0, 0, 0, 0, -5,
   -5, 0, 0, 0, 0, 0, 0, -5,
   -5, 0, 0, 0, 0, 0, 0, -5,
   -5, 0, 0, 0, 0, 0, 0, -5,
   0, 0, 0, 5, 5, 0, 0, 0
]

queenPos = [
   -20, -10, -10, -5, -5, -10, -10, -20,
   -10, 0, 0, 0, 0, 0, 0, -10,
   -10, 0, 5, 5, 5, 5, 0, -10,
   -5, 0, 5, 5, 5, 5, 0, -5,
   0, 0, 5, 5, 5, 5, 0, -5,
   -10, 5, 5, 5, 5, 5, 0, -10,
   -10, 0, 5, 0, 0, 0, 0, -10,
   -20, -10, -10, -5, -5, -10, -10, -20
]

kingPos = [
   20, 30, 10, 0, 0, 10, 30, 20,
   20, 20, 0, 0, 0, 0, 20, 20,
   -10, -20, -20, -20, -20, -20, -20, -10,
   -20, -30, -30, -40, -40, -30, -30, -20,
   -30, -40, -40, -50, -50, -40, -40, -30,
   -30, -40, -40, -50, -50, -40, -40, -30,
   -30, -40, -40, -50, -50, -40, -40, -30,
   -30, -40, -40, -50, -50, -40, -40, -30
]
 */