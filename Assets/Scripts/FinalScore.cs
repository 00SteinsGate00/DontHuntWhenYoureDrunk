using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour {

	private Text finalScoreLabel;

	// Use this for initialization
	void Start () {
		this.finalScoreLabel = this.GetComponent<Text> ();

		this.finalScoreLabel.text = Score.scoreCount.ToString ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
