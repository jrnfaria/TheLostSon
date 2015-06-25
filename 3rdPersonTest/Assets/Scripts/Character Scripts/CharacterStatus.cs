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

	public Text lvlText;
	private int lvl;

	private int money;
	private bool dodging;

	
	public Slider healthSlider;
	public Slider staminaSlider;
	public Slider expSlider;

	//public Text lvlText;
	public Text HPTextInfo;
	public Text SPTextInfo;
	//public Text moneyText;
	private int canAttack=0;
	public int attackDamage = 5;
	public int specialAttackDamage = 20;
	public int specialAttack2Damage = 50;

	
	
	
	// Use this for initialization
	void Start () {
		health = 100;
		fullHealth = 100;
		dodging = false;

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

		lvlText.text=lvl.ToString();

	
//		lvlText.text = "Lvl:" + lvl;

		HPTextInfo.text = health + "/" + fullHealth;
		SPTextInfo.text = stamina + "/" + maxStamina;

		//moneyText.text = "Money:" + money;
		InvokeRepeating ("regenStamina", 2f, 2f);
		InvokeRepeating ("regenHealth", 2f, 2f);
	}

	public void setDodging()
	{
		dodging = !dodging;
	}

	void regenStamina()
	{
		stamina += (int)(maxStamina * 0.01);
		if (stamina >= maxStamina) {
			stamina=maxStamina;
		}
		staminaSlider.value = stamina;
		SPTextInfo.text = stamina + "/" + maxStamina;
	}

	public bool enoughStamina(int value)
	{
		return stamina >= value;
	}

	void regenHealth()
	{
		health += (int)(fullHealth * 0.01);
		if (health >= fullHealth) {
			health=fullHealth;
		}
		healthSlider.value = health;
		HPTextInfo.text = health + "/" + fullHealth;
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
		if (!dodging) {
			health -= dmg;
			healthSlider.value = health;
			HPTextInfo.text = health + "/" + fullHealth;

			if (health <= 0)
				Application.LoadLevel (1);
		}
	}
	
	public void spendStamina(int sta)
	{
		if (stamina - sta >= 0) {
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
		if (health + he <= fullHealth) {
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
			lvlText.text=lvl.ToString();
			fullHealth=fullHealth+50;
			maxStamina=maxStamina+50;
			health=fullHealth;
			stamina=maxStamina;

			healthSlider.maxValue=fullHealth;
			healthSlider.value=fullHealth;

			staminaSlider.maxValue=maxStamina;
			staminaSlider.value=maxStamina;

			HPTextInfo.text = health + "/" + fullHealth;
			SPTextInfo.text = stamina + "/" + maxStamina;


		}
		expSlider.value = exp;
	}
	
	void OnTriggerStay(Collider other) {
		if (other.tag == "Enemy") {
			if (canAttack!=0) {
				other.GetComponent<EnemyHealth> ().takeDamage (canAttack);
				canAttack=0;
			}
		}
	}

	public void CanAttack(){
		canAttack = attackDamage;
	}
	
	public void CanAttack1(){
		canAttack = specialAttackDamage;
	}
	
	public void CanAttack2(){
		canAttack = specialAttack2Damage;
	}

	public int getHealth(){
		return health;
	}
	
	public int getMaxHealth(){
		return fullHealth;
	}
	
	public float getHealthRegen(){
		return fullHealth*0.01f;
	}
	
	public int getStamina(){
		return stamina;
	}
	
	public int getMaxStamina(){
		return maxStamina;
	}
	
	public float getStaminaRegen(){
		return fullHealth*0.01f;
	}
	
	public int getExp(){
		return exp;
	}
	
	public int getMaxExp(){
		return maxExp;
	}

	public int getLevel(){
		return lvl;
	}
}
