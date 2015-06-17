using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {

	public List<Item> inventory= new List<Item>();
	public List<Item> slotItems= new List<Item>();
	public List<Item> fastItems= new List<Item>();
	public int slotsX,slotsY;
	public bool show=false;
	private string currentToolTip;

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

		fastItems.Add (new Item());
		fastItems.Add (new Item());

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
	}

	void OnGUI()
	{
		int i = 0;
		Event e = Event.current;
		GUI.matrix = matrix;

		GUI.Box (new Rect(1700,980,70,70),"");
		GUI.Box (new Rect(1780,980,70,70),"");

		if (show) {

			GUI.Box (new Rect(650,250,500,500),"inventory");
			for (int x=0;x<slotsX;x++)
			{
				for (int y=0;y<slotsY;y++)
				{
					Rect slotRect = new Rect(700 + x * 80,300+y*80,70,70);
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
					i++;
				}
			}
		}
	}




}
