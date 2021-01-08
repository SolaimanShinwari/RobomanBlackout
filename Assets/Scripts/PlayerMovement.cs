using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	//Created Variable which stores CharacterController2D Class reference
	public CharacterController2D controller;

	//Created Animator Variable which stores player Animtor reference
	public Animator animator;

	//Variable which stores how fast player can move;
	public float runSpeed = 40f;

	float horizontalMove = 0f;

	//Variable which returns if player can Jump or not
	bool canJump = false;

	//Function which will call when player lands on Ground and Change Jump Animation to Player Idle or Run Animation
	public void OnLanding ()
	{
		animator.SetBool("IsJumping", false);
	}

	private void Update()
	{
		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

		//Change Animation of player to Run from Idle if user press Movement Keys
		animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

		if (Input.GetButtonDown("Jump"))
		{
			canJump = true;

			//Change Player animation to Jump when Space is clicked
			animator.SetBool("IsJumping", true);
		}
	}

	void FixedUpdate ()
	{
		if(canJump)
		{
			controller.Jump();
		}
		canJump = false;

		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime);
	}
}
