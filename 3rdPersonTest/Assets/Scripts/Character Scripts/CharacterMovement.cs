using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {

	public float speed = 15.0F;
	public float jumpSpeed = 8.0F;
	public float gravity = 20.0F;

	private CharacterController controller ;
	private Vector3 moveDirection = Vector3.zero;

	
	void Start () {
		controller = GetComponent<CharacterController> ();
	}

	void Update() {

		if (controller.isGrounded) {

			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;
			if (Input.GetButton("Jump"))
				moveDirection.y = jumpSpeed;
			
		}
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);

		Vector3 CameraDir = new Vector3 (Camera.main.transform.position.x,0,Camera.main.transform.position.z);
		transform.LookAt(transform.position + CameraDir);
	}

	void OnTriggerEnter(Collider other) {
		if(other.tag=="Enemy1"||other.tag=="Enemy2")
		Destroy(other.transform.parent.gameObject);
	}
}

