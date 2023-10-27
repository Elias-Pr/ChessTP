using Managers;
using UnityEngine;

namespace Tile
{
    public class TileHandler : MonoBehaviour
    {
        public static Transform SelectedtileTransform;
        
        private void OnMouseDown()
        {
            GameManager.SelectTile(transform);

        }
    }
}
