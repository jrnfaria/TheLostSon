using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour
{
	public int fullHealth;
	public int health;
	private float healthRatio;

	void Start ()
	{
		healthRatio = 1f;
	}

	public float getHealthRatio()
	{
		return healthRatio;
	}

	public void takeDamage(int dmg)
	{
		health -= dmg;

		if (health <= 0) {
			Destroy (this.transform.parent.gameObject);
			KillQuest quest = GameObject.FindGameObjectWithTag("Character").GetComponent<KillQuest>();
			if(quest.getNumber() !=0){
				quest.setNumber(quest.getNumber()-1);
			}
		}

		healthRatio = health / (float)fullHealth;
	}
}

