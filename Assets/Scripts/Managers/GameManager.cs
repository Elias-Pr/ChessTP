using System;
using System.Collections.Generic;
using System.Diagnostics;
using Core;
using Data;
using Entities;
using MiniMax;
using UnityEngine;
using UnityEngine.Serialization;
using Debug = UnityEngine.Debug;
using Random = UnityEngine.Random;

namespace Managers {
    
    public class GameManager : MonoBehaviourSingleton<GameManager> {

        private Piece _selectedPiece;
        private Vector2Int _selectedTile;
        public Vector2Int SelectedPiecePosition;
        private bool PieceIsSelected;
        private bool TileIsSelected;
        public Camera WhiteCam;
        public Camera BlackCam;
        
        private PlayerColor _playerTurn = PlayerColor.White; 
        public PlayerColor Opponent => _playerTurn == PlayerColor.White ? PlayerColor.Black : PlayerColor.White;
        
        //Minimax param
        public static PlayerColor Owner;
        
        MiniMaxLogic minimax = new MiniMaxLogic();


        [ContextMenu("Think")]
        private void Think()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            bool isOwnerTurn = Owner == _playerTurn;
            Node node = new Node(ChessBoard.Matrix, Owner, _playerTurn, Vector2Int.zero, Vector2Int.zero);
            Node bestChild = null;

            int depth = 4;
            
            int alpha = int.MinValue; // alpha
            int beta = int.MaxValue; // beta

            foreach (Node child in node.GetChilds())
            {
                int score = minimax.MinimaxFunctionAlphaBeta(child, depth - 1, alpha, beta, !isOwnerTurn);

                if (bestChild == null || score > bestChild.GetHeuristicValue())
                {
                    bestChild = child;
                }
                else if (score == bestChild.GetHeuristicValue())
                {
                    if (Random.Range(0, 2) == 0)
                    {
                        bestChild = child;
                    }
                }
            }

            if (bestChild != null)
            {
                ChessBoard.Matrix = bestChild.CurrentBoard;
                SelectedPiecePosition = bestChild.InitialPos;
                _selectedTile = bestChild.Move;
                ResolveMoveAI();
                Debug.Log(bestChild.GetHeuristicValue());
            }

            stopwatch.Stop();
            float elapsedSeconds = (float)Math.Round(stopwatch.ElapsedMilliseconds / 1000.0, 2);
            Debug.Log("elapsed time : " + elapsedSeconds);
        }

        
        private void Start()
        {
            for (int c = 0; c <8; c++)
            {
                for (int r = 0; r < 8; r++)
                {
                    Debug.Log(ChessBoard.Matrix[_selectedTile.x,_selectedTile.y].Behaviour.gameObject.name);
                }
            }
        }

        
        
        private void Update()
        {
            
            if (_playerTurn == PlayerColor.White)
            {
                DisableOpponentPieceColliders(PlayerColor.Black);
            }
            else if (_playerTurn == PlayerColor.Black)
            {
                DisableOpponentPieceColliders(PlayerColor.White);
            }
            
            if (PieceIsSelected && TileIsSelected)
            {
                ResolveMove();

                EnableOpponentPieceColliders(PlayerColor.Black);
                EnableOpponentPieceColliders(PlayerColor.White);
                
                Debug.Log(_playerTurn);
            }

        }
        

        private void ChangeTurn()
        {
            PieceIsSelected = false;
            TileIsSelected = false;
            _playerTurn = Opponent;
            if (_playerTurn == PlayerColor.White)
            {
                WhiteCam.gameObject.SetActive(true);
                //BlackCam.gameObject.SetActive(false);
            }
            /*else if (_playerTurn == PlayerColor.Black)
            {
                WhiteCam.gameObject.SetActive(false);
                BlackCam.gameObject.SetActive(true);
            }*/
        }

