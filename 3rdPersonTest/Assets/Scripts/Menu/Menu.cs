using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	//Objects
	public GameObject menu;
	public GameObject loading;

	void Start () {
		menu.SetActive (true);
		loading.SetActive (false);
	}


	void Update()
	{

	}
}
