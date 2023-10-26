using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraRotate : MonoBehaviour {

    [FormerlySerializedAs("Speed")] public float speed = 8;

	// Update is called once per frame
	void FixedUpdate () {
        transform.Rotate(Vector3.up, speed * Time.deltaTime, Space.World);
	}
}
