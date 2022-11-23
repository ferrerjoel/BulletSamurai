using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int life = 100;
	private bool canTakeDamage = true;

	public Text userText;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (life == 0f)
        {

        }


    }

	public void LoseLife(byte points)
	{
		if (canTakeDamage)
		{
			canTakeDamage = false;
			life -= points;
			userText.text = "" + life;
			StartCoroutine(DamageCooldown());
		}
	}

	IEnumerator DamageCooldown()
	{
		yield return new WaitForSeconds(3);
		canTakeDamage = true;
	}
}
