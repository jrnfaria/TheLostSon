﻿using UnityEngine;
using System.Collections;

public class Button_Controller : MonoBehaviour {

	//Objects
	public GameObject menu;
	public GameObject loading;

	public void Exit_Game(){
		Application.Quit ();
	}

	public void Start_Game(){
		menu.SetActive (false);
		loading.SetActive (true);
		//Application.LoadLevelAsync(1);
		if(Application.GetStreamProgressForLevel(1) ==1){//0&&1 aproveitar para fazer progress bar
			Application.LoadLevelAsync(1);
		}
	}
}