using UnityEngine;
using System.Collections;

public class StatusMenu : MonoBehaviour {
	
	//resize
	private float virtualWidth = 1920.0f;
	private float virtualHeight = 1080.0f;
	Matrix4x4 matrix;
	public GUISkin customSkin;
	public bool show=false;

	private CharacterStatus cs;
	
	// Use this for initialization
	void Start () {
		matrix = Matrix4x4.TRS (Vector3.zero, Quaternion.identity,new  Vector3(Screen.width/virtualWidth, Screen.height/virtualHeight, 1.0f));
		cs = GameObject.FindGameObjectWithTag("Character").GetComponent<CharacterStatus>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown (KeyCode.C)){
			show=!show;
		}
	}
	
	void OnGUI(){
		if(show){
			GUI.matrix = matrix;
			GUI.skin = customSkin;
			
			GUI.Box (new Rect (760, 340, 400, 400), "\nStatus");

			string hp = "HP "+cs.getHealth() + "/" + cs.getMaxHealth() + "     HP regen " + cs.getHealthRegen();
			GUI.Label (new Rect (780, 440, 380, 400), hp);

			string stamina = "Stamina "+cs.getStamina() + "/" + cs.getMaxStamina() + "   Statmina regen " + cs.getStaminaRegen();
			GUI.Label (new Rect (780, 470, 380, 400), stamina);

			string lvl = "Level "+cs.getLevel();
			GUI.Label (new Rect (780, 500, 380, 400), lvl);

			string exp = "Experience "+cs.getExp() + "/" + cs.getMaxExp();
			GUI.Label (new Rect (780, 530, 380, 400), exp);
			
			string atk1 = "Attack 1 (Left button) - "+cs.attackDamage + " damage";
			GUI.Label (new Rect (780, 560, 380, 400), atk1);
			
			string atk2 = "Attack 2 (Right button) - "+cs.specialAttackDamage + " damage";
			GUI.Label (new Rect (780, 590, 380, 400), atk2);
			
			string atk3 = "Attack 3 (Mid button) - "+cs.specialAttack2Damage + " damage";
			GUI.Label (new Rect (780, 620, 380, 400), atk3);
			
			if (GUI.Button (new Rect (980, 680, 160, 40), "Cancel")) {
				show=false;
			}
		}
	}
}
