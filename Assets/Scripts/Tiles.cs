
using UnityEngine;

public class Tiles : MonoBehaviour
{
    public GameObject Tile;

    private Transform tileTransform;

    public bool SelectedTile;
    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnMouseDown()
    {
        Debug.Log("I am a selected Tile");
        SelectedTile = true;

        if (SelectedTile)
        {
            Destination();
        }

    }

    private void Destination()
    {
        tileTransform = GetComponent<Transform>();
        Debug.Log(tileTransform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
