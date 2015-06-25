using UnityEngine;
using System.Collections;

public class ExitMenu : MonoBehaviour {
	
	//resize
	private float virtualWidth = 1920.0f;
	private float virtualHeight = 1080.0f;
	Matrix4x4 matrix;
	public GUISkin customSkin;
	public bool show=false;
	
	// Use this for initialization
	void Start () {
		matrix = Matrix4x4.TRS (Vector3.zero, Quaternion.identity,new  Vector3(Screen.width/virtualWidth, Screen.height/virtualHeight, 1.0f));
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown (KeyCode.Escape)){
			show=!show;
		}
	}
	
	void OnGUI(){
		if(show){
			GUI.matrix = matrix;
			GUI.skin = customSkin;
			
			GUI.Box (new Rect (860, 440, 200, 230), "\nSettings");

			if (GUI.Button (new Rect (880, 510, 160, 40), "Resume")) {//Resume
				show=false;
			}
			if (GUI.Button (new Rect (880, 560, 160, 40), "Back to menu")) {//Back to menu
				Application.LoadLevel(1);
			}
			if (GUI.Button (new Rect (880, 610, 160, 40), "Exit game")) {//Exit game
				Application.Quit();
			}
		}
	}
}
