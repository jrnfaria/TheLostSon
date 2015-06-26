using UnityEngine;
using System.Collections;

public class minimap : MonoBehaviour {
	
	public Texture aTexture;
	public RenderTexture minimapTexture;
	public Material minimapMaterial;

	private float virtualWidth = 1920.0f;
	private float virtualHeight = 1080.0f;
	private Matrix4x4 matrix;

	void Awake(){
		matrix = Matrix4x4.TRS (Vector3.zero, Quaternion.identity,new  Vector3(Screen.width/virtualWidth, Screen.height/virtualHeight, 1.0f));
	}

	void OnGUI(){
		GUI.matrix = matrix;

		if (Event.current.type == EventType.Repaint) {
			Graphics.DrawTexture (new Rect (1615, 90, 225, 250), minimapTexture, minimapMaterial);
		}
		GUI.DrawTexture(new Rect(1495, 0, 455, 450), aTexture);
	}
}
