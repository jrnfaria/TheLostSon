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

	private Transform cameraTransform;
	private float h;
	private float v;
	private Vector3 lastDirection;
	public float turnSmoothing = 3.0f;
	private bool isMoving;

	void Start () {
		controller = GetComponent<CharacterController> ();
		anim= GetComponent<Animator> ();
		cameraTransform = Camera.main.transform;
	}
	
	void Update() {
		h = Input.GetAxis ("Horizontal");
		v = Input.GetAxis("Vertical");
		Rotating(h, v);

		if (controller.isGrounded) {
			isMoving=false;
			anim.SetInteger("move",0);
			moveDirection = new Vector3(0,0,0);
			if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) ||Input.GetKey(KeyCode.D)){
				idleAttack ();
				isMoving=true;
				moveDirection = Vector3.forward * Time.deltaTime;
				if(Input.GetKey(KeyCode.LeftShift)){
					anim.SetInteger("move",2);//run
					speed = 480.0f;
				}else{
					anim.SetInteger("move",1);//walk
					speed = 140.0f;
				}
			}else if(Input.GetKey(KeyCode.E)){
				idleAttack ();
				canIdleAttack=true;
				anim.SetInteger("move",8);//dodgeRight
			}
			//transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, Camera.main.transform.localEulerAngles.y, transform.localEulerAngles.z);
			/*if(Input.GetKey(KeyCode.D)){
				transform.Rotate(Vector3.up, Mathf.Clamp(180f * Time.deltaTime, 0f, 360f));
			}
			if(Input.GetKey(KeyCode.A)){
				transform.Rotate(Vector3.up, -Mathf.Clamp(180f * Time.deltaTime, 0f, 360f));
			}*/

			//moveDirection = new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"));
			moveDirection = transform.TransformDirection(moveDirection);

			if (Input.GetButton ("Jump") && anim.GetInteger("move")==2) {
				idleAttack ();
				anim.SetInteger ("move", 4);//BigJump
			}else if (Input.GetButton ("Jump") && (anim.GetInteger("move")==0 || anim.GetInteger("move")==1)) {
				idleAttack ();
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

	Vector3 Rotating(float horizontal, float vertical)
	{
		Vector3 forward = cameraTransform.TransformDirection(Vector3.forward);
		forward.y = 0.0f;
		forward = forward.normalized;
		
		Vector3 right = new Vector3(forward.z, 0, -forward.x);
		
		Vector3 targetDirection;
		
		targetDirection = forward * vertical + right * horizontal;
		
		if(isMoving && targetDirection != Vector3.zero)
		{
			Quaternion targetRotation = Quaternion.LookRotation (targetDirection, Vector3.up);
			
			
			Quaternion newRotation = Quaternion.Slerp(GetComponent<Rigidbody>().rotation, targetRotation, turnSmoothing * Time.deltaTime);
			GetComponent<Rigidbody>().MoveRotation (newRotation);
			lastDirection = targetDirection;
		}
		//idle - fly or grounded
		if(!(Mathf.Abs(h) > 0.9 || Mathf.Abs(v) > 0.9))
		{
			Repositioning();
		}
		
		return targetDirection;
	}	
	
	private void Repositioning()
	{
		Vector3 repositioning = lastDirection;
		if(repositioning != Vector3.zero)
		{
			repositioning.y = 0;
			Quaternion targetRotation = Quaternion.LookRotation (repositioning, Vector3.up);
			Quaternion newRotation = Quaternion.Slerp(GetComponent<Rigidbody>().rotation, targetRotation, turnSmoothing * Time.deltaTime);
			GetComponent<Rigidbody>().MoveRotation (newRotation);
		}
	}
	
}

