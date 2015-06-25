using UnityEngine;
using System.Collections;

public class minimap : MonoBehaviour {

	public int xPos,yPos,width,height;
	private float ratioX,ratioY,ratio;
	// Use this for initialization
	void Start () {
		ratioX = Screen.width/1920f;
		ratioY = Screen.height/1080f;
		ratio = Camera.main.aspect;
		}
	
	// Update is called once per frame
	void Update () {
		ratioX = Screen.width/1920f;
		ratioY = Screen.height/1080f;
		ratio = Camera.main.aspect;

		Debug.Log (ratio);

		if(ratio>=1.7)
			transform.GetComponent<Camera>().pixelRect = new Rect(Screen.width - 264*ratioX, Screen.height - 302*ratioY, 223*ratioX, 222*ratioY);
		else if(ratio>=1.5)
			transform.GetComponent<Camera>().pixelRect = new Rect(Screen.width - 280*ratioX, Screen.height - 293*ratioY, 230*ratioX, 222*ratioY);
		else if(ratio>=1.33||ratio>=1.25)
			transform.GetComponent<Camera>().pixelRect = new Rect(Screen.width - 311*ratioX, Screen.height - 262*ratioY, 253*ratioX, 200*ratioY);
	}
}