        public  void SelectPiece(Transform piece)
        {
            if (piece==null)
            {
                throw new NullReferenceException("Cannot select Ghostpiece");
            }
            
            SelectedPiecePosition = new Vector2Int((int)piece.position.x, (int)piece.position.z);
            
            if ((SelectedPiecePosition.x < 0 && SelectedPiecePosition.x > 7)
                || (SelectedPiecePosition.y < 0 && SelectedPiecePosition.y > 7))
            {
                return;
            }
            
            if (_selectedPiece != null)
            {
                _selectedPiece.Behaviour.GetComponent<PieceHandler>().Unselected();
            }
            
            _selectedPiece = ChessBoard.Matrix[SelectedPiecePosition.x, SelectedPiecePosition.y];

            if (_selectedPiece.PlayerColor == Opponent)
            {
                Debug.Log("You can't play this piece ! Scumbag !");
                _selectedPiece = null;
                SelectedPiecePosition = Vector2Int.zero;
                _selectedTile = Vector2Int.zero;
                
                return;
            }

            PieceIsSelected = true;

            List<Vector2Int> availableMoves = _selectedPiece.GetAvailableMoves(SelectedPiecePosition); 
            ChessBoard.GenerateTiles(availableMoves);
            
        }

        public  void SelectTile(Transform tile)
        {
            Vector2Int position = new Vector2Int((int)tile.position.x, (int)tile.position.z);

            if (_selectedPiece == null) return;

            _selectedTile = position;

            TileIsSelected = true;
            
            
        }

        private void ResolveMoveAI()
        {

           
            Piece destination = ChessBoard.GetTile(_selectedTile);
            if (destination == null || destination.PlayerColor == Opponent)
            {
                if (destination != null && destination.PlayerColor == Opponent)
                {
                    Destroy(ChessBoard.Matrix[_selectedTile.x, _selectedTile.y].Behaviour.gameObject);
                }
                
                ChessBoard.Matrix[_selectedTile.x, _selectedTile.y] = ChessBoard.Matrix[SelectedPiecePosition.x, SelectedPiecePosition.y];
                ChessBoard.Matrix[SelectedPiecePosition.x, SelectedPiecePosition.y] = null;

                ChessBoard.Matrix[_selectedTile.x, _selectedTile.y].Behaviour.transform.position =
                    new Vector3(_selectedTile.x, 0, _selectedTile.y);
                
                _selectedPiece = null;
                
                
                
                ChangeTurn();
            }

            else
            {
                Debug.Log("AI Invalid move !");
            }
            ChessBoard.DestroyOldTiles();
            
        }
        
        private void ResolveMove()
        {
            Piece destination = ChessBoard.GetTile(_selectedTile.x, _selectedTile.y);
            
            if (destination == null || destination.PlayerColor == Opponent)
            {
                if (destination != null && destination.PlayerColor == Opponent)
                {
                    Destroy(ChessBoard.Matrix[_selectedTile.x, _selectedTile.y].Behaviour.gameObject);
                }
                
                ChessBoard.Matrix[_selectedTile.x, _selectedTile.y] = _selectedPiece;
                ChessBoard.Matrix[SelectedPiecePosition.x, SelectedPiecePosition.y] = null;
                
                ChessBoard.Matrix[_selectedTile.x, _selectedTile.y].Behaviour.transform.position =
                    new Vector3(_selectedTile.x, 0, _selectedTile.y);

                _selectedPiece.Behaviour.GetComponent<PieceHandler>().Unselected();
                _selectedPiece = null;
                PieceIsSelected = false;
                
                ChangeTurn();
            }
            else
            {
                Debug.Log("Invalid move! Destination tile is occupied by a friendly piece.");
            }
            ChessBoard.DestroyOldTiles();
            
        }
        
        private void DisableOpponentPieceColliders(PlayerColor opponentColor)
        {
            foreach (Piece piece in ChessBoard.Matrix)
            {
                if (piece != null && piece.PlayerColor == opponentColor)
                {
                    Collider pieceCollider = piece.Behaviour.GetComponent<Collider>();
                    if (pieceCollider != null)
                    {
                        pieceCollider.enabled = false;
                    }
                }
            }
        }

        private void EnableOpponentPieceColliders(PlayerColor opponentColor)
        {
            foreach (Piece piece in ChessBoard.Matrix)
            {
                if (piece != null && piece.PlayerColor == opponentColor)
                {
                    Collider pieceCollider = piece.Behaviour.GetComponent<Collider>();
                    if (pieceCollider != null)
                    {
                        pieceCollider.enabled = true;
                    }
                }
            }
        }
        
        public bool IsPositionEmpty(int x, int y)
        {
            if (x < 0 || x >= ChessBoard.Matrix.GetLength(0) || y < 0 || y >= ChessBoard.Matrix.GetLength(1))
            {
                return true;
            }

            
            Piece piece = ChessBoard.Matrix[x, y];

            
            return piece == null;
        }

    }
}
