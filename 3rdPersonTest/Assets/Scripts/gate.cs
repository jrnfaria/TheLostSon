using UnityEngine;
using System.Collections;

public class gate : MonoBehaviour {

	public int dimension;
	public Vector3 beginPosition;

	private GameObject HUD;
	private GameObject inventory;
	private GameObject Tyson;


	// Use this for initialization
	void Start () {
		HUD = GameObject.FindGameObjectWithTag ("HUD");
		inventory = GameObject.FindGameObjectWithTag ("Inventory");
		Tyson= GameObject.FindGameObjectWithTag ("Character");

	}


	void OnTriggerEnter(Collider other) {
		if (other.transform.tag == "Character") {
			DontDestroyOnLoad(HUD);
			DontDestroyOnLoad(inventory);
			DontDestroyOnLoad(Tyson);
			DontDestroyOnLoad(Camera.main);

			Application.LoadLevel (dimension);
			Tyson.transform.position=beginPosition;

		}

	}


	// Update is called once per frame
	void Update () {
	
	}
}
