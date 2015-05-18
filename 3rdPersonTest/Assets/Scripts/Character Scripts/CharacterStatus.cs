using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CharacterStatus : MonoBehaviour {
	
	private int health;
	private int fullHealth;
	
	private int stamina;
	private int maxStamina;

	private int exp;
	private int maxExp;

	private int lvl;
	
	public Slider healthSlider;
	public Slider staminaSlider;
	public Slider expSlider;

	public Text expTextInfo;
	public Text lvlText;
	public Text HPTextInfo;
	public Text SPTextInfo;

	
	
	
	// Use this for initialization
	void Start () {
		health = 100;
		fullHealth = 100;
		
		stamina=100;
		lvl = 1;
		exp = 0;
		maxExp = 100;
		maxStamina = 100;

		//ui configuration
		//sliders
		healthSlider.maxValue = fullHealth;
		healthSlider.value = health;
		
		staminaSlider.maxValue = stamina;
		staminaSlider.value = stamina;

		expSlider.maxValue = 100;
		expSlider.value = exp;

		//text
		expTextInfo.text = "0/"+maxExp;
		lvlText.text = "Lvl:" + lvl;

		HPTextInfo.text = health + "/" + fullHealth;
		SPTextInfo.text = stamina + "/" + maxStamina;
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
		HPTextInfo.text = health + "/" + fullHealth;
	}
	
	public void spendStamina(int sta)
	{
		if (stamina - sta > 0) {
			stamina -= sta;
			staminaSlider.value = stamina;
			SPTextInfo.text = stamina + "/" + maxStamina;
		} else {
			stamina=0;
		}
	}

	public void addExp(int xp){
		exp += xp;
		while(exp >= maxExp){
			lvl++;
			lvlText.text = "Lvl:" + lvl;
			exp -= 100;
			maxExp=maxExp*lvl;
			expSlider.maxValue=maxExp;
		}
		expTextInfo.text = exp+"/"+maxExp;
		expSlider.value = exp;
	}
	
	void OnTriggerEnter(Collider other) {
		//Debug.Log (other.tag);
		if (other.tag == "Enemy") {
			other.GetComponent<EnemyHealth>().takeDamage(10);
		}
	}
}
