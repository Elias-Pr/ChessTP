using System.Collections.Generic;
using Core;
using Data;
using Entities;
using UnityEngine;

namespace Managers {
    public class GameManager : MonoBehaviourSingleton<GameManager> {

        //public int a;
        //public string toto;
        
        private static Piece SelectedPiece;

        private static Vector2Int SelectedTile;

        public static void SelectPiece(Transform piece)
        {

            Vector2Int position = new Vector2Int((int)piece.position.x, (int)piece.position.z);

            SelectedPiece = ChessBoard.Matrix[position.x, position.y];
            
            Debug.Log("I am a selected Piece at " + position.x + position.y + " !");

            List<Vector2Int> availableMoves = SelectedPiece.GetAvailableMoves();
            
            ChessBoard.GenerateTiles(availableMoves);
        }

        public static void SelectTile(Transform tile)
        {
            Vector2Int position = new Vector2Int((int)tile.position.x, (int)tile.position.z);

            if (SelectedPiece == null) return;

            SelectedTile = position;
            
            Debug.Log("I am a selected Tile at " + position.x + position.y + " !");
        }
        
        
        
        /*public static void SelectTile(Transform tile)
        {

            Vector2Int position = new Vector2Int((int)tile.position.x, (int)tile.position.z);

            SelectedTile = ChessBoard.Matrix[position.x, position.y];
            
            Debug.Log("I am a selected Tile at " + position.x + position.y + " !");
            

        }*/
        
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    
    }
}
