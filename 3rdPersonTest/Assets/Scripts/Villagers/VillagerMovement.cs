using UnityEngine;
using System.Collections;

public class VillagerMovement : MonoBehaviour {

	private bool inDestiny;
	private Vector3 initialPosition;
	private NavMeshAgent nav; 

	private Vector3 patrolPosition;

	public int patrolRange;


	void Start () {
		inDestiny = false;
		initialPosition = transform.position;
		nav = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
		if (inDestiny) {
			CalculatePatrolPoint ();
		} 
		if (nav.remainingDistance == 0)
			inDestiny = true;

	}

	void CalculatePatrolPoint()
	{
		Vector3 randomDirection = Random.insideUnitSphere * patrolRange;
		
		randomDirection += initialPosition;
		NavMeshHit hit;
		NavMesh.SamplePosition(randomDirection, out hit, patrolRange, 1);
		patrolPosition = hit.position;
		
		inDestiny=false;
		nav.destination = patrolPosition;
	}
}
