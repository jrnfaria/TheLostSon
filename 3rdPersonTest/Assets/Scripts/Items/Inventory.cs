﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {

	public List<Item> inventory= new List<Item>();
	public List<Item> slotItems= new List<Item>();
	public int slotsX,slotsY;
	public bool show=false;
	private string currentToolTip;
	public GUISkin customSkin;

	//draging item
	private bool dragging = false;
	private Item curItem=null;
	private int prevIndex;

	//resize
	private float virtualWidth = 1920.0f;
	private float virtualHeight = 1080.0f;
	Matrix4x4 matrix;
	

	// Use this for initialization
	void Start () {

		slotItems.Add (new Item());
		slotItems.Add (new Item());



		matrix = Matrix4x4.TRS (Vector3.zero, Quaternion.identity,new  Vector3(Screen.width/virtualWidth, Screen.height/virtualHeight, 1.0f));
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
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			slotItems[slotItems.Count-2].effect();
			if(slotItems[slotItems.Count-2].type==Item.itemType.Potion)
			{
				slotItems[slotItems.Count-2].itemAmount-=1;
				if(slotItems[slotItems.Count-2].itemAmount<=0)
					slotItems[slotItems.Count-2]=new Item();
			}
		}
		if (Input.GetKeyDown (KeyCode.Alpha2)) {
			slotItems[slotItems.Count-1].effect();
			if(slotItems[slotItems.Count-1].type==Item.itemType.Potion)
			{
				slotItems[slotItems.Count-1].itemAmount-=1;
				if(slotItems[slotItems.Count-1].itemAmount<=0)
					slotItems[slotItems.Count-1]=new Item();
			}
		}
	}

	void shortcutOptions(Rect slotRect,int i,Event e)
	{
		if(slotItems[i].itemAmount>0)
		{
			Color c = GUI.backgroundColor;
			GUI.backgroundColor = Color.clear;
			GUI.Label(new Rect(slotRect.x,slotRect.y,20,20),slotItems[i].itemAmount.ToString());
			GUI.backgroundColor=c;
		}

		GUI.Box (slotRect,slotItems[i].image);
		
		if(slotRect.Contains(e.mousePosition)&&!dragging && slotItems[i].itemName !=null && slotItems[i].itemName!="")
		{
			currentToolTip = slotItems[i].itemName+"\n"+slotItems[i].itemDescription;
			
			if(e.type == EventType.MouseDrag && curItem==null)
			{
				dragging=true;
				prevIndex = i;
				curItem = slotItems[i];
				slotItems[i]=new Item();
			}
			
			//use item
			else if(e.type==EventType.mouseUp)
			{
				bool worked=slotItems[i].effect();
				if(slotItems[i].type==Item.itemType.Potion&&worked)
				{
					slotItems[i].itemAmount-=1;
					if(slotItems[i].itemAmount<=0)
						slotItems[i]=new Item();
				}
				
			}
		}
		else
		{
			currentToolTip = "";
		}
		
		
		if(dragging)
		{
			GUI.DrawTexture(new Rect(e.mousePosition.x,e.mousePosition.y,70,70),curItem.image);
			
			if(e.type == EventType.MouseUp)
			{
				
				if(slotRect.Contains (e.mousePosition))
				{
					if(slotItems[i].itemName != null && slotItems[i].itemName != "")
					{
						slotItems[prevIndex]=slotItems[i];
					}
					
					slotItems[i]=curItem;
					curItem=null;
					dragging=false;
				}
				
				
			}
		}
		//shows item description
		if(currentToolTip!=null&&currentToolTip!="")
		{
			GUI.Box(new Rect(e.mousePosition.x,e.mousePosition.y,100,100),currentToolTip);
		}
	}

	void OnGUI()
	{
		GUI.skin = customSkin;
		int i = 0;

		Event e = Event.current;
		GUI.matrix = matrix;

	
		Rect slotRect = new Rect(885,980,70,70);
		GUI.Box (slotRect,"");
		shortcutOptions (slotRect,slotItems.Count-2,e);


		slotRect=new Rect(965,980,70,70);
		GUI.Box (slotRect,"");
		shortcutOptions (slotRect,slotItems.Count-1,e);




		if (show) {

			GUI.Box (new Rect(710,250,500,500),"inventory");

			for (int x=0;x<slotsX;x++)
			{
				for (int y=0;y<slotsY;y++)
				{
					slotRect = new Rect(760 + x * 80,300+y*80,70,70);

					GUI.Box (slotRect,slotItems[i].image);

					if(slotItems[i].itemAmount>0)
					{
					Color c = GUI.backgroundColor;
					GUI.backgroundColor = Color.clear;
					GUI.Label(new Rect(760 + x * 80,300+y*80,20,20),slotItems[i].itemAmount.ToString());
					GUI.backgroundColor=c;
					}

					if(slotRect.Contains(e.mousePosition)&&!dragging && slotItems[i].itemName !=null && slotItems[i].itemName!="")
					{
						currentToolTip = slotItems[i].itemName+"\n"+slotItems[i].itemDescription;

						if(e.type == EventType.MouseDrag && curItem==null)
						{
							dragging=true;
							prevIndex = i;
							curItem = slotItems[i];
							slotItems[i]=new Item();
						}

						//use item
						else if(e.type==EventType.mouseUp)
						{
							slotItems[i].effect();
							if(slotItems[i].type==Item.itemType.Potion)
							{
								slotItems[i].itemAmount-=1;
								if(slotItems[i].itemAmount<=0)
									slotItems[i]=new Item();
							}

						}
					}
					else
					{
						currentToolTip = "";
					}

					//shows item description
					if(currentToolTip!=null&&currentToolTip!="")
					{
						GUI.Box(new Rect(e.mousePosition.x,e.mousePosition.y,100,100),currentToolTip);
					}
				

					if(dragging)
					{
						GUI.DrawTexture(new Rect(e.mousePosition.x,e.mousePosition.y,70,70),curItem.image);
					
						if(e.type == EventType.MouseUp)
						{

							if(slotRect.Contains (e.mousePosition))
							{
								if(slotItems[i].itemName != null && slotItems[i].itemName != "")
								{
									slotItems[prevIndex]=slotItems[i];
								}

								slotItems[i]=curItem;
								curItem=null;
								dragging=false;
							}


						}
					}
				
					i++;
				}
			}
		}
	}

	public void dropSystem()
	{
		if (Random.Range (0, 1) == 0) {
			int index = Random.Range (0, inventory.Count);
			while (inventory[index].type!=Item.itemType.Potion) {
				index = Random.Range (0, inventory.Count);
			}

			for (int i=0; i<slotItems.Count; i++) {

				if (slotItems [i].itemName == inventory [index].itemName) {
					slotItems [i].itemAmount++;
				}
			}
		}


	}


}
