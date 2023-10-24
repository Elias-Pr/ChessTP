using Core;
using Data;
using Managers;
using UnityEngine;


namespace Entities
{
    public class PieceHandler : MonoBehaviour {
    
        public static Transform SelectedPieceTransform;
        //public static bool SelectedPiece;
        
        
        
        private void OnMouseDown()
        {
            
            GameManager.SelectPiece(transform);
            
        }

        
        
    }
}
