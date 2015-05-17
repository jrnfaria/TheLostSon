﻿using UnityEngine;
using System.Collections;

public class KillQuest : Quest {

	private int number;

	// Use this for initialization
	void Start () {
		questReader = GameObject.FindGameObjectWithTag("Range").GetComponent<QuestReader> ();
		monster = "";
		number = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override void startQuest(){
		questReader = GameObject.FindGameObjectWithTag("Range").GetComponent<QuestReader> ();
		monster = questReader.getObjective ().type;
		number = questReader.getObjective ().quantity;
	}

	public int getNumber(){
		return number;
	}

	public void setNumber(int number){
		this.number = number;
	}

	public int getKilledNum(){
		return questReader.getObjective ().quantity-number;
	}

	public int getTotalNum(){
		return questReader.getObjective ().quantity;
	}
}
