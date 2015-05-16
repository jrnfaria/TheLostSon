using UnityEngine;
using System.Collections;

public class HealthBarController : MonoBehaviour {

	private GameObject greenBar;
	private GameObject redBar;
	public GameObject enemyBody;
	private EnemyHealth enemyHealth;

	public Vector3 offset;



	void Start () {
		greenBar = transform.FindChild ("Green").gameObject;
		redBar = transform.FindChild ("Red").gameObject;
		enemyHealth = enemyBody.GetComponent<EnemyHealth> ();
	}
	
	// Update is called once per frame
	void Update () {
		Transform cam = Camera.main.transform;
		//Debug.Log (enemyHealth.getHealthRatio());
		redBar.transform.position = enemyBody.transform.position+offset;


		greenBar.transform.position = enemyBody.transform.position+offset;
		greenBar.transform.localScale = new Vector3 (greenBar.transform.localScale.x,1,greenBar.transform.localScale.z*enemyHealth.getHealthRatio());

		redBar.transform.LookAt (cam);

		greenBar.transform.LookAt (cam,new Vector3(1,0,0));

	}
}
