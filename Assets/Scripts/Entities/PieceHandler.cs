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
        public Material OriginalMaterial;

        private void OnMouseDown()
        {
            GameManager.Instance.SelectPiece(transform);
            GetComponent<Renderer>().material = SelectedMaterial;
        }

        public void Unselected()
        {
            GetComponent<Renderer>().material = OriginalMaterial;
        }
    }
}
