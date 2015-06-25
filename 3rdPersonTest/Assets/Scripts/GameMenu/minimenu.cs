﻿using UnityEngine;
using System.Collections;

public class minimenu : MonoBehaviour {

	//resize
	private float virtualWidth = 1920.0f;
	private float virtualHeight = 1080.0f;
	Matrix4x4 matrix;
	public GUISkin customSkin;

	// Use this for initialization
	void Start () {
		matrix = Matrix4x4.TRS (Vector3.zero, Quaternion.identity,new  Vector3(Screen.width/virtualWidth, Screen.height/virtualHeight, 1.0f));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		GUI.matrix = matrix;
		GUI.skin = customSkin;

		if (GUI.Button (new Rect (1627, 945, 43, 90), "")) {//character
			Debug.Log("character");
		}
		if (GUI.Button (new Rect (1675, 945, 43, 90), "")) {//inventory
			Debug.Log("inventory");
			Inventory inv = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
			inv.show=!inv.show;
		}
		if (GUI.Button (new Rect (1723, 945, 43, 90), "")) {//status
			Debug.Log("status");
		}
		if (GUI.Button (new Rect (1771, 945, 43, 90), "")) {//quests
			Debug.Log("quests");
			QuestViewer qview = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<QuestViewer>();
			qview.setShowInfoQuestMenu();
		}
		if (GUI.Button (new Rect (1819, 945, 43, 90), "")) {//settings
			Debug.Log("settings");
			ExitMenu em = gameObject.GetComponent<ExitMenu>();
			em.show=!em.show;
		}

	}
}
