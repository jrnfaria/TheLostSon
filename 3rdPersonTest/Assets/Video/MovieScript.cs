using UnityEngine;
using System.Collections;

public class MovieScript : MonoBehaviour {

	private MovieTexture movTex;
	private AudioSource sound;

	// Use this for initialization
	void Start () {
		float height = Camera.main.orthographicSize * 1/5.0f;
		float width = (float)(height * Screen.width / Screen.height);
		transform.localScale = new Vector3(width, 0.1f,height);

		movTex = (MovieTexture)GetComponent<Renderer>().material.mainTexture;
		movTex.loop = false;
		sound = GetComponent<AudioSource> ();
		sound.Play ();
		movTex.Play();

	}
	
	// Update is called once per frame
	void Update () {


		if (Input.GetKey (KeyCode.Escape) || Input.GetKey (KeyCode.KeypadEnter)|| Input.GetKey (KeyCode.Return)|| !movTex.isPlaying) {
			end ();
		}
	}

	void end()
	{
		sound.Stop();
		movTex.Stop();
		Application.LoadLevel (1);
	}
}
