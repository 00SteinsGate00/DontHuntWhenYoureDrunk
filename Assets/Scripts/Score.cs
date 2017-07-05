using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	private Text scoreLabel;
	public static int scoreCount;

	// Use this for initialization
	void Start () {
		this.scoreLabel = this.GetComponent<Text> ();
		scoreCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void increaseScore(int inc) {
		scoreCount += inc;
		this.scoreLabel.text = scoreCount.ToString ();
	}
}
