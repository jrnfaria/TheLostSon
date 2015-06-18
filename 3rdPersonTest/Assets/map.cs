using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class map : MonoBehaviour {

	public Image frame;
	// Use this for initialization
	void Start () 
	{
		// set the desired aspect ratio (the values in this example are
		// hard-coded for 16:9, but you could make them into public
		// variables instead so you can set them at design time)
		float targetaspect = 16f / 9f;
		
		// determine the game window's current aspect ratio
		float windowaspect = (float)Screen.width / (float)Screen.height;
		
		// current viewport height should be scaled by this amount
		float scaleheight = windowaspect / targetaspect;
		
		// obtain camera component so we can modify its viewport
		Camera camera = GetComponent<Camera>();

		Rect rect = camera.rect;

		camera.rect = frame.rectTransform.rect;
	

	}
}
