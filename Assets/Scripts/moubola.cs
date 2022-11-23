using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//CODI INSPIRAT EN  https://www.youtube.com/watch?v=jxoY5kBtCRQ

public class moubola : MonoBehaviour {
	public float rangoDeAlerta;
	public LayerMask capaDelJugador;
	public Transform jugador;
	bool estarAlerta;
	private AudioSource source;
	public float velocitat=0.1f;
	public AudioClip sofantasma;
	public AudioClip mossegada;
	public AudioClip espasa;
	private Vector3 vinicial;
	private float contadorToques=0f;
	// Use this for initialization
	void Start () {
			
		source = GetComponent<AudioSource>();	
		vinicial = transform.parent.position;
	}
	
	// Update is called once per frame
	void Update () {
		//defineix un rang d'alerta que detecta si el jugador esta a prop 
		estarAlerta=  Physics.CheckSphere(transform.position,rangoDeAlerta,capaDelJugador);
		if (estarAlerta==true) 
			{

				transform.parent.LookAt(jugador);
				transform.parent.position=Vector3.MoveTowards(transform.parent.position, jugador.position,velocitat*Time.deltaTime);
				if (!source.isPlaying)
        		{
				source.clip=sofantasma;
       			source.Play();
				}
		} 
	}

	private void  OnTriggerEnter(Collider other) {
		Debug.Log ("COLLISION");

		if (other.CompareTag("espasa"))
		{
			Debug.Log ("te ha tocat la espasa ");
				
			//ves a la casilla de sortidaç
			contadorToques++;
			if (contadorToques>0)
				{
					//so de espassa
					source.Stop();
					source.clip=espasa;
       				source.Play();
					//so de morir
					//va al inici
					transform.parent.position=vinicial;
					contadorToques=0;
				}
		}
		else
		{
			if (other.CompareTag("jugador"))
			{
			Debug.Log ("te ha tocat el player ");
			source.Stop();
			source.clip=mossegada;
			source.Play();

			//li treu vida
			//creem una instancia de classe mouespasa
			MoveSword me;
			me=FindObjectOfType<MoveSword>();
			// me.vida=me.vida-5;
			
			//mou el fantasma una mica
			Vector3 pos=transform.parent.position;
			Vector3 posjugador=jugador.transform.parent.position;
			pos.y=pos.y+0.5f;
			if (posjugador.z>pos.z) {pos.z=pos.z-0.7f;} else {pos.z=pos.z+0.7f;}
			if (posjugador.x>pos.x) {pos.x=pos.x-0.7f;} else {pos.x=pos.x+0.7f;}
			transform.parent.position=pos;
			}
		}
	}

	private void OnDrawGizmos() {
		Gizmos.DrawWireSphere(transform.position, rangoDeAlerta);
	}
}
