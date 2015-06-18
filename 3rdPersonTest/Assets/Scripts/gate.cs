using UnityEngine;
using System.Collections;

public class gate : MonoBehaviour {

	public int dimension;

	// Use this for initialization
	void Start () {
	}


	void OnTriggerEnter(Collider other) {
		if (other.transform.tag == "Character") {
			Application.LoadLevel (dimension);

		}

	}


	// Update is called once per frame
	void Update () {
	
	}
}
