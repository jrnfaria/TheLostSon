using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Borders : MonoBehaviour {

	//public Text text;
	public string cityName;
	private minimap map;
	void Start () {
		 map = GameObject.FindGameObjectWithTag("Minimap").GetComponent<minimap>();
	}
	
	void OnTriggerEnter(Collider other) {
		if (other.tag == "Character")
			map.text = cityName;
	}

	void OnTriggerExit(Collider other) {
		if (other.tag == "Character")
			map.text = "Wilderness";
	}
}
