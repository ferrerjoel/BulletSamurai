using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveSword : MonoBehaviour {
	public float anterior;
	private AudioSource source;
	public AudioClip espasa;
	public AudioClip morir;
	public float dist;
	public Text textUI;
	public GameObject gameobjectJugador;
	public int vida=100;
	// Use this for initialization
	void Start () {
		//diferencia entre el vector de espasa i el de personatge
		anterior=Vector3.Distance(this.transform.position,gameobjectJugador.transform.position);
			
		source = GetComponent<AudioSource>();
		StartCoroutine("sonaFerro");
		
	}

	IEnumerator sonaFerro(){
		for (;;){

				
				yield return new WaitForSeconds (0.1f);
				//cada 0.1f passa per aquí
				dist=Vector3.Distance(this.transform.position,gameobjectJugador.transform.position);
				float diferencia = dist-anterior;
				anterior=dist;
				
				//textUI.text= "ant:"+anterior.ToString("0.000")+"\n ";
				//textUI.text= textUI.text+"ara:"+dist.ToString("0.000")+"\n ";
				//textUI.text= textUI.text+"dif:"+diferencia.ToString("0.000")+"\n";
				if (diferencia>0.07f || diferencia<-0.07f)
				{
						//textUI.text=textUI.text +"SONA \n\n";
						//sona ferro al aire
						if (!source.isPlaying)
						{
					
						source.clip=espasa;
						source.Play();
						}

				}
				
				
		}
	}
	
	// Update is called once per frame
	void Update () {
		//if (vida>0) textUI.text= "\n \n \n \n \n \n"+vida.ToString("0")+"\n ";
		if (vida==0f) {
			
			if (!source.isPlaying){
						Debug.Log ("musica morir");
						source.clip=morir;
						source.Play();
						}
			}
		if (vida<0){
			textUI.text= "\n \n \n \n\n \nGAME OVER! \n ";
			Debug.Log("VIDA <0");
			if (!source.isPlaying){
						Debug.Log ("FINAL del tot");
						Application.Quit();
						}
			}
	}
				
		
}
