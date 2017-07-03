using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour {

	Camera camera;

	// Use this for initialization
	void Start () {
		this.camera = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
		// transform the mouse position to world coordinates
		Vector3 mousePosition = camera.ScreenToWorldPoint (Input.mousePosition);
		// set the crosshair to the mouse position
		// z: -3.0 to set it in front of everything
		this.transform.position = new Vector3 (mousePosition.x, mousePosition.y, -3.0f);
	}
}
