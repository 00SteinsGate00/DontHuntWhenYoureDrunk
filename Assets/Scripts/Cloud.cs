using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float velocity = 2;
		Vector3 move = new Vector3 (1.0f, 0.0f, 0.0f);

		this.transform.position += move * velocity * Time.deltaTime;

		// check if the bird is outside of the screen and delete it
		Vector3 sceneBounds = Camera.main.ScreenToWorldPoint (new Vector3 (Screen.width, Screen.height, 0));
		if (this.transform.position.x > sceneBounds.x + sceneBounds.x / 2) {
			Destroy (this.gameObject);
		}
	}
}
