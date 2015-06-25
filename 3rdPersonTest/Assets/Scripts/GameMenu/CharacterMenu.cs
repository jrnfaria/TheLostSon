using UnityEngine;
using System.Collections;

public class CharacterMenu : MonoBehaviour {
	
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
		if(Input.GetKeyDown (KeyCode.C)){
			show=!show;
		}
	}
	
	void OnGUI(){
		if(show){
			GUI.matrix = matrix;
			GUI.skin = customSkin;
			
			GUI.Box (new Rect (760, 340, 400, 400), "\nCharacter");

			string text = "Hi!\n\n I'm Tyson and my father is Tie. My father is a \n\nblacksmith "+
				"and i help him many times on it. \n\nOne day my father was handing a sword to \n\n"+
				"a customer and he disappeared. I was very \n\nconcerned so I decided to go looking for it.";
			GUI.Label (new Rect (780, 440, 380, 400), text);

			if (GUI.Button (new Rect (980, 680, 160, 40), "Cancel")) {
				show=false;
			}
		}
	}
}
