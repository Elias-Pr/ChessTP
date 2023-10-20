using UnityEngine;
using UnityEngine.UIElements;


public class Pieces : MonoBehaviour
{
    public GameObject Piece;
    
    private Transform pieceTransform;
    public bool SelectedPiece;

    public Side side;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    private void OnMouseDown()
    {
        Debug.Log("I am a selected Piece!");
        SelectedPiece = true;

        if (SelectedPiece)
        {
            MovePiece();
        }
        
    }

    private void MovePiece()
    {
        pieceTransform = GetComponent<Transform>();
        Debug.Log(pieceTransform.position);
        
    }
    
}
