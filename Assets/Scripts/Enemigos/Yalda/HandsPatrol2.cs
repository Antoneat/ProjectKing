using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandsPatrol2 : MonoBehaviour
{

	public Transform player;
	public float Speed;
	//public float playerDistance;
	//public float awareAI = 20f;
	//public float damping = 6.0f;


	//public Transform[] goals;
	public UnityEngine.AI.NavMeshAgent agent;

	public Transform goal1;
	public Transform goal2;
	public Transform goal3;
	public Transform goal4;
	

	void Start()
	{
		UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();


		agent.autoBraking = false;
	}

	void Update()
	{

		LookAtPlayer();
	}

	void LookAtPlayer()
	{
		transform.LookAt(player);
	}


	public void GotoNextPoint1()
	{
		agent.destination = goal1.position;

	}

	public void GotoNextPoint2()
	{

		agent.destination = goal2.position;
	}

	public void GotoNextPoint3()
	{
		agent.destination = goal3.position;

	}
	public void GotoNextPoint4()
	{

		agent.destination = goal4.position;
	}


}
