using UnityEngine;
using System.Collections;

[System.Serializable]
public class Item{

	public enum itemType
	{
		Potion,
		QuestItem,
		Clothes,
		Mount,
		Partner
	}
	public string itemName;
	public Texture image;
	public string itemDescription;
	public int itemID;
	public int itemAmount;
	public itemType type;

	public int hpRegen;
	public int staminaRegen;

	public GameObject dragon;
	private bool invoked=false;

	public bool effect()
	{
		if (hpRegen != 0 || staminaRegen != 0) {
			CharacterStatus hero = GameObject.FindGameObjectWithTag ("Character").GetComponent<CharacterStatus> ();

			hero.regenHealth (hpRegen);
			hero.regenStamina (staminaRegen);

		} else if (dragon!=null) {
			if(invoked)
			{
				GameObject.Destroy(GameObject.FindGameObjectWithTag("Dragon"));
				invoked=false;
			}
			else
			{
				GameObject hero = GameObject.FindGameObjectWithTag ("Character");
				GameObject Dragon=GameObject.Instantiate(dragon as GameObject);
				Dragon.transform.parent=hero.transform;
				Dragon.transform.localPosition=new Vector3(1.5f,2f,0);
				invoked=true;
			}
		}
		return true;
	}
}
