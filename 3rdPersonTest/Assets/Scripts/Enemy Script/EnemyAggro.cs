using UnityEngine;
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
	private bool attacking;

	void Start () {

		hero = GameObject.FindGameObjectWithTag ("Character");
		nav = GetComponent<NavMeshAgent>();
		anim=GetComponent<Animator>();
		attacking = false;

		initialPosition = this.transform.parent.transform.position;

		patrolPosition=new Vector3();
		inDestiny = true;
		followingHero = false;
		attacking = false;
	}



	// Update is called once per frame
	void Update () {
		if (attacking == false) {
			nav.Resume();
			if (Vector3.Distance (hero.transform.position, nav.transform.position) <= heroDetectionRange && aggressive) {
				ChaseHero ();
			} else {
				if (inDestiny) {
					CalculatePatrolPoint ();
				} else {
					nav.destination = patrolPosition;

					if (nav.remainingDistance == 0)
						inDestiny = true;
				}
				followingHero = false;
				anim.SetBool ("chasing", false);
				nav.speed = 8;
			}
		} else
			nav.Stop ();
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
		nav.speed=20;
	}

	void OnTriggerEnter(Collider other) {
		if (other.transform.tag == "Character") {
			if(attacking==false)
			{
			attacking=true;
			Invoke("attack",1f);
			}
		}
	}

	void attack()
	{
		if (attacking == true) {
			anim.SetTrigger("attacking");
			hero.GetComponent<CharacterStatus>().takeDamage(20);
			Invoke("attack",1f);
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.transform.tag == "Character") {
			attacking=false;
		}
	}

}
