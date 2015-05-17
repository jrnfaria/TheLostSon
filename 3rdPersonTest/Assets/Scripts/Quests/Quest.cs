using UnityEngine;
using System.Collections;

public class Quest : MonoBehaviour {

	QuestReader questReader;
	private string monster;

	// Use this for initialization
	void Start () {
		questReader = gameObject.GetComponent<QuestReader> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void startQuest(){
		monster=questReader.
	}
}
