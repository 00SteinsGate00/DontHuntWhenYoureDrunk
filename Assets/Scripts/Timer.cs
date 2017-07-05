using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {

	private float secondsCount;

	private Text timerLabel;

	// Use this for initialization
	void Start () {
		this.secondsCount = 60;

		this.timerLabel = this.GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		this.secondsCount -= Time.deltaTime;

		string secondLabelText = this.secondsCount > 10 ? Mathf.Floor (this.secondsCount).ToString () : "0" + Mathf.Floor (this.secondsCount).ToString ();
		this.timerLabel.text = "0:" + secondLabelText;

		if (Mathf.Floor (this.secondsCount) <= 0) {
			this.timeUp ();
		}
	}

	private void timeUp() {
		// times up
		// Results Scene
		SceneManager.LoadScene(1);
	}
}
