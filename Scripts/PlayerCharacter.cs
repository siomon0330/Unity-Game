using UnityEngine;
using System.Collections;

public class PlayerCharacter : MonoBehaviour {

	private Rigidbody2D rb;
	private Animator an;

	public float movementSpeed = 10f;
	public float jumpForce = 400f;
	public float maxVelocityX = 4f;

	public AudioClip soundEffect;

	private bool Grounded;

	// Use this for initialization
	void Start () {
		//get the components
		rb = GetComponent<Rigidbody2D>();
		an = GetComponent<Animator>();

	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//Force to be applied
		var force = new Vector2(0f, 0f);

		//Get controls for horizontal movement
		float moveHorizontal = Input.GetAxis("Horizontal");

		//get current velocity of the rigidbidy 2d
		var absVelocityX = Mathf.Abs(rb.velocity.x);
		var absVelocityY = Mathf.Abs(rb.velocity.y);

		//check if on ground
		if (absVelocityY == 0){
			Grounded = true;
		}else{
			Grounded = false;
		}

		//set x force
		if (absVelocityX < maxVelocityX){
			force.x = (movementSpeed * moveHorizontal);
		}
		//jump if on gound and button pressed
		if (Grounded == true && Input.GetButton("Jump")){

			if(soundEffect){
				AudioSource.PlayClipAtPoint(soundEffect, transform.position);
			}

			Grounded = false;
			force.y = jumpForce;
			an.SetInteger("AnimationState", 2);
		}
		//apply force
		rb.AddForce(force);

		//Alter player direction
		if(moveHorizontal > 0){

			//face right
			transform.localScale = new Vector3(1,1,1);
			if(Grounded){
				an.SetInteger("AnimationState", 1);
			}
		}else if(moveHorizontal < 0){

				//face left
				transform.localScale = new Vector3(-1,1,1);
				if(Grounded){
					an.SetInteger("AnimationState", 1);
				}
		}else{

			//still
			if(Grounded){
				an.SetInteger("AnimationState", 0);
			}
		}

	}
}
