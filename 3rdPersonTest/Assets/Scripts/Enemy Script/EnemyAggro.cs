using UnityEngine;
using System.Collections;

public class EnemyAggro : MonoBehaviour {

	private GameObject hero;
	public float range;
	public float speed;
	public bool aggressive;


	//terrain limit
	private float limitSupX;
	private float limitInfX;
	private float limitSupZ;
	private float limitInfZ;

	//random movement
	private Vector3 patrolPosition;
	private bool inPatrolPosition;

	void Start () {

		hero=GameObject.FindGameObjectWithTag("Character");
		inPatrolPosition = true;
		limitSupX = transform.parent.position.x + GetComponentInParent<EnemySpawner>().range;
		limitInfX = transform.parent.position.x - GetComponentInParent<EnemySpawner>().range;
		limitSupZ = transform.parent.position.z + GetComponentInParent<EnemySpawner>().range;
		limitInfZ = transform.parent.position.z - GetComponentInParent<EnemySpawner>().range;
	}



	// Update is called once per frame
	void Update () {
		float dist = Mathf.Abs (Vector3.Distance(hero.transform.position,transform.position));
		float step = speed * Time.deltaTime;
		if (aggressive & (dist <= range) ) {
			//transform.LookAt(hero.transform.position);
			//move towards the player
			transform.rotation = Quaternion.Slerp(transform.rotation,
			                                        Quaternion.LookRotation(hero.transform.position - transform.position), /*rotation*/speed*Time.deltaTime);
			transform.position += transform.forward * speed * Time.deltaTime;

			Vector3.MoveTowards(transform.position,hero.transform.position,step);
		}
		else if ((dist > range) || !aggressive)
		{
			if(inPatrolPosition)
			{
			Vector3 Temp = Random.onUnitSphere;
			float TempDistance = Random.Range(0, 10);
			Temp = Temp * TempDistance;
			Vector3 FinalTemp = new Vector3(Temp.x, 0, Temp.z);

			patrolPosition=transform.position + FinalTemp;
				inPatrolPosition=false;
				//Debug.Log (	patrolPosition);
			}
			else 
			{
				transform.position=Vector3.MoveTowards(transform.position,patrolPosition,2*Time.deltaTime);
				if(Vector3.Distance(transform.position,patrolPosition)==0)
					inPatrolPosition=true;
			}
		}


	
	}
}
