using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdManagement : MonoBehaviour {

	private int birdTimer;

	public Bird birdPrefab;

	// Use this for initialization
	void Start () {
		this.birdTimer = 0;
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
				Vector3 birdPosition = new Vector3 ((sceneBounds.x + sceneBounds.x / 10), Random.Range (-sceneBounds.y+sceneBounds.y/10, sceneBounds.y-+sceneBounds.y/10), -2f);
				Bird bird = Instantiate (birdPrefab, birdPosition, Quaternion.identity) as Bird;
				bird.setVelocity (Random.Range(-10,-3));
				bird.setDirection (0);

			// Spawn on the left
			} else {
				Vector3 birdPosition = new Vector3 ((sceneBounds.x + sceneBounds.x / 10) * -1, Random.Range (-sceneBounds.y+sceneBounds.y/10, sceneBounds.y-+sceneBounds.y/10), -2f);
				Bird bird = Instantiate (birdPrefab, birdPosition, Quaternion.identity) as Bird;
				bird.setVelocity (Random.Range(3,10));
				bird.setDirection (1);
			}
		}

	}
}
