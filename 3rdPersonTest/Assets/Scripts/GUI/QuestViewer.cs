using UnityEngine;
using System.Collections;

public class QuestViewer : MonoBehaviour {

	private QuestRange questRange;
	private QuestReader questReader;
	private Vector2 scrollPosition = Vector2.zero;
	private static bool showInfoQuestMenu =false;
	private bool questWasAccepted =false;
	private Quest quest;

	//resize
	private float virtualWidth = 1920.0f;
	private float virtualHeight = 1080.0f;
	Matrix4x4 matrix;
	public GUISkin customSkin;

	// Use this for initialization
	void Start () {
		matrix = Matrix4x4.TRS (Vector3.zero, Quaternion.identity,new  Vector3(Screen.width/virtualWidth, Screen.height/virtualHeight, 1.0f));

		questRange = GameObject.FindGameObjectWithTag("Range").GetComponent<QuestRange> ();
		questReader = GameObject.FindGameObjectWithTag("Range").GetComponent<QuestReader> ();
		quest = GameObject.FindGameObjectWithTag("Character").GetComponent<KillQuest>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Q)) {
			showInfoQuestMenu=true;
		}
	}
	
	void OnGUI()
	{
		if (questRange.isDisplayedGUI()) {
			if(questWasAccepted){
				createEndQuestGUI();
			}else{
				createStartQuestGUI();
			}
		}else if (showInfoQuestMenu) {
			createInfoQuestGUI();
		}
	}

	public void initQuest(){
		if (questReader.getQuestType () == "kill") {
			quest = GameObject.FindGameObjectWithTag("Character").GetComponent<KillQuest>();
			quest.startQuest();
		}
	}

	public void createStartQuestGUI(){
		GUI.matrix = matrix;
		GUI.skin = customSkin;

		// Make a background box
		GUI.Box (new Rect (250, 250, 400, 600), "\nQuest "+questReader.getQuestId());
		
		//Quest Description
		string questDescr =questReader.getDescription();
		scrollPosition = GUI.BeginScrollView (new Rect(280, 320, 340, 300), scrollPosition, new Rect(0, 0, 320, 310));
		GUI.TextField (new Rect (0, 0, 320, 310), questDescr,"Label");
		GUI.EndScrollView();
		
		string reward="Reward\n\nMoney:"+questReader.getReward().money+"\nExperience:"+questReader.getReward().exp;
		GUI.TextField (new Rect (280, 650, 340, 100), reward);
		
		//Accept button
		if (GUI.Button (new Rect (280, 770, 160, 40), "Accept")) {
			questRange.setDisplayedGUI(false);
			questWasAccepted=true;
			initQuest();
		}
		
		//Reject button
		if (GUI.Button (new Rect (460, 770, 160, 40), "Reject")) {
			questRange.setDisplayedGUI(false);
		}
	}

	public void createInfoQuestGUI(){
		GUI.matrix = matrix;
		GUI.skin = customSkin;
		// Make a background box
		GUI.Box (new Rect (250, 250, 400, 600), "\nQuest "+questReader.getQuestId());
		
		//Quest Description
		string questDescr =questReader.getDescription();
		scrollPosition = GUI.BeginScrollView (new Rect(280, 320, 340, 300), scrollPosition, new Rect(0, 0, 320, 310));
		GUI.TextField (new Rect (0, 0, 320, 310), questDescr,"Label");
		GUI.EndScrollView();

		if (questReader.getQuestType () == "kill") {
			GUI.TextField (new Rect (280, 600, 220, 25), "Enemies missing : " + ((KillQuest)quest).getKilledNum ()+"/"+((KillQuest)quest).getTotalNum());
		}
		
		string reward="Reward\n\nMoney:"+questReader.getReward().money+"\nExperience:"+questReader.getReward().exp;
		GUI.TextField (new Rect (280, 650, 340, 100), reward);
		
		//Cancel button
		if (GUI.Button (new Rect (460, 770, 160, 40), "Cancel")) {
			showInfoQuestMenu=false;
		}
	}
	
	public void createEndQuestGUI(){
		GUI.matrix = matrix;
		GUI.skin = customSkin;
		// Make a background box
		GUI.Box (new Rect (250, 250, 400, 600), "\nQuest "+questReader.getQuestId());
		
		//Quest Description
		string questDescr =questReader.getDescription();
		scrollPosition = GUI.BeginScrollView (new Rect(280, 320, 340, 300), scrollPosition, new Rect(0, 0, 320, 310));
		GUI.TextField (new Rect (0, 0, 320, 310), questDescr,"Label");
		GUI.EndScrollView();
		
		if (questReader.getQuestType () == "kill") {
			GUI.TextField (new Rect (280, 600, 220, 25), "Enemies missing : " + ((KillQuest)quest).getKilledNum ()+"/"+((KillQuest)quest).getTotalNum());
		}
		
		string reward="Reward\n\nMoney:"+questReader.getReward().money+"\nExperience:"+questReader.getReward().exp;
		GUI.TextField (new Rect (280, 650, 340, 100), reward);
		
		//Accept button
		if (GUI.Button (new Rect (280, 770, 160, 40), "Complete")) {
			if (questReader.getQuestType () == "kill" && ((KillQuest)quest).getKilledNum()==((KillQuest)quest).getTotalNum()) {
				questRange.setDisplayedGUI (false);
				GameObject.FindGameObjectWithTag("Character").GetComponent<CharacterStatus>().addExp(questReader.getReward().exp);
				questReader.read(questReader.nextQuest());
				questWasAccepted=false;
			}
		}

		//Cancel button
		if (GUI.Button (new Rect (460, 770, 160, 40), "Cancel")) {
			questRange.setDisplayedGUI(false);
		}
	}

}
