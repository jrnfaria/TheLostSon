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

	private int money;

	private CharacterMovement cm;

	
	public Slider healthSlider;
	public Slider staminaSlider;
	public Slider expSlider;

	//public Text lvlText;
	public Text HPTextInfo;
	public Text SPTextInfo;
	//public Text moneyText;

	
	
	
	// Use this for initialization
	void Start () {
		health = 100;
		fullHealth = 100;

		money = 0;
		stamina=100;
		lvl = 1;
		exp = 0;
		maxExp = 100;
		maxStamina = 100;

		//ui configuration
		//sliders
		healthSlider.maxValue = fullHealth;
		healthSlider.value = health;

		expSlider.maxValue = 100;
		expSlider.value = exp;
		
		staminaSlider.maxValue = stamina;
		staminaSlider.value = stamina;

	
//		lvlText.text = "Lvl:" + lvl;

		HPTextInfo.text = health + "/" + fullHealth;
		SPTextInfo.text = stamina + "/" + maxStamina;

		//moneyText.text = "Money:" + money;
		cm = GetComponent<CharacterMovement> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		
		
		
		if (Input.GetKeyUp (KeyCode.C)) {
			takeDamage(10);
			spendStamina(10);
			addExp(10);
			addMoney(100);
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

	public void regenStamina(int st)
	{
		stamina =stamina + st;
		if (stamina + st >= maxStamina)
			stamina = maxStamina;
		else
			stamina += st;

		staminaSlider.value = stamina;
		SPTextInfo.text = stamina + "/" + maxStamina;
	}

	public void regenHealth(int he)
	{
		if (health + he > fullHealth) {
			health = health + he;
		} else
			health = fullHealth;

		healthSlider.value = health;
		HPTextInfo.text = health + "/" + fullHealth;
	}

	public void addMoney(int mn)
	{
		money += mn;
		//moneyText.text = "Money:" + money;
	}

	public void addExp(int xp){
		exp += xp;
		while(exp >= maxExp){
			lvl++;
			//lvlText.text = "Lvl:" + lvl;
			exp = 0;
			maxExp=(int)(maxExp*lvl);
			expSlider.maxValue=maxExp;
		}
		expSlider.value = exp;
	}
	
	void OnTriggerStay(Collider other) {
		
		//Debug.Log (other.tag);
		if (other.tag == "Enemy") {
			Debug.Log (cm.getMove());
			if(cm.getMove()==5){//attack
				other.GetComponent<EnemyHealth>().takeDamage(10);
			}else if(cm.getMove()==6){//special attack
				other.GetComponent<EnemyHealth>().takeDamage(50);
			}else if(cm.getMove()==7){//special attack
				other.GetComponent<EnemyHealth>().takeDamage(70);
			}
		}
	}
}
