using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	//Created variable to change speed of Bullet
	public float speed = 20f;

	//Created variable which stores how much damage bullet can give
	public int damage = 40;

	//Creatd Rigidbody Object of Bullet which stores reference of Bullet Rigidbody 
	public Rigidbody2D rb;

	//Created Bullet collision Impact Effect Object which stores reference of Bullet Impact Prefab
	public GameObject impactEffect;

	// Use this for initialization
	void Start () {
		
		//Proving velocity to Bullet Prefab
		rb.velocity = transform.right * speed;
	}

	//Ontrigger Function will called automatically whenever any collider with trigger enable touch this GameObject
	void OnTriggerEnter2D (Collider2D hitInfo)
	{
		//Created Enemy Class Object which will get reference of Enemy Class when collided with enemy
		Enemy enemy = hitInfo.GetComponent<Enemy>();
		if (enemy != null)
		{
			//Providing damage to enemy using Damage variable of bullet
			enemy.TakeDamage(damage);
		}

		//Instantiating Impact Effect prefab on Collision
		Instantiate(impactEffect, transform.position, transform.rotation);

		//Destroy this Bullet Object on Collision
		Destroy(gameObject);
	}
	
}
