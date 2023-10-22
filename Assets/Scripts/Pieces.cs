using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;


public class Pieces : MonoBehaviour
{
    
    public static Transform pieceTransform;
    public static bool SelectedPiece;

    

    public Side side;
    private void OnMouseDown()
    {
        Debug.Log("I am a selected Piece!");
        SelectedPiece = true;
        pieceTransform = GetComponent<Transform>();

        if (SelectedPiece)
        {
            MovePiece();
        }
        
    }

    private void MovePiece()
    {
        
        Debug.Log(pieceTransform.position);
        
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("je mange");
        if (SelectedPiece && other.CompareTag("Light"))
        {
            Destroy(other);
            
        }
    }
}
