using UnityEngine;
using System.Collections;

[System.Serializable]
public class Game { 
	
	public static Game current;
	public CharacterStatus tyson;
	
	public Game () {
		tyson = new CharacterStatus();
	}
}