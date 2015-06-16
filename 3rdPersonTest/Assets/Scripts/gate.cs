using UnityEngine;
using System.Collections;

public class gate : MonoBehaviour {

	public int dimension;
	public Vector3 beginPosition;
	private GameObject HUD;
	private GameObject inventory;


	// Use this for initialization
	void Start () {
		HUD = GameObject.FindGameObjectWithTag ("HUD");
		inventory = GameObject.FindGameObjectWithTag ("Inventory");
	}


	void OnTriggerEnter(Collider other) {
		if (other.transform.tag == "Character") {
			DontDestroyOnLoad(other.transform.gameObject);
			DontDestroyOnLoad(HUD);
			DontDestroyOnLoad(inventory);
			DontDestroyOnLoad(Camera.main.gameObject);
			other.transform.position=beginPosition;
			Application.LoadLevel (dimension);
		}

	}


	// Update is called once per frame
	void Update () {
	
	}
}
