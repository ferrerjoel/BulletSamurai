using UnityEngine;

public class Enemy : MonoBehaviour {

	// Use this for initialization
	public void takeHit()
	{
		Destroy(gameObject);
	}

	private void OnTriggerEnter(Collider other) {
		Debug.Log ("COLLISION");

		if (other.CompareTag("Sword"))
		{
			Destroy(gameObject);
		}
	}
}
