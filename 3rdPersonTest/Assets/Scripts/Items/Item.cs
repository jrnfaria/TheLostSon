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

}
