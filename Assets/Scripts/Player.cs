using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

	private const byte COINS_TO_WIN = 3;
    public int life = 100;
	private bool canTakeDamage = true;

	public Text userText;

	public AudioSource hitSound;
	public AudioSource deathSound;
	public AudioSource winSound;

	public bool hasWon;

	private byte collectedCoins = 0;

    // Use this for lose
    void Start()
    {
		userText.text = "\n\n\n" + life;
    }

    // Update is called once per frame
    void Update()
    {
        if (life <= 0f)
        {
			userText.text = "\n\n\nDED";
			canTakeDamage = false;
			deathSound.Play();
			StartCoroutine(DeathCooldown(5));
        }
    }

	public void LoseLife(byte points)
	{
		if (canTakeDamage)
		{
			canTakeDamage = false;
			life -= points;
			hitSound.Play();
			userText.text = "\n\n\n" + life;
			StartCoroutine(DamageCooldown());
		}
	}

	IEnumerator DamageCooldown()
	{
		yield return new WaitForSeconds(2);
		canTakeDamage = true;
	}

	IEnumerator DeathCooldown(int seconds)
	{
		yield return new WaitForSeconds(seconds);
		Application.Quit();
	}

	private void OnTriggerEnter(Collider other) {

		if (other.CompareTag("Flag"))
		{
			collectedCoins++;

			if (collectedCoins >= COINS_TO_WIN) {

				hasWon = true;
				
				if (life <= 0) {
					userText.text = "\n\n\n YOU HAVE WON! You have been lucky...";
				} else {
					userText.text = "\n\n\n YOU HAVE WON!";
				}

				StartCoroutine(DeathCooldown(10));
				
			}
			
			
		}
	}
}
