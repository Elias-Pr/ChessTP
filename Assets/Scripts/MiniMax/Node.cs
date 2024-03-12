using System.Collections.Generic;
using Core;
using Data;
using Entities;
using UnityEngine.UI;

namespace MiniMax
{
    public class Node
    {
        
        private Piece[,] _currentBoard;
        private PlayerColor _owner;
        private PlayerColor _turn;
        
        public Node(Piece[,] currentBoard, PlayerColor owner, PlayerColor turn)
        {
            _currentBoard = currentBoard;
            _owner = owner;
            _turn = turn;
        }

        /*public List<Node> GetChilds()
        {
            foreach (Piece piece in _currentBoard)
            {
                piece.GetAvailableMoves();
                foreach (var VARIABLE in COLLECTION)
                {
                    
                }
            }
        }*/
        
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
            
            for (int row = 0; row < ChessBoard.Matrix.GetLength(0); row++)
            {
                for (int column = 0; column < ChessBoard.Matrix.GetLength(1); column++)
                {
                    foreach (Piece piece in ChessBoard.Matrix)
                    {
                        if (piece.PlayerColor == _owner)
                        {
                            heuristicValue += piece.Score;
                        }
                    }
                }
            }
            return heuristicValue;
        }

    }
}
