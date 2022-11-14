using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pvr_UnitySDKAPI;

public class ChangeWeapon : MonoBehaviour {

	public GameObject sword;
	public GameObject pistol;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Controller.UPvr_GetKeyDown(0, Pvr_KeyCode.VOLUMEUP) ||Input.GetKeyDown("x")) {
			if (sword.active) {
				sword.SetActive(false);
				pistol.SetActive(true);
			} else {
				pistol.SetActive(false);
				sword.SetActive(true);
			}
		}
	}
}
