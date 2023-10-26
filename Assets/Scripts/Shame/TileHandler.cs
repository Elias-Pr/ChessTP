
using Managers;
using UnityEngine;

namespace Shame
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
