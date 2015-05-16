using UnityEngine;
using System.Collections;

public class HealthBarController : MonoBehaviour {

	//private GameObject greenBar;
	private GameObject redBar;
	public GameObject enemyBody;
	private EnemyHealth enemyHealth;

	private float healthSize;

	public Vector3 offset;



	void Start () {
		//greenBar = transform.FindChild ("Green").gameObject;
		redBar = transform.FindChild ("Red").gameObject;
		enemyHealth = enemyBody.GetComponent<EnemyHealth> ();
		healthSize = redBar.transform.localScale.x;
	}
	
	// Update is called once per frame
	void Update () {
		Transform cam = Camera.main.transform;
	

		//greenBar.transform.position = enemyBody.transform.position + offset;
		redBar.transform.position = enemyBody.transform.position+offset;
	

		//greenBar.transform.localScale = new Vector3 (healthSize*enemyHealth.getHealthRatio(),greenBar.transform.localScale.y,greenBar.transform.localScale.z);
		//redBar.transform.position -= new Vector3 (healthSize*enemyHealth.getHealthRatio()/2f,0,0);

		
		//greenBar.transform.LookAt (cam);
		redBar.transform.LookAt (cam);
	}
}
