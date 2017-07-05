using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Combo : MonoBehaviour {

	private float originalDisplayTime = 3;
	private float displayTime = 2;
	private float comboValue  = 0;

	private Text comboDisplay;

	// Use this for initialization
	void Start () {
		this.comboDisplay = this.GetComponent<Text> ();
		this.displayTime = this.originalDisplayTime;
	}
	
	// Update is called once per frame
	void Update () {
		this.comboDisplay.text = comboValue.ToString () + "x";

		// update the display time
		this.displayTime -= Time.deltaTime;

		// move the marker upwards
		Vector3 move = new Vector3 (0.0f, 20.0f, 0.0f);
		this.transform.position += move * Time.deltaTime;

		// set the transparency
		Color color = this.comboDisplay.color;
		color.a = this.displayTime / this.originalDisplayTime; 
		this.comboDisplay.color = color;

		// destroy the object if the time is below 0;
		if (this.displayTime <= 0) {
			Destroy (this.gameObject);
		}
	}

	public void setComboValue(int combo){
		this.comboValue = combo;
	}
}
