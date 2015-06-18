using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
	public int fullHealth;
	public int health;
	private float healthRatio;
	public Slider healthSlider;
	public Text healthInfo;

	void Start ()
	{
		healthRatio = 1f;
		if (healthSlider != null) {
			healthSlider.maxValue=fullHealth;
			healthSlider.value=health;
			healthInfo.text=fullHealth+"/"+health;
		}
	}

	public float getHealthRatio()
	{
		return healthRatio;
	}

	public void takeDamage(int dmg)
	{
		health -= dmg;

		if (healthSlider != null) {
			healthSlider.value=health;
			healthInfo.text=health+"/"+fullHealth;
		}

		if (health <= 0) {
			if (healthSlider != null) {
				Destroy (healthSlider.gameObject);

			}

			if(GameObject.FindGameObjectWithTag("Character").GetComponent<CharacterStatus>()!=null){
				Debug.Log("Entrei");
			}
			
			Destroy (this.transform.parent.gameObject);
			GameObject.FindGameObjectWithTag("Character").GetComponent<CharacterStatus>().addExp(10);
			KillQuest quest = GameObject.FindGameObjectWithTag("Character").GetComponent<KillQuest>();
			if(quest.getNumber() !=0 && quest.getMonster()==gameObject.name){
				quest.setNumber(quest.getNumber()-1);
			}
		}

		healthRatio = health / (float)fullHealth;
	}
}

