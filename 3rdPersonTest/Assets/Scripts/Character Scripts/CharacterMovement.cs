using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {

	public float speed = 15.0F;
	public float jumpSpeed = 8.0F;
	public float gravity = 20.0F;

	private CharacterController controller ;
	private Vector3 moveDirection = Vector3.zero;
	private Animator anim;


	
	void Start () {
		controller = GetComponent<CharacterController> ();
		anim= GetComponent<Animator> ();


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

		/*if (moveDirection != Vector3.zero)
			anim.SetBool ("walking", true);
		else
			anim.SetBool ("walking", false);*/

		controller.Move(moveDirection * Time.deltaTime);

		//Vector3 CameraDir = new Vector3 (Camera.main.transform.position.x,0,Camera.main.transform.position.z);
		//transform.LookAt(transform.position + CameraDir);
		transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, Camera.main.transform.localEulerAngles.y, transform.localEulerAngles.z); 
	}
	
}

