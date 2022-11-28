using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int life = 100;
	private bool canTakeDamage = true;

	public Text userText;

	public AudioSource hitSound;
	public AudioSource deathSound;


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
}
