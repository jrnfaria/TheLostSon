using UnityEngine;
using System.Collections;
using System.Threading;

public class CharacterMovement : MonoBehaviour {
	
	public float speed = 0;
	public float gravity = 20.0F;
	public Animator anim;

	private float horizontal, vertical;
	private bool canIdleAttack=false;
	
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
				idleAttack ();
				if(Input.GetKey(KeyCode.LeftShift)){
					anim.SetInteger("move",2);//run
					speed = 15.0f;
				}else{
					anim.SetInteger("move",1);//walk
					speed = 5.0f;
				}
			}else if(Input.GetKey(KeyCode.Q)){
				idleAttack ();
				canIdleAttack=true;
				anim.SetInteger("move",9);//dodgeLeft
			}else if(Input.GetKey(KeyCode.E)){
				idleAttack ();
				canIdleAttack=true;
				anim.SetInteger("move",8);//dodgeRight
			}
			transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, Camera.main.transform.localEulerAngles.y, transform.localEulerAngles.z);
			/*if(Input.GetKey(KeyCode.D)){
				transform.Rotate(Vector3.up, Mathf.Clamp(180f * Time.deltaTime, 0f, 360f));
			}
			if(Input.GetKey(KeyCode.A)){
				transform.Rotate(Vector3.up, -Mathf.Clamp(180f * Time.deltaTime, 0f, 360f));
			}*/

			moveDirection = new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"));
			moveDirection = transform.TransformDirection(moveDirection);

			if (Input.GetButton ("Jump") && anim.GetInteger("move")==2) {
				anim.SetInteger ("move", 4);//BigJump
			}else if (Input.GetButton ("Jump") && (anim.GetInteger("move")==0 || anim.GetInteger("move")==1)) {
				anim.SetInteger ("move", 3);//jump
			}
			attack ();
			moveDirection *= speed;
		}
		moveDirection.y -= gravity * Time.deltaTime;
		
		controller.Move(moveDirection * Time.deltaTime);

	}

	void attack(){
		if (Input.GetMouseButtonDown(0)) {//left click
			idleAttack();
			canIdleAttack=true;
			anim.SetInteger ("move", 5);//normal attack
		}else if (Input.GetMouseButtonDown(1)) {//right click
			idleAttack();
			anim.SetInteger ("move", 6);//Special attack 1
			canIdleAttack=true;
		}else if (Input.GetMouseButtonDown(2)) {//mid click
			idleAttack();
			anim.SetInteger ("move", 7);//Special attack 2
			canIdleAttack=true;
		}
		if(canIdleAttack && anim.GetInteger("move")!=5 && anim.GetInteger("move")!=6 && anim.GetInteger("move")!=7 && anim.GetInteger("move")!=8 && anim.GetInteger("move")!=9){
			anim.SetInteger ("move", 10);//idleAttack
			Invoke ("idleAttack", 5.0f);
		}
	}

	void idleAttack(){
		CancelInvoke("idleAttack");
		canIdleAttack=false;
		anim.SetInteger ("move", 0);//idle
	}

	public int getMove(){
		return anim.GetInteger ("move");
	}
	
}

