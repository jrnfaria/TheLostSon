using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {
	
	public GameObject explosionPrefab;
	public float fuseTime;
	private bool explode=false;
	
	void Start() {
	}
	
	void Update() {
	}
	
	void Explode() {
		if(explode){
			Instantiate (explosionPrefab, this.transform.position, Quaternion.identity);
			GameObject.FindGameObjectWithTag("Character").GetComponent<CharacterStatus>().takeDamage(20);
			Destroy (gameObject);
			Destroy (transform.parent.gameObject, 0.2f);
		}
	}
	
	void OnTriggerEnter(Collider other) {
		if (other.name == "Tyson") {
			explode=true;
			CancelInvoke("Explode");
			Invoke("Explode", fuseTime);
		}
	}
	
	void OnTriggerExit(Collider other) {
		if (other.name == "Tyson") {
			explode=false;
		}
	}
}
