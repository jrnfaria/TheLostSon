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

	}
}
