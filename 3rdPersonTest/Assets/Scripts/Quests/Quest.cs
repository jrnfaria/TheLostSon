﻿using UnityEngine;
using System.Collections;

public class Quest : MonoBehaviour {

	protected QuestReader questReader;
	protected string monster;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public string getMonster(){
		return monster;
	}

	public virtual void startQuest(){}
}
