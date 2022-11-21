using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {

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

	private void Start()
	{
		player = GameObject.Find("jugador").transform;
		agent = GetComponent<NavMeshAgent>();
	}

	private void Update()
	{
		playerIsInSight = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
		playerIsInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

		if (!playerIsInSight && !playerIsInAttackRange) Patroling();
		if (playerIsInSight && !playerIsInAttackRange) ChasePlayer();
		if (playerIsInAttackRange && playerIsInSight) ChasePlayer();

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
		Destroy(gameObject);
	}

	private void OnTriggerEnter(Collider other) {
		Debug.Log ("COLLISION");

		if (other.CompareTag("Sword"))
		{
			Destroy(gameObject);
		}
	}
}
