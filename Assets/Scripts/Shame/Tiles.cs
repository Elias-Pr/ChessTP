
using UnityEngine;

namespace Shame
{
    public class Tiles : MonoBehaviour
    {
        public GameObject Tile;

        public static Transform tileTransform;
        public static bool SelectedTile;

        private void OnMouseDown()
        {
            Debug.Log("I am a selected Tile");
            SelectedTile = true;
            tileTransform = GetComponent<Transform>();

            if (SelectedTile)
            {
                Destination();
            }

        }

        private void Destination()
        {
            Debug.Log(tileTransform.position);
        }
    
    }
}
