using UnityEngine;
using System.Collections;

public class QuestViewer : MonoBehaviour {

	private QuestRange questRange;
	private QuestReader questReader;
	private Vector2 scrollPosition = Vector2.zero;
	private bool showInfoQuestMenu =false;
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

		questRange = gameObject.GetComponent<QuestRange> ();
		questReader = gameObject.GetComponent<QuestReader> ();
		quest = GameObject.FindGameObjectWithTag("Character").GetComponent<KillQuest>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.R)) {
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
	
	/*Rect ResizeGUI(Rect _rect)
	{
		float FilScreenWidth = _rect.width / 800;
		float rectWidth = FilScreenWidth * Screen.width;
		float FilScreenHeight = _rect.height / 600;
		float rectHeight = FilScreenHeight * Screen.height;
		float rectX = (_rect.x / 800) * Screen.width;
		float rectY = (_rect.y / 600) * Screen.height;
		
		return new Rect(rectX,rectY,rectWidth,rectHeight);
	}*/

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
		GUI.Box (new Rect (50, 50, 200, 400), "\nQuest "+questReader.getQuestId());
		
		//Quest Description
		string questDescr =questReader.getDescription();
		int size = (int)((questDescr.Length*200/566)+0.5);
		if(size<200){
			size=200;
		}
		scrollPosition = GUI.BeginScrollView (new Rect(65, 100, 170, 200), scrollPosition, new Rect(0, 0, 160, size));
		GUI.TextField (new Rect (0, 0, 160, size), questDescr,"Label");
		GUI.EndScrollView();

		if (questReader.getQuestType () == "kill") {
			GUI.TextField (new Rect (65, 285, 170, 25), "Enemies missing : " + ((KillQuest)quest).getKilledNum ()+"/"+((KillQuest)quest).getTotalNum());
		}

		string reward="Reward\n\nMoney:"+questReader.getReward().money+"\nExperience:"+questReader.getReward().exp;
		GUI.TextField (new Rect (65, 315, 170, 80), reward);
		
		//Cancel button
		if (GUI.Button (new Rect (155, 410, 80, 20), "Cancel")) {
			showInfoQuestMenu=false;
		}
	}
	
	public void createEndQuestGUI(){
		GUI.matrix = matrix;
		GUI.skin = customSkin;
		// Make a background box
		GUI.Box (new Rect (50, 50, 200, 400), "\nQuest "+questReader.getQuestId());
		
		//Quest Description
		string questDescr =questReader.getDescription();
		int size = (int)((questDescr.Length*200/566)+0.5);
		if(size<200){
			size=200;
		}
		scrollPosition = GUI.BeginScrollView (new Rect(65, 100, 170, 200), scrollPosition, new Rect(0, 0, 160, size));
		GUI.TextField (new Rect (0, 0, 160, size), questDescr,"Label");
		GUI.EndScrollView();
		
		if (questReader.getQuestType () == "kill") {
			GUI.TextField (new Rect (65, 285, 170, 25), "Enemies missing : " + ((KillQuest)quest).getKilledNum ()+"/"+((KillQuest)quest).getTotalNum());
		}
		
		string reward="Reward\n\nMoney:"+questReader.getReward().money+"\nExperience:"+questReader.getReward().exp;
		GUI.TextField (new Rect (65, 315, 170, 80), reward);
		
		//Accept button
		if (GUI.Button (new Rect (65, 410, 80, 20), "Complete")) {
			questRange.setDisplayedGUI (false);
			GameObject.FindGameObjectWithTag("Character").GetComponent<CharacterStatus>().addExp(questReader.getReward().exp);
		}
	}

}
