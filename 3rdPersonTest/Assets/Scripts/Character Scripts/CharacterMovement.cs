using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {
	
	public float speed = 15.0F;
	public float jumpSpeed = 8.0F;
	public float gravity = 20.0F;
	public Animator anim;

	private float horizontal, vertical;
	
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
			horizontal = Input.GetAxis("Horizontal");
			vertical = Input.GetAxis("Vertical");

			transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, Camera.main.transform.localEulerAngles.y, transform.localEulerAngles.z);
			if(vertical<0){
				transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, Camera.main.transform.localEulerAngles.y+180, transform.localEulerAngles.z);
				//setAngle(Camera.main.transform.localEulerAngles.y+180);
			}
			if(horizontal>0){
				transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, Camera.main.transform.localEulerAngles.y+90, transform.localEulerAngles.z);
				//setAngle(Camera.main.transform.localEulerAngles.y+90);
			}else if(horizontal<0){
				transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, Camera.main.transform.localEulerAngles.y-90, transform.localEulerAngles.z);
				//setAngle(Camera.main.transform.localEulerAngles.y-90);
			}

			moveDirection = new Vector3(horizontal, 0, vertical);
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
	}

	void setAngle(float angle){
		if (angle >= 0 && angle < 90) {
			horizontal=1;
			vertical=1;
		}else if(angle >= 90 && angle < 180){
			horizontal=-1;
			vertical=1;
		}else if(angle >= 180 && angle < 270){
			horizontal=-1;
			vertical=-1;
		}else if(angle >= 270 && angle < 360){
			horizontal=1;
			vertical=-1;
		}
	}
	
}

