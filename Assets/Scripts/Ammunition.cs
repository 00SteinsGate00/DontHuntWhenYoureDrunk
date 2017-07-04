using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ammunition : MonoBehaviour {

	public Image[] bullets = new Image[5];
	private int bulletCount;

	// Use this for initialization
	void Start () {
		this.bulletCount = 5;
		this.setBulletAmount (5);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Updates the bullet count the the set value
	// Updates the UI graphics as well
	//
	// @ param bulletCount {int} - Number of bullets
	private void setBulletAmount(int bulletCount) {
		this.bulletCount = bulletCount;

		for (int i = 0; i < bulletCount; i++) {
			// Makes the bullet visible
			Color bulletColor = bullets [i].color;
			bulletColor.a = 1;
			bullets [i].color = bulletColor;
		}
		for (int i = bulletCount; i < 5; i++) {
			// Makes the bullet invisible
			Color bulletColor = bullets [i].color;
			bulletColor.a = 0;
			bullets [i].color = bulletColor;
		}
	}

	// Reloads and sets the bullet count back to 5
	public void reload() {
		this.setBulletAmount (5);
	}

	// Reduces the ammunition by 1
	public void reduceBulletCount() {
		this.setBulletAmount (this.bulletCount > 0 ? this.bulletCount-1 : 0);
	}

	// Gets the number of currently loaded bullets
	//
	// return {int}
	public int getBulletCount() {
		return this.bulletCount;
	}
}
