using UnityEngine;
using System.Collections;

public class minimenu : MonoBehaviour {

	//resize
	private float virtualWidth = 1920.0f;
	private float virtualHeight = 1080.0f;
	Matrix4x4 matrix;
	public GUISkin customSkin;

	public Texture aTexture;

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
		
		GUI.DrawTexture(new Rect(1590, 850, 300, 300), aTexture);

		if (GUI.Button (new Rect (1605, 955, 50, 80), "")) {//character
			Debug.Log("character");
			CharacterMenu cm = gameObject.GetComponent<CharacterMenu>();
			cm.show=!cm.show;
		}else if (GUI.Button (new Rect (1660, 955, 50, 80), "")) {//inventory
			Debug.Log("inventory");
			Inventory inv = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
			inv.show=!inv.show;
		}else if (GUI.Button (new Rect (1715, 955, 50, 80), "")) {//status
			Debug.Log("status");
			StatusMenu sm = gameObject.GetComponent<StatusMenu>();
			sm.show=!sm.show;
		}else if (GUI.Button (new Rect (1770, 955, 50, 80), "")) {//quests
			Debug.Log("quests");
			QuestViewer qview = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<QuestViewer>();
			qview.setShowInfoQuestMenu();
		}else if (GUI.Button (new Rect (1825, 955, 50, 80), "")) {//settings
			Debug.Log("settings");
			ExitMenu em = gameObject.GetComponent<ExitMenu>();
			em.show=!em.show;
		}

	}
}
