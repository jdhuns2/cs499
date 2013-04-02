using UnityEngine;
using System.Collections;

public class Win : MonoBehaviour {

	// Use this for initialization
	private int buttonWidth = 200;
	private int buttonHeight = 50;
	
	void OnGUI () {
		//GUI.Label(new Rect(10, 10, 250, 200), instructionText);
		if(GUI.Button(new Rect(Screen.width/2 - buttonWidth/2, 
							Screen.height/2- buttonHeight/2, buttonWidth, buttonHeight),"You Win!\nPress to play again"))
		{
			//Debug.Log("HHHHHHH");
			Player.Score = 0;
			Player.Lives = 3;
			Player.Missed = 0;
			Application.LoadLevel(1);
		}
	}
	
	}

