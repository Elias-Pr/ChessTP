using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;


public class Pieces : MonoBehaviour
{
    GameObject Piece;
    
    // Start is called before the first frame update
    void Start()
    {
        Piece = this.GameObject();
    }

    // Update is called once per frame
    private void OnMouseDown()
    {
        Debug.Log("I am selected !");
    }
}
