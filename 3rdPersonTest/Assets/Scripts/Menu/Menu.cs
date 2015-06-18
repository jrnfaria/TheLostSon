using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	//Objects
	public Texture background;
	public Texture loading;

	//resize
	private float virtualWidth = 1920.0f;
	private float virtualHeight = 1080.0f;
	private bool hasBeenPressed = false;
	Matrix4x4 matrix;

	void Start () {
		matrix = Matrix4x4.TRS (Vector3.zero, Quaternion.identity, new  Vector3 (Screen.width / virtualWidth, Screen.height / virtualHeight, 1.0f));
	}


	void OnGUI()
	{
		GUI.matrix = matrix;
		GUI.DrawTexture(new Rect(0,0,virtualWidth,virtualHeight), background);
		GUIStyle myStyle = new GUIStyle (GUI.skin.button);
		myStyle.fontSize = 48;
		if (!hasBeenPressed)
		{
			if (GUI.Button (new Rect (150, 300, 450 , 100), "Start Game", myStyle)){
				hasBeenPressed = true;
				background = loading;

				Application.LoadLevel (1);
			}
			if(GUI.Button (new Rect (150, 500, 450 , 100), "Exit Game", myStyle))	{		
				hasBeenPressed = true;
				Application.Quit ();
			}
		}

	}
}
