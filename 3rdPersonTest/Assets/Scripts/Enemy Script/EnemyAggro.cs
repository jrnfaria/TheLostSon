﻿using UnityEngine;
using System.Collections;

public class EnemyAggro : MonoBehaviour {

	private GameObject hero;
	private NavMeshAgent nav; 
	private Animator anim;

	public bool aggressive;

	public int heroDetectionRange;
	public int patrolRange;

	private Vector3 patrolPosition;
	private bool inDestiny;
	private Vector3 initialPosition;

	private bool followingHero;

	void Start () {

		hero = GameObject.FindGameObjectWithTag ("Character");
		nav = GetComponent<NavMeshAgent>();
		anim=GetComponent<Animator>();

		initialPosition = this.transform.parent.transform.position;

		patrolPosition=new Vector3();
		inDestiny = true;
		followingHero = false;
	}



	// Update is called once per frame
	void Update () {
		if (Vector3.Distance (hero.transform.position, nav.transform.position) <= heroDetectionRange && aggressive ) {
			ChaseHero();
		} else  {
			if (inDestiny)
			{
				CalculatePatrolPoint();
			}
			else
			{
				nav.destination=patrolPosition;

				if(nav.remainingDistance==0)
					inDestiny=true;
			}
			followingHero=false;
			anim.SetBool ("chasing",false);
			nav.speed=4;
		}

	}

	void ChaseHero()
	{
		nav.destination = hero.transform.position;
		followingHero = true;
		anim.SetBool ("chasing",true);
	}

	void CalculatePatrolPoint()
	{
		Vector3 randomDirection = Random.insideUnitSphere * patrolRange;
		
		randomDirection += initialPosition;
		NavMeshHit hit;
		NavMesh.SamplePosition(randomDirection, out hit, patrolRange, 1);
		patrolPosition = hit.position;
		
		inDestiny=false;
		nav.speed=10;
	}
}
