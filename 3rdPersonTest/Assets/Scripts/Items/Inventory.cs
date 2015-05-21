using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {

	public List<Item> inventory= new List<Item>();
	public List<Item> slotItems= new List<Item>();
	public int slotsX,slotsY;
	public bool show=false;
	private string currentToolTip;

	//draging item
	private bool dragging = false;
	private Item curItem=null;
	private int prevIndex;

	// Use this for initialization
	void Start () {
		for (int i=0; i<(slotsX * slotsY); i++) {
			//inventory.Add (new Item());
			slotItems.Add (new Item());
		}

		for (int i=0; i < inventory.Count; i++) {
			if(inventory[i].itemAmount >=1)
			{
				for(int j=0;j<slotItems.Count;j++)
				{
					if(slotItems[j].itemName==null|| slotItems[j].itemName=="")
					{
						slotItems[j] = inventory[i];
						break;
					}
				}
			}
		}

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.I)) {
			show=!show;
		}
	}

	void OnGUI()
	{
		int i = 0;
		Event e = Event.current;

		if (show) {
			for (int x=0;x<slotsX;x++)
			{
				for (int y=0;y<slotsY;y++)
				{
					Rect slotRect = new Rect(65 + x * 60,30+y*60,50,50);
					GUI.Box (slotRect,slotItems[i].itemName);
				
					if(slotRect.Contains(e.mousePosition))
					{
						currentToolTip = slotItems[i].itemDescription;

						if(e.type == EventType.MouseDrag && slotItems[i].itemName !=null && slotItems[i].itemName!="")
						{
							dragging=true;
							prevIndex = i;
							curItem = slotItems[i];
							slotItems[i]=new Item();
						}
					}

					if(dragging)
					{
						GUI.Label (new Rect(e.mousePosition.x,e.mousePosition.y,100,100),curItem.itemName);
					
						if(e.type == EventType.MouseUp)
						{
							if(slotRect.Contains (e.mousePosition))
							{
								if(slotItems[i].itemName != null && slotItems[i].itemName != "")
								{

								}
								slotItems[i]=curItem;
								dragging=false;
							}
						}
					}
					//shows item description
					if(currentToolTip!=null&&currentToolTip!="")
					{
						GUI.Box(new Rect(e.mousePosition.x,e.mousePosition.y,100,100),currentToolTip);
					}
					i++;
				}
			}
		}
	}
}
