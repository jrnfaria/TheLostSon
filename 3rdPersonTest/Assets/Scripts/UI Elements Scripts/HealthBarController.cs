using UnityEngine;
using System.Collections;

public class HealthBarController : MonoBehaviour {

	private GameObject greenBar;
	private GameObject redBar;
	private GameObject enemyBody;

	public Vector3 offset;



	void Start () {
		greenBar = transform.FindChild ("Green").gameObject;
		redBar = transform.FindChild ("Red").gameObject;
		enemyBody=transform.parent.FindChild ("Enemy").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		greenBar.transform.position = enemyBody.transform.position+offset;
		redBar.transform.position = enemyBody.transform.position+offset;
	}
}
