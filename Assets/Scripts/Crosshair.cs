﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour {

	Camera camera;

	public Ammunition ammunition;

	private AudioSource audio;

	public AudioClip gunshot;
	public AudioClip reload;
	public AudioClip outOfAmmo;

	// Use this for initialization
	void Start () {
		this.camera = Camera.main;

		// Audio Source
		this.audio = this.GetComponent<AudioSource> ();


	}
			
	// Update is called once per frame
	void Update () {
		// transform the mouse position to world coordinates
		Vector3 mousePosition = camera.ScreenToWorldPoint (Input.mousePosition);
		// set the crosshair to the mouse position
		// z: -3.0 to set it in front of everything
		this.transform.position = new Vector3 (mousePosition.x, mousePosition.y, -3.0f);

		if (Input.GetMouseButtonDown (0)) {
			if (this.ammunition.getBulletCount () > 0) {
				this.ammunition.reduceBulletCount ();
				// gunshot
				this.audio.PlayOneShot (this.gunshot, 1);
			} else {
				// out of ammo
				this.audio.PlayOneShot (this.outOfAmmo, 1);
			}


		}
		else if (Input.GetMouseButtonDown(1)) {
			this.ammunition.reload ();
			// reload
			this.audio.PlayOneShot (this.reload, 1);
		}
	}
}
