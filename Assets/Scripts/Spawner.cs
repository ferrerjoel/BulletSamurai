using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public GameObject spider;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.childCount <= 1)
		{
			var instance = Instantiate(spider, gameObject.transform.position, Quaternion.identity);
			instance.transform.parent = gameObject.transform;
		}
	}
}
