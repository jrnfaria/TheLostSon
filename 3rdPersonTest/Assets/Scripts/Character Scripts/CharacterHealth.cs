using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CharacterHealth : MonoBehaviour {

	private int health;
	private int fullHealth;

	private int stamina;

	public Slider healthSlider;
	public Slider staminaSlider;



	// Use this for initialization
	void Start () {
		health = 100;
		fullHealth = 100;

		stamina=100;


		healthSlider.maxValue = fullHealth;
		healthSlider.value = health;

		staminaSlider.maxValue = stamina;
		staminaSlider.value = stamina;
	}
	
	// Update is called once per frame
	void Update () {



		if (Input.GetKeyUp (KeyCode.C)) {
			takeDamage(10);
			spendStamina(10);
		}
	}

	public void takeDamage(int dmg)
	{
		health -= dmg;
		healthSlider.value = health;

	}

	public void spendStamina(int sta)
	{
		stamina -= sta;
		staminaSlider.value = stamina;
		
	}

	void OnTriggerEnter(Collider other) {
		//Debug.Log (other.tag);
		if (other.tag == "Enemy") {
			other.GetComponent<EnemyHealth>().takeDamage(10);
		}
	}
}
