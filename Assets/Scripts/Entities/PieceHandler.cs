using Core;
using Data;
using Unity.VisualScripting;
using UnityEngine;

namespace Entities
{
    public class PieceHandler : MonoBehaviour {
    
        public static Transform SelectedPieceTransform;
        //public static bool SelectedPiece;
        public GameObject SelectedPiece;
        
        
        private void OnMouseDown()
        {
            SelectedPiece = this.GameObject();
            SelectedPieceTransform = GetComponent<Transform>();
            Debug.Log("I am a selected Piece at " + SelectedPieceTransform.position + " !");
        }

        

        
    }
}
