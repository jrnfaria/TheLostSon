using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {
	
	public float speed = 15.0F;
	public float jumpSpeed = 8.0F;
	public float gravity = 20.0F;
	public Animator anim;
	
	private CharacterController controller ;
	private Vector3 moveDirection = Vector3.zero;
	
	
	
	void Start () {
		controller = GetComponent<CharacterController> ();
		anim= GetComponent<Animator> ();
		
		
	}
	
	void Update() {

		if (controller.isGrounded) {
			anim.SetInteger("move",0);
			if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) ||Input.GetKey(KeyCode.D)){
				if(Input.GetKey(KeyCode.LeftShift)){
					anim.SetInteger("move",2);//run
					speed = 15.0F;
				}else{
					anim.SetInteger("move",1);//walk
					speed = 5.0F;
				}
			}
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;
			
			if (Input.GetButton ("Jump") && anim.GetInteger("move")==2) {
				anim.SetInteger ("move", 4);//BigJump
			}else if (Input.GetButton ("Jump") && (anim.GetInteger("move")==0 || anim.GetInteger("move")==1)) {
				anim.SetInteger ("move", 3);//jump
			}
		}
		
		moveDirection.y -= gravity * Time.deltaTime;
		
		controller.Move(moveDirection * Time.deltaTime);
		
		transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, Camera.main.transform.localEulerAngles.y, transform.localEulerAngles.z);
	}
	
}

