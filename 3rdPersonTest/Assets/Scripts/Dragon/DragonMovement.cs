using UnityEngine;
using System.Collections;

public class DragonMovement : MonoBehaviour {
	
	private GameObject hero;
	
	// Use this for initialization
	void Start () {
		hero = GameObject.FindGameObjectWithTag ("Character");
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(hero.transform.position.x,transform.position.y,hero.transform.position.z);
		transform.LookAt (hero.transform.forward);
	}
}
