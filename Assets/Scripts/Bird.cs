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

	// Score Script
	private Score score;

	public Combo comboLabel;

	// Animator
	private Animator animator;
	// Rigid Body 2D for gravity
	private Rigidbody2D rigidBody;
	// Camera for coordinate transformation
	private Camera camera;

	// Use this for initialization
	void Start () {
		this.animator = this.GetComponent<Animator> ();

		this.camera = Camera.main;

		this.rigidBody = this.GetComponent<Rigidbody2D> ();
		// get the ammunition script
		this.ammunition = GameObject.Find ("Ammunition").GetComponent<Ammunition> ();
		// get the score script
		this.score      = GameObject.Find("Score").GetComponent<Score>();
	}

	
	// Update is called once per frame
	void Update () {
		this.animator.SetInteger ("Direction", direction);

		// movement
		Vector3 movement = new Vector3 (1.0f, 0.0f, 0.0f);
		this.transform.position += movement * this.velocity * Time.deltaTime;

		// check if the bird is outside of the screen and delete it
		Vector3 sceneBounds = Camera.main.ScreenToWorldPoint (new Vector3 (Screen.width, Screen.height, 0));
		if ((this.transform.position.x > sceneBounds.x + sceneBounds.x / 2) || (this.transform.position.x < -sceneBounds.x - sceneBounds.x / 2) || this.transform.position.y < -sceneBounds.y - sceneBounds.y / 2) {
			Destroy (this.gameObject);
		}
	}
		

	public void setVelocity (float velocity) {
		this.velocity = velocity;
	}

	public void setDirection (int direction) {
		this.direction = direction;
		if (direction == 0 && velocity > 0) {
			velocity *= -1;
		}
		else if (direction == 1 && velocity < 0){
			velocity *= -1;
		}
	}

	public bool checkCollission(Vector3 mousePosition) {
		Vector3 objectPosition = this.transform.position;
		Vector3 size		   = this.GetComponent<Renderer>().bounds.size;

		if (mousePosition.x > objectPosition.x - size.x / 2 && mousePosition.x < objectPosition.x + size.x / 2) {
			if (mousePosition.y > objectPosition.y - size.y / 2 && mousePosition.y < objectPosition.y + size.y / 2) {
				return true;
			}
		}
		return false;
	}

	public void die() {
		// Combo
		GameManager.incCombo();
		// mouse position in screen coordinates

		if (GameManager.combo > 1) {
			Combo combo = Instantiate (this.comboLabel, Camera.main.WorldToScreenPoint(this.transform.position), Quaternion.identity) as Combo;
			combo.setComboValue (GameManager.combo);
			combo.transform.SetParent (GameObject.Find("Canvas").transform);
		}

		// set falling animation
		this.animator.SetBool("Dead", true);
		this.rigidBody.simulated = true;
		// increase the point proportional to the velocity
		this.score.increaseScore ((int)(10 * Mathf.Abs(this.velocity)) * GameManager.combo);
	}
}
