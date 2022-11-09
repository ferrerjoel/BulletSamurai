using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pvr_UnitySDKAPI;

public class moupersonatge : MonoBehaviour {

	private Transform myTransform;
	private AudioSource source;
	public AudioClip motor1;
	public AudioClip motor2;
	public AudioClip tocabola;
	public AudioClip gira;
	public AudioClip walking;

	Vector3 movementInput;
	private CharacterController cc;
	Rigidbody rb; 
	float speed=5f;



 	private void OnCollisionEnter(Collision collision)

    {
       Debug.Log("El " + gameObject.name + " colicionó con el gamobject " + collision.gameObject.name);   
	   //source.Stop();
	   //source.clip =walking-on-gravel;
       //source.Play();
    }

	// Use this for initialization
	void Start() {
			myTransform = GetComponent<Transform>();
			source = GetComponent<AudioSource>();	
			cc=GetComponent<CharacterController>();
			
	}

	
	// Update is called once per frame
	void Update () {

		float smooth = 2.0F;
		Quaternion target;
		float velocidadTraslac = 0.5f;
    	float velocidadRotac = 45f; // X grados por segundo
		float spped=6f;

		Vector3 movementInput = Vector3.zero;
		
		if (transform.position.y < -30f)  
			{ 
			
			Debug.Log ("FIIIN");	
			Application.Quit();
			}


		if (Input.GetKey("w")) 
			{
			//myTransform.Translate(new Vector3(0, 0,1) * spped*Time.deltaTime);
			Vector3 forward = transform.TransformDirection (Vector3.forward);
			cc.SimpleMove(forward*speed);
			if (!source.isPlaying)
        		{
				source.clip=walking;
       			source.Play();
				}
			}
		if (Input.GetKey("s"))
			{
			Vector3 back = transform.TransformDirection (Vector3.back);
			cc.SimpleMove(back*speed);
			if (!source.isPlaying)
        		{
				source.clip=walking;
       			source.Play();
				}
			}
		
		if (Input.GetKey("d")) myTransform.Rotate(Vector3.up * velocidadRotac * Time.deltaTime);
		if (Input.GetKey("a")) myTransform.Rotate(Vector3.down * velocidadRotac * Time.deltaTime);
		
        

		switch (Controller.UPvr_GetTouchPadClick(0))
        	{
            case TouchPadClick.No:
				if(source.clip!=tocabola) source.Stop();
                break;
            case TouchPadClick.ClickUp:
				Vector3 forward = transform.TransformDirection (Vector3.forward);
				cc.SimpleMove(forward*spped);
                //myTransform.Translate(new Vector3(0, 0, 1) * spped * Time.deltaTime);
				if (!source.isPlaying)
        		{
				source.clip=walking;
       			source.Play();
				}
				break;
            case TouchPadClick.ClickDown:
				Vector3 back = transform.TransformDirection (Vector3.back);
				cc.SimpleMove(back*spped);
                //myTransform.Translate(new Vector3(0, 0, -1) * spped* Time.deltaTime);
				if (!source.isPlaying)
        		{
				source.clip=walking;
       			source.Play();
				}
                break;
            case TouchPadClick.ClickRight:
                myTransform.Rotate(Vector3.up * velocidadRotac * Time.deltaTime);
				if (!source.isPlaying)
        		{
				source.clip=gira;
       			source.Play();
				}
                break;
            case TouchPadClick.ClickLeft:
                myTransform.Rotate(Vector3.down * velocidadRotac * Time.deltaTime);
				if (!source.isPlaying)
        		{
				source.clip=gira;
       			source.Play();
				}
                break;
            default:
                break;
        	}
	}
}
