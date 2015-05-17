using UnityEngine;
using System.Collections;

public class QuestStart : MonoBehaviour {
	private bool isInside = false;
	private bool displayedGUI = false;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.F) && isInside) {
			displayedGUI = true;
		} else if (!isInside) {
			displayedGUI=false;
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.name == "Tyson") {
			isInside = true;
		}
	}

	void OnTriggerExit(Collider other){
		if (other.name == "Tyson") {
			isInside = false;
		}
	}

	public bool isDisplayedGUI(){
		return displayedGUI;
	}

	public void setDisplayedGUI(bool displayedGUI){
		this.displayedGUI = displayedGUI;
	}
}
