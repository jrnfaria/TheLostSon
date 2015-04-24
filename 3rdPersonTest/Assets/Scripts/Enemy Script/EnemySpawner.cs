using UnityEngine;
using System.Collections;


public class EnemySpawner : MonoBehaviour {

	public GameObject enemy;
	public int maxNumOfEnemies;
	public float range;
	public string tag;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.FindGameObjectsWithTag (tag).Length < maxNumOfEnemies) {
			GameObject enem = Instantiate (enemy, new Vector3 (transform.position.x + Random.Range (-range, range), transform.position.y, transform.position.z + Random.Range (-range, range)), Quaternion.identity) as GameObject;
			enem.transform.parent = transform;
		}
	}
}
