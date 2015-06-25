using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Borders : MonoBehaviour {

	public Text text;
	public string name;
	void Start () {
	
	}
	
	void OnTriggerEnter(Collider other) {
		if (other.tag == "Character")
			text.text = name;
	}

	void OnTriggerExit(Collider other) {
		if (other.tag == "Character")
			text.text = "Wilderness";
	}
}
