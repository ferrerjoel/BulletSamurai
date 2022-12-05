using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Pvr_UnitySDKAPI;

public class ShootGun : MonoBehaviour {
	
	public GameObject gun;
	public ParticleSystem particlesShoot;
	public GameObject impactEffect; 
	public AudioSource shootSound;
	public AudioSource reloadSound;

	public Text textUI;
	public Text bulletsText;

	private const byte maxBullets = 6;

	private byte bullets;
	public bool isReloading;

	void Start () {
		bullets = maxBullets;
	}
	
	// Update is called once per frame
	void Update () {
		if (Controller.UPvr_GetKeyDown(0, Pvr_KeyCode.APP) || Input.GetKeyDown("space"))
		{
			Shoot();
		}
	}

	void Shoot() 
	{
		Debug.Log(bullets + " " + isReloading);
		if (bullets > 0 && !isReloading)
		{
			//textUI.text = "\n\n\n\n\n\n\nMISS";
			particlesShoot.Play();
			shootSound.Play();

			RaycastHit hit;
			if (Physics.Raycast(gun.transform.position, gun.transform.forward, out hit))
			{
				//textUI.text = "\n\n\n\n\n\n\n" + hit.transform.name;
				Enemy enemy = hit.transform.GetComponent<Enemy>();
				if (enemy != null)
				{
					enemy.takeHit();
				}

				GameObject impact = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
				Destroy(impact, 2f);
			}
			bullets--;
			updateBulletText();
		} else if (!isReloading) {
			StartCoroutine(reload());
		}
		
	}

	IEnumerator reload()
	{
		isReloading = true;
		reloadSound.Play();
		yield return new WaitForSeconds(reloadSound.clip.length);
		bullets = maxBullets;
		updateBulletText();
		isReloading = false;
	}

	void updateBulletText()
	{
		bulletsText.text = bullets + " | " + maxBullets;
	}
}
