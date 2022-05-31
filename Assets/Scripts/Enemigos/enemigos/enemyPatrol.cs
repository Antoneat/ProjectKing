using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyPatrol : MonoBehaviour
{

	public float Speed;
	//public float damping = 6.0f;

	public UnityEngine.AI.NavMeshAgent agent;

	public int destPoint = 0;
	public Transform goal;

	public float playerDistance;
	public float awareAI;
	public float atkRange;
	public Enemy ee;

	void Start()
	{
		UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
		

		agent.autoBraking = false;


		goal = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	}

	void Update()
	{
		playerDistance = Vector3.Distance(transform.position, goal.position);

		if (playerDistance <= awareAI)
		{
			LookAtPlayer();
			Debug.Log("Seen");
			Chase();
		}
		else if (playerDistance > awareAI)
		{
			LookAtPlayer();
		}


		if (playerDistance <= atkRange)
		{
			ee.ChooseAtk();
		}
		else if (playerDistance > atkRange )
		{
			LookAtPlayer();
		}
	}

	void LookAtPlayer()
	{
		transform.LookAt(goal);
	}



	public void Chase()
	{
		
		transform.Translate(Vector3.forward * Speed * Time.deltaTime);
		//agent.SetDestination(goal.transform.position);
		agent.destination = goal.position;
	}


}
