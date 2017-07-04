using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {

	// 0 left, 1 right
	private int direction;
	// velocity
	private float velocity;


	// Animator
	Animator animator;

	// Rigid Body 2D for gravity
	Rigidbody2D rigidBody;

	// Use this for initialization
	void Start () {
		this.animator = this.GetComponent<Animator> ();
		this.rigidBody = this.GetComponent<Rigidbody2D> ();

		// dummy values for now
		this.direction = 1;
		this.velocity = 10.0f;
	}
	
	// Update is called once per frame
	void Update () {
		this.animator.SetInteger ("Direction", direction);

		Vector3 movement = new Vector3 (1.0f, 0.0f, 0.0f);
		this.transform.position += movement * velocity * Time.deltaTime;

	}

	void setVelocity(float velocity){
		this.velocity = velocity;
	}
}
