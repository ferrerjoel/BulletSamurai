using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {

	public Player playerScript;

	public int minWaitSound;
	public int maxWaitSound;

	public AudioSource deathSound;
	public AudioSource spiderSound;

	public Animation spiderAnimations; 

	// IA

	public UnityEngine.AI.NavMeshAgent agent;

	public Transform player;

	public LayerMask whatIsGround, whatIsPlayer;

	// Patroling

	public Vector3 walkPoint;
	bool walkPointSet;
	public float walkPointRange;

	// Attacking
	public float timeBetweenAttacks;
	bool isAtacking;

	//States
	public float sightRange, attackRange;
	public bool playerIsInSight, playerIsInAttackRange;

	private bool isAlive = true;

	public byte hitAttack;

	private void Start()
	{
		player = playerScript.gameObject.transform;
		agent = GetComponent<NavMeshAgent>();
		StartCoroutine(enemySoundWait());
	}

	private void Update()
	{
		playerIsInSight = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
		playerIsInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

		if (!playerIsInSight && !playerIsInAttackRange && isAlive) Patroling();
		if (playerIsInSight && !playerIsInAttackRange && isAlive)
		{
			ChasePlayer();
			spiderAnimations.Play("run");
		} 
		if (playerIsInAttackRange && playerIsInSight && isAlive) ChasePlayer();

	}

	private IEnumerator enemySoundWait()
	{
		while (isAlive){
			yield return new WaitForSeconds(Random.Range(minWaitSound, maxWaitSound+1));
			spiderSound.Play();
		}
		
	}

	private void Patroling()
	{
		if (!walkPointSet) SearchWalkPoint();

		if (walkPointSet) agent.SetDestination(walkPoint);

		Vector3 distanceToWalkPoint = transform.position - walkPoint;

		// Walkpoint reached

		if (distanceToWalkPoint.magnitude < 1f) walkPointSet = false;
	}

	private void SearchWalkPoint()
	{
		float randomZ = Random.Range(-walkPointRange, walkPointRange);
		float randomX = Random.Range(-walkPointRange, walkPointRange);
		walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

		if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround)) walkPointSet = true;
	}

	private void ChasePlayer()
	{
		agent.SetDestination(player.position);
	}

	private void AttackPlayer()
	{

	}

	// LEGACY CODE
	public void takeHit()
	{
		isAlive = false;
		deathSound.Play();
		spiderAnimations.Play("death1");
		StartCoroutine(removeSpider(15));
	}

	public IEnumerator removeSpider(int seconds)
	{
		yield return new WaitForSeconds(seconds);
		Destroy(gameObject);
	}

	private void OnTriggerEnter(Collider other) {
		Debug.Log ("COLLISION");

		if (other.CompareTag("Sword") && isAlive)
		{
			takeHit();
		}

		if (other.CompareTag("jugador") && isAlive)
		{

			playerScript.LoseLife(hitAttack);

		}
	}
}
