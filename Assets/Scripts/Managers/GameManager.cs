using System;
using System.Collections.Generic;
using Core;
using Data;
using Entities;
using UnityEngine;

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

        private void Start()
        {
            Debug.Log("test Matrix");
            for (int c = 0;  c<8; c++)
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
                BlackCam.gameObject.SetActive(false);
            }
            else if (_playerTurn == PlayerColor.Black)
            {
                WhiteCam.gameObject.SetActive(false);
                BlackCam.gameObject.SetActive(true);
            }
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

            List<Vector2Int> availableMoves = _selectedPiece.GetAvailableMoves(); 
            ChessBoard.GenerateTiles(availableMoves);
            
        }

        public  void SelectTile(Transform tile)
        {
            Vector2Int position = new Vector2Int((int)tile.position.x, (int)tile.position.z);

            if (_selectedPiece == null) return;

            _selectedTile = position;

            TileIsSelected = true;
            
            
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
