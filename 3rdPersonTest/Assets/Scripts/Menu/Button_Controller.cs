using UnityEngine;
using System.Collections;

public class Button_Controller : MonoBehaviour {

	public void Exit_Game(){
		Application.Quit ();
	}

	public void Start_Game(){
		Application.LoadLevel(4);
	}
}