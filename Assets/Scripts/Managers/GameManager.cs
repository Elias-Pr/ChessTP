using System;
using System.Collections.Generic;
using Core;
using Data;
using Entities;
using UnityEngine;

namespace Managers {
    
    public class GameManager : MonoBehaviourSingleton<GameManager> {

        private static Piece _selectedPiece;
        private static Vector2Int _selectedTile;
        private static Vector2Int _selectedPiecePosition;
        private static bool PieceIsSelected => _selectedPiece != null;
        private static bool TileIsSelected => _selectedTile != null;

        private PlayerColor _playerTurn = PlayerColor.White; 
        public PlayerColor Opponent => _playerTurn == PlayerColor.White ? PlayerColor.Black : PlayerColor.White;

        private bool _doOnce = true;

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
            if (!PieceIsSelected || !TileIsSelected) return;
            if (_doOnce)
            {
                //ResolveMove();
                _doOnce = false;
            }
            
        }

        public static void SelectPiece(Transform piece)
        {
            if (piece==null)
            {
                throw new NullReferenceException("Cannot select Ghostpiece");
            }
            
            _selectedPiecePosition = new Vector2Int((int)piece.position.x, (int)piece.position.z);
            
            if ((_selectedPiecePosition.x < 0 && _selectedPiecePosition.x > 7)
                || (_selectedPiecePosition.y < 0 && _selectedPiecePosition.y > 7))
            {
                return;
            }
            
            _selectedPiece = ChessBoard.Matrix[_selectedPiecePosition.x, _selectedPiecePosition.y];

            List<Vector2Int> availableMoves = _selectedPiece.GetAvailableMoves(); 
            ChessBoard.GenerateTiles(availableMoves);
            
        }

        public static void SelectTile(Transform tile)
        {
            Vector2Int position = new Vector2Int((int)tile.position.x, (int)tile.position.z);

            if (_selectedPiece == null) return;

            _selectedTile = position;
        }
        
        private void ResolveMove()
        {
            Piece destination = ChessBoard.Matrix[_selectedTile.x, _selectedTile.y];
                
            if ( destination != null && destination.PlayerColor == Opponent)
                Destroy(ChessBoard.Matrix[_selectedTile.x,_selectedTile.y].Behaviour.gameObject);

            ChessBoard.Matrix[_selectedTile.x, _selectedTile.y] = _selectedPiece;
            ChessBoard.Matrix[_selectedPiecePosition.x, _selectedPiecePosition.y] = null;

            ChessBoard.Matrix[_selectedTile.x, _selectedTile.y].Behaviour.transform.position =
                new Vector3(_selectedTile.x, 0, _selectedTile.y);
        }
    }
}
