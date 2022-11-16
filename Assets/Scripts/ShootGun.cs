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

	public Text textUI;

	void Start () {
		
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
		textUI.text = "HOLA";
		particlesShoot.Play();
		shootSound.Play();

		RaycastHit hit;
		
		if (Physics.Raycast(gun.transform.position, gun.transform.forward, out hit))
		{
			textUI.text = hit.transform.name;
			Enemy enemy = hit.transform.GetComponent<Enemy>();
			if (enemy != null)
			{
				enemy.takeHit();
			}

			GameObject impact = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
			Debug.Log("HOLA");
			Destroy(impact, 2f);
		}
	}
}
