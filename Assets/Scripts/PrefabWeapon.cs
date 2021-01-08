using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabWeapon : MonoBehaviour
{
	//Transform Postion of Point from where Bullet can Instantiate in straight Direction
	public Transform firePoint;

	//Transform Postion of Point from where Bullet can Instantiate in Upward Diagonal Direction
	public Transform firePointUp;

	//Transform Postion of Point from where Bullet can Instantiate in Downward Diagonal Direction
	public Transform firePointDown;

	//Variable which stores Bullet Prefab reference so that Player can Instantiate
	public GameObject bulletPrefab;

	// Update is called once per frame
	void Update()
	{
		//If Mouse Button is pressed then Play Shoot Sound and Invoke Shoot Function
		if (Input.GetButtonDown("Fire1") && Time.timeScale==1)
		{
			SoundManagerController.Instance.shootSound.Play();
			Shoot();
		}
	}

	//Instantiate bullet in the direction player is clicking
	void Shoot()
	{
		if (Input.GetAxis("Vertical")>0)
		{
			Instantiate(bulletPrefab, firePointUp.position, firePointUp.rotation);
		}
		else if(Input.GetAxis("Vertical") < 0)
		{
			Instantiate(bulletPrefab, firePointDown.position, firePointDown.rotation);
		}
		else
		{
			Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
		}
	}
}
