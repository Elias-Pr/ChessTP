using System.Collections.Generic;
using Core;
using Data;
using Entities;
using UnityEngine;

namespace MiniMax
{
    public class Node
    {
        private Piece[,] _currentBoard;
        private PlayerColor _owner;
        private PlayerColor _turn;
        private Vector2Int _move;
        private Vector2Int _initialPos;

        public Piece[,] CurrentBoard => _currentBoard;
        public Vector2Int Move => _move;
        public Vector2Int InitialPos => _initialPos;

        // If node has no childs then it will return true
        public bool IsTerminal => GetChilds().Count == 0;

        public Node(Piece[,] currentBoard, PlayerColor owner, PlayerColor turn, Vector2Int movePosition, Vector2Int initialPos)
        {
            _currentBoard = currentBoard;
            _owner = owner;
            _turn = turn;
            _move = movePosition;
            _initialPos = initialPos;

        }

        public List<Node> GetChilds()
        {
            List<Node> nodelist = new List<Node>();

            for (int row = 0; row < 8; row++)
            {
                for (int column = 0; column < 8; column++)
                {
                    Piece piece = _currentBoard[row, column];
                    
                    if (piece == null) continue;
                    if (piece.PlayerColor != _turn) continue;

                    List<Vector2Int> availableMoves = piece.GetAvailableMoves(new Vector2Int(row,column));
                    
                    foreach (Vector2Int move in availableMoves)
                    {
                        Node newNode = new (_currentBoard, _owner, _turn, move, new Vector2Int(row,column));
                        nodelist.Add(newNode);
                    }
                }
            }
            

            return nodelist;
        }
        
        public int GetHeuristicValue()
        {
            int heuristicValue = 0;

            for (int row = 0; row < 8; row++)
            {
                for (int column = 0; column < 8; column++)
                {
                    Piece piece = _currentBoard[row, column];
                    if (piece == null) continue;
                    if (piece.PlayerColor != _turn) continue;

                    Vector2Int piecePosition = new Vector2Int(row, column);

                    heuristicValue += piece.Score;

                    if (_turn == _owner)
                    {
                        heuristicValue += piece.GetPositionalValue(piecePosition);
                    }
                    else
                    {
                        heuristicValue += piece.GetOppositPosValue(piecePosition);
                    }

                    List<Vector2Int> availableMoves = piece.GetAvailableMoves(new Vector2Int(row, column));
                    foreach (Vector2Int move in availableMoves)
                    {
                        Piece targetPiece = _currentBoard[move.x, move.y];

                        if (targetPiece != null && targetPiece.PlayerColor != _turn)
                        {
                            heuristicValue += targetPiece.Score;
                        }
                    }
                }
            }

            return heuristicValue;
        }


    }
}

/*Objectif fonction d'évaluation

       Queen = 10
       Rook = 5
       Bishop, Knight = 3
       Pawn = 1

       Piece menacing ennemy piece without being menaced = ennemy piece value
                                   while being menaced by an equal piece = null
                                   while being menaced by an higer rated piece = ennemy piece value
                                   while being menaced by a lower rated piece = - current piece value*/