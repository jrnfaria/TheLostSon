using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;

public class QuestReader : MonoBehaviour {
	
	private XmlReader xml;
	
	//QuestData
	private int questId;
	private List<startcondition> startconditions = new List<startcondition>();
	private string description;
	private string questType;
	private objective obj;
	private reward rew;

	public int quest=1;

	// Use this for initialization
	void Start () {
	}

	void Awake(){
		
		read (quest);

	}

	public void read(int quest){
		xml = this.GetComponent<XmlReader> ();
		
		try {
			xml.read ("Quest " + quest);
		} catch (FileNotFoundException) {
		}
		
		//get QuestId
		questId = xml.container.id;
		//Debug.Log ("questId = " + questId);
		
		//get Start Conditions
		for (int i=0; i< xml.container.startconditions.Count; i++) {
			startconditions.Add (xml.container.startconditions [i]);
			//Debug.Log ("startconditions[" + i + "] = " + startconditions [i].type + "/" + startconditions [i].questId);
		}
		
		//get description
		description = xml.container.description;
		//Debug.Log ("description = "+description);
		
		//get quest type
		questType = xml.container.type;
		//Debug.Log ("questType = "+questType);
		
		//get objectives
		obj = xml.container.obj;
		//Debug.Log ("Objective type = "+obj.type+"/"+obj.quantity);
		
		//get money
		rew = xml.container.rew;
		//Debug.Log ("money = "+rew.money +"/exp = "+rew.exp);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public int getQuestId(){
		return questId;
	}

	public List<startcondition> getStartConditions(){
		return startconditions;
	}

	public string getDescription(){
		return description.Replace("\\n","\n");
	}

	public string getQuestType(){
		return questType;
	}

	public objective getObjective(){
		return obj;
	}

	public reward getReward(){
		return rew;
	}

	public int nextQuest(){
		quest++;
		return quest;
	}
}
