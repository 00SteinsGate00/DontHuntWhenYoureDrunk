using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudManager : MonoBehaviour {

	private int cloudTimer = 1;

	public Cloud cloudPrefab;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.cloudTimer += Random.Range (1, 10);
		if (this.cloudTimer % 150 == 0) {
			Vector3 sceneBounds = Camera.main.ScreenToWorldPoint (new Vector3 (Screen.width, Screen.height, 0));
			Vector3 cloudPosition = new Vector3 ((sceneBounds.x + sceneBounds.x / 5) * -1, Random.Range (-sceneBounds.y+sceneBounds.y/3, sceneBounds.y-sceneBounds.y/10), -2f);
			Instantiate (cloudPrefab, cloudPosition, Quaternion.identity);
		}
	}
}
