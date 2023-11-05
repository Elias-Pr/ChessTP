using System;
using Core;
using Data;
using Managers;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
using Object = System.Object;


namespace Entities
{
    public class PieceHandler : MonoBehaviour
    {
        public static Transform SelectedPieceTransform;
        public Material SelectedMaterial;
        public Material OriginalMaterial; // Store the original material

        private void OnMouseDown()
        {
            GameManager.Instance.SelectPiece(transform);
            GetComponent<Renderer>().material = SelectedMaterial;
        }

        public void Unselected()
        {
            // Restore the original material when the mouse exits
            GetComponent<Renderer>().material = OriginalMaterial;
        }
    }
}
