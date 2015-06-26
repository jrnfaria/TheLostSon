using UnityEngine;
using System.Collections;

public class minimap : MonoBehaviour {
	
	public Texture aTexture;
	public RenderTexture minimapTexture;
	public Material minimapMaterial;

	private float virtualWidth = 1920.0f;
	private float virtualHeight = 1080.0f;
	private Matrix4x4 matrix;

	public string text = "Blue Mill";
	private GUIStyle style;

	void Awake(){
		style = new GUIStyle ();
		style.normal.textColor = Color.black;
		style.fontSize = 20;

		matrix = Matrix4x4.TRS (Vector3.zero, Quaternion.identity,new  Vector3(Screen.width/virtualWidth, Screen.height/virtualHeight, 1.0f));
		aTexture =  (Texture) Resources.Load("stats/mapa_quadrado");
	}

	void OnGUI(){
		GUI.matrix = matrix;

		if (Event.current.type == EventType.Repaint) {
			Graphics.DrawTexture (new Rect (1615, 90, 225, 250), minimapTexture, minimapMaterial);
		}
		GUI.DrawTexture(new Rect(1495, 0, 455, 450), aTexture);
		GUI.Label (new Rect (1695, 45, 100, 100), text, style);
	}
}
