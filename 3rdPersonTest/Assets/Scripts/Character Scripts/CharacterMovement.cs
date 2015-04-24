using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {

	public float speed;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		float movY= Input.GetAxis("Vertical");
		float movX = Input.GetAxis("Horizontal");

		Vector3 move=new Vector3(-movX ,0, -movY);
		// dont worry about a jump right now.
	
		Vector3 pos = new Vector3 (Camera.main.transform.position.x,0,Camera.main.transform.position.z);

		transform.LookAt(pos);
		transform.Translate(move * speed * Time.deltaTime);
	}

	void OnTriggerEnter(Collider other) {
		if(other.tag=="Enemy1"||other.tag=="Enemy2")
		Destroy(other.gameObject);
	}
}
