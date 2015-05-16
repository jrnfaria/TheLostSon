using UnityEngine;
using System.Collections;

public class QuestStart : MonoBehaviour {
	private bool isInside =false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.F) && isInside) {
			Debug.Log("OLA");
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.name == "Tyson") {
			Debug.Log("Entrei no COLLIDER");
			isInside = true;
		}
	}

	void OnTriggerExit(Collider other){
		if (other.name == "Tyson") {
			Debug.Log("Sai do COLLIDER");
			isInside = false;
		}
	}
}
