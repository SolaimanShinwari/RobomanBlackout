using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	//Created Variable that stores total amount of enemy health
	public int health = 100;

	//Created Object that stores enemy death effect prefab
	public GameObject deathEffect;

	//Bool variable if user wants to destroy parent object or not
	public bool destroyParent = false;

	//Function that will be called by bullet collided with enemy and send damage amount
	public void TakeDamage (int damage)
	{
		health -= damage;

		if (health <= 0)
		{
			//If enemy health is less then 0 then invoke Enemy Die Function
			Die();
		}
	}

	void Die()
	{
		//Enemy Die Sound will play
		SoundManagerController.Instance.explosionSound.Play();

		//Instantiating Death Effect prefab on Collision
		Instantiate(deathEffect, transform.position, Quaternion.identity);

		//If destroyParent bool is set to true then destroy parent also else destroy this object only 
		if (destroyParent)
		{
			Destroy(gameObject.transform.parent.gameObject);
		}
		else
		{
			Destroy(gameObject);
		}
	}

}
