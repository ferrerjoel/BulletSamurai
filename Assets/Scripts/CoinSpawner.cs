using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour {

	public List<GameObject> spawnPositions;
	public GameObject coin;

	private GameObject spider;

	private const byte COINS_TO_SPAWN = 5;
	private const byte SPIDERS_TO_SPAWN = 5; // On every coin position that is choosen


	// Use this for initialization
	void Start () {

		spider = GameObject.FindWithTag("Reference spider");

		for (int i = 0; i < COINS_TO_SPAWN; i++) {
			int r = Random.Range(0, spawnPositions.Count);
			Instantiate(coin, spawnPositions[r].gameObject.transform.position, coin.transform.rotation);
			for (int j = 0; j < SPIDERS_TO_SPAWN; j++){
				Instantiate(spider, spawnPositions[r].gameObject.transform.position, spider.transform.rotation);
			}
			
			spawnPositions.RemoveAt(r);
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
