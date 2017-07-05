using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;

public class BirdManagement : MonoBehaviour {

	private int birdTimer = 0;

	public Bird birdPrefab;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	//
	// Spawns birds randomly
	void Update () {
		
		birdTimer += Random.Range (0, 3);

		if (birdTimer % 50 == 0) {
			Vector3 sceneBounds = Camera.main.ScreenToWorldPoint (new Vector3 (Screen.width, Screen.height, 0));

			// determines whether the bird is spawned on the right or left side
			float directionDecision = Random.value;

			// Spawn on the right
			if (directionDecision > 0.5) {
				Vector3 birdPosition = new Vector3 ((sceneBounds.x + sceneBounds.x / 10), Random.Range (-sceneBounds.y+sceneBounds.y/10, sceneBounds.y-sceneBounds.y/10), 0f);
				Bird bird = Instantiate (birdPrefab, birdPosition, Quaternion.identity) as Bird;
				bird.setVelocity (Random.Range(-10,-3));
				bird.setDirection (0);

			// Spawn on the left
			} else {
				Vector3 birdPosition = new Vector3 ((sceneBounds.x + sceneBounds.x / 10) * -1, Random.Range (-sceneBounds.y+sceneBounds.y/10, sceneBounds.y-sceneBounds.y/10), 0f);
				Bird bird = Instantiate (birdPrefab, birdPosition, Quaternion.identity) as Bird;
				bird.setVelocity (Random.Range(3,10));
				bird.setDirection (1);

			}
		}
			
		if (Input.GetMouseButtonDown (0)) {
			this.checkForCollissions ();
		}

	}

	void FixedUpdate(){

		// I'll leave it here
		// this works sometimes and sometimes it doesn't, randomly

//		if (Input.GetMouseButtonDown (0)) {
//			Vector3 mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);

//			RaycastHit2D[] hits = Physics2D.RaycastAll (mousePosition, Vector2.zero, Mathf.Infinity);

//			foreach (RaycastHit2D hit in hits) {
//				GameObject obj = hit.collider.gameObject;
//				Bird hitBird = obj.GetComponent<Bird> ();
//				hitBird.die ();
//			}
//
//			Debug.Log (hits.Length);
//		}
	}

	private void checkForCollissions() {
		Vector3 mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);

		Bird[] birds = FindObjectsOfType(typeof(Bird)) as Bird[];

		bool hit = false;

		foreach (Bird bird in birds) {
			// check for collision 
			if (bird.checkCollission (mousePosition)) {
				bird.die ();
				hit = true;
			}
		}

		if (!hit) {
			GameManager.resetCombo ();
		}
	}
}
