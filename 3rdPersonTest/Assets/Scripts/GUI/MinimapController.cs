using UnityEngine;
using System.Collections;

public class MinimapController : MonoBehaviour {

	private bool visible;
	public GameObject miniCamera;

	void Start () {
		visible = false;
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyUp(KeyCode.M))
		{
			visible=!visible;
			miniCamera.SetActive(visible);
		}

		else if(Input.GetKeyUp(KeyCode.Z))
		{
			miniCamera.GetComponent<Camera>().orthographicSize+=20;
		}

		else if(Input.GetKeyUp(KeyCode.X))
		{
			miniCamera.GetComponent<Camera>().orthographicSize-=20;
		}
	}
}
