using UnityEngine;
using System.Collections;

public class QuestViewer : MonoBehaviour {

	private QuestStart questStart;
	private Vector2 scrollPosition = Vector2.zero;

	// Use this for initialization
	void Start () {
		questStart = GameObject.FindGameObjectWithTag ("Range").GetComponent<QuestStart> ();
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	void OnGUI()
	{
		if (questStart.isDisplayedGUI()) {
			// Make a background box
			GUI.Box (ResizeGUI (new Rect (50, 50, 200, 400)), "\nQuest + id");

			//Quest Description
			string questDescr ="Ola Joao ndsf hsdhkfdks hf hkdshfhysdfgusdbbfhbshdh khfsdb hfds bkjfjsd sd - fdahsfjkdah f gfhgdfj hfg dgfghd gf gf dhf g dg jfghdghf hgd fhdakhfhd gfhdggfdgfh ghdh g hdgfgkdgkafhds fhd ggf dggdhfd f dhhf gf gdgfhhdgkfsgdf gdh gfhdgjfdg fdghdf gfd gd sgf hsdgfg jdfsj fhd id sihgjfshgsifdhgiofhih ih ifd hf nvfhn   vhhv hnvhfnhnvhhhhhhhhhh fhb vsbhfkvhsfnvnisfuoaahhs bhbf hfh hfb vfb bfhsklsbk fghfdh dghhgfkn gdf bhkgf g hdghfd ksgkf hkgfsbgh fhslfh kghfd gkdfh gdfh gfbd dskj hfdsf dihfaishd  hf hsdhf  hdsf ihd ds f ds  fh sdh fkhdfksdkf dhs f dsh hfhsdhkf dh hf hhksd hf ksfhsdhk g djshf kdsf sdhfh ihsdhfu hidsohiuf hihsduh fihsdhuf huidhsihf uisdiu hfuudsh ihfihsdu fihdus fih hsd hfdshifhihsdh fisud f hsd ufhiodidsui ou dsf fjksbdjf dskj fkj sdfh dlk fhdasjfh ldasfh lskhadf h sdlafh sdaksfhlasdhf afl dfd------.";
			int size = (int)((questDescr.Length*200/566)+0.5);
			if(size<200){
				size=200;
			}
			scrollPosition = GUI.BeginScrollView (ResizeGUI (new Rect(65, 100, 170, 200)), scrollPosition, ResizeGUI (new Rect(0, 0, 160, size)));
			GUI.TextField (ResizeGUI (new Rect (0, 0, 160, size)), questDescr,"Label");
			GUI.EndScrollView();

			string reward="Reward\nMoney:1000\nExperience:233";
			GUI.TextField (ResizeGUI (new Rect (65, 315, 170, 80)), reward);
			
			//Accept button
			if (GUI.Button (ResizeGUI (new Rect (65, 410, 80, 20)), "Accept")) {
				Debug.Log ("Accept");
				questStart.setDisplayedGUI(false);
			}
			
			//Reject button
			if (GUI.Button (ResizeGUI (new Rect (155, 410, 80, 20)), "Reject")) {
				Debug.Log ("Reject");
				questStart.setDisplayedGUI(false);
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
}
