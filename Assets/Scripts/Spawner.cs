using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Spawner : MonoBehaviour {

    [SerializeField]
	public GameObject spider;
	
    void Start()
    {
        
    }
   
 
    void Update()
    {
        if (transform.childCount <= 1)
		{
			var instance = Instantiate(spider, gameObject.transform.position, Quaternion.identity);
			instance.transform.parent = gameObject.transform;
		}
    }
}
