using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinFlag : MonoBehaviour {

	public Player playerScript;
	public ParticleSystem coinParticles;

	private bool hasBeenGrabed;

	// Use this for initialization
	void Start () {
		playerScript = GameObject.FindWithTag("jugador").GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {

  		transform.Rotate (0,0,50*Time.deltaTime); //rotates 50 degrees per second around z axis

	}

	private void OnTriggerEnter(Collider other) {

		if (other.CompareTag("jugador") && !hasBeenGrabed)
		{
			hasBeenGrabed = true;
			coinParticles.Play();
			gameObject.GetComponent<MeshRenderer>().enabled = false;
			gameObject.GetComponent<SphereCollider>().enabled = false;
			StartCoroutine(removeCoin());
		}

	}

	IEnumerator removeCoin()
	{
		yield return new WaitForSeconds(2);
		Destroy(gameObject);
	}


	
}
