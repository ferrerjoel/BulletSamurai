using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour {

	public List<GameObject> spawnPositions;
	public GameObject coin;

	// Use this for initialization
	void Start () {

		for (int i = 0; i < 5; i++) {
			int r = Random.Range(0, spawnPositions.Count);
			Instantiate(coin, spawnPositions[r].gameObject.transform.position, coin.transform.rotation);
			spawnPositions.RemoveAt(r);
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
