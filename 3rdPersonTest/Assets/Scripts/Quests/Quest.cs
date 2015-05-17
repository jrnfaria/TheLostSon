using UnityEngine;
using System.Collections;

public abstract class Quest : MonoBehaviour {

	protected QuestReader questReader;
	protected string monster;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public virtual void startQuest(){
		questReader = gameObject.GetComponent<QuestReader> ();
		monster = questReader.getObjective ().type;
	}
}
