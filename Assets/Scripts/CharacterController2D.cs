using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class CharacterController2D : MonoBehaviour
{
	//Created variable for Player Jump force
	[SerializeField] private float m_JumpForce = 400f;
	
	//Created variable that will check how smooth movement user wants for player
	[Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;
	
	//Created a LayerMask for Ground which stores which layer is ground
	[SerializeField] private LayerMask m_WhatIsGround;
	
	//Position of ground
	[SerializeField] private Transform m_GroundCheck;

	//Created a variable for ground radius check so that we can provide a radius of Ground check collision
	const float k_GroundedRadius = .2f; 

	//Bool variable that returns check if player is on ground or not
	private bool m_Grounded;

	//Creatd Rigidbody Object of Player which stores reference of Player Rigidbody 
	private Rigidbody2D m_Rigidbody2D;

	//Created variable which retuns if player is facing right or left
	private bool m_FacingRight = true;

	private Vector3 m_Velocity = Vector3.zero;

	//Bool variable which let the player know that it can double jump or not
	bool candoublejump = false;

	//Created Unity Event that invokes function which ever is passed to it when player lands on ground
	[Header("Events")]
	[Space]

	public UnityEvent OnLandEvent;

	private void Awake()
	{
		//Get reference of Player Rigidbody
		m_Rigidbody2D = GetComponent<Rigidbody2D>();

		if (OnLandEvent == null)
			OnLandEvent = new UnityEvent();
	}

	private void FixedUpdate()
	{

		bool wasGrounded = m_Grounded;
		m_Grounded = false;

		// The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
		// This can be done using layers instead but Sample Assets will not overwrite your project settings.
		Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject)
			{
				m_Grounded = true;
				if (!wasGrounded)
					OnLandEvent.Invoke();
			}
		}
	}


	public void Move(float move)
	{
			// Move the character by finding the target velocity
			Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
			// And then smoothing it out and applying it to the character
			m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

			// If the input is moving the player right and the player is facing left...
			if (move > 0 && !m_FacingRight)
			{
				// ... flip the player.
				Flip();
			}
			// Otherwise if the input is moving the player left and the player is facing right...
			else if (move < 0 && m_FacingRight)
			{
				// ... flip the player.
				Flip();
			}
	}

	public void Jump()
	{
		//If player is grounded then allow player to jump using AddForce and enable player can double Jump
		if (m_Grounded)
		{
			m_Rigidbody2D.AddForce(new Vector2(0, m_JumpForce),ForceMode2D.Impulse);
			candoublejump = true;
		}
		else
		{
			//If player is in Air and Double Jump is enabled then allow player to double jump using Add Force
			if (candoublejump)
			{
				candoublejump = false;
				m_Rigidbody2D.AddForce(new Vector2(0, m_JumpForce), ForceMode2D.Impulse);
			}
		}

		//Set grounded to false as player will be in Air after Add Force
		m_Grounded = false;
	}


	private void Flip()
	{
		// Switch the way the player is labelled as facing.
		m_FacingRight = !m_FacingRight;

		transform.Rotate(0f, 180f, 0f);
	}

    //Ontrigger Function will called automatically whenever any collider with trigger enable touch this GameObject
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Check if enemy is collided with Player
        if (other.CompareTag("Enemy"))
        {
            //Play Explosion Sound
            SoundManagerController.Instance.explosionSound.Play();

            //Restart current scene as player is collided with enemy
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

            SoundManagerController.Instance.backgroundSound.Play();
            SoundManagerController.Instance.bossSound.Stop();

        }
    }
}
