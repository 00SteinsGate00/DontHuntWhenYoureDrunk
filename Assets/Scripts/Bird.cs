using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {

	// 0 left, 1 right
	private int direction;
	// velocity
	private float velocity;

	// Ammunition Script
	public Ammunition ammunition;

	// Animator
	private Animator animator;
	// Rigid Body 2D for gravity
	private Rigidbody2D rigidBody;
	// Camera for coordinate transformation
	private Camera camera;

	// Use this for initialization
	void Start () {
		this.animator = this.GetComponent<Animator> ();
		this.rigidBody = this.GetComponent<Rigidbody2D> ();
		this.camera = Camera.main;

		// dummy values for now
		this.direction = 1;
		this.velocity = 5.0f;
	}
	
	// Update is called once per frame
	void Update () {
		this.animator.SetInteger ("Direction", direction);

		Vector3 movement = new Vector3 (1.0f, 0.0f, 0.0f);
		this.transform.position += movement * velocity * Time.deltaTime;


		// left click
		if (Input.GetMouseButtonDown (0) && this.ammunition.getBulletCount() > 0) {
			Vector3 mousePosition  = camera.ScreenToWorldPoint(Input.mousePosition);
			Vector3 objectPosition = this.transform.position;
			Vector3 size		   = this.GetComponent<Renderer>().bounds.size;


			// check if this bird was hit by the mouse
			if (mousePosition.x > objectPosition.x - size.x/2 && mousePosition.x < objectPosition.x + size.x/2) {
				if (mousePosition.y > objectPosition.y - size.y/2 && mousePosition.y < objectPosition.y + size.y/2) {
					this.rigidBody.simulated = true;
				}
			}
		
		}

	}

	void setVelocity(float velocity){
		this.velocity = velocity;
	}
}
