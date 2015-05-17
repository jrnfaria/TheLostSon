using UnityEngine;
using System.Collections;

public class QuestViewer : MonoBehaviour {

	private QuestRange questRange;
	private QuestReader questReader;
	private Vector2 scrollPosition = Vector2.zero;

	// Use this for initialization
	void Start () {
		questRange = gameObject.GetComponent<QuestRange> ();
		questReader = gameObject.GetComponent<QuestReader> ();
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	void OnGUI()
	{
		if (questRange.isDisplayedGUI()) {
			// Make a background box
			GUI.Box (ResizeGUI (new Rect (50, 50, 200, 400)), "\nQuest "+questReader.getQuestId());

			//Quest Description
			string questDescr =questReader.getDescription();
			int size = (int)((questDescr.Length*200/566)+0.5);
			if(size<200){
				size=200;
			}
			scrollPosition = GUI.BeginScrollView (ResizeGUI (new Rect(65, 100, 170, 200)), scrollPosition, ResizeGUI (new Rect(0, 0, 160, size)));
			GUI.TextField (ResizeGUI (new Rect (0, 0, 160, size)), questDescr,"Label");
			GUI.EndScrollView();

			string reward="Reward\n\nMoney:"+questReader.getReward().money+"\nExperience:"+questReader.getReward().exp;
			GUI.TextField (ResizeGUI (new Rect (65, 315, 170, 80)), reward);
			
			//Accept button
			if (GUI.Button (ResizeGUI (new Rect (65, 410, 80, 20)), "Accept")) {
				Debug.Log ("Accept");
				questRange.setDisplayedGUI(false);
			}
			
			//Reject button
			if (GUI.Button (ResizeGUI (new Rect (155, 410, 80, 20)), "Reject")) {
				Debug.Log ("Reject");
				questRange.setDisplayedGUI(false);
			}
		}
	}
	
	Rect ResizeGUI(Rect _rect)
	{
		float FilScreenWidth = _rect.width / 800;
		float rectWidth = FilScreenWidth * Screen.width;
		float FilScreenHeight = _rect.height / 600;
		float rectHeight = FilScreenHeight * Screen.height;
		float rectX = (_rect.x / 800) * Screen.width;
		float rectY = (_rect.y / 600) * Screen.height;
		
		return new Rect(rectX,rectY,rectWidth,rectHeight);
	}

	public void initQuest(){
		
	}
}
