using UnityEngine;
using System.Collections;

public class EnemyName : MonoBehaviour {

	public Transform enemy; //enemy's transform
	public Vector3 positionOffset = Vector3.up; //offset relative to enemy's origin, so it doesn't, say, draw the text at the enemy's feet

	// Use this for initialization
	public void Start() {
		transform.position = enemy.position + positionOffset;
		transform.LookAt (Camera.main.transform);
		//transform.localEulerAngles = new Vector3 (180, 0, 0);
		//transform.parent = enemy;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = enemy.position + positionOffset;
		transform.LookAt (2 * transform.position-Camera.main.transform.position);
		//transform.localEulerAngles = new Vector3 (0, 180, 0);


	}
}
