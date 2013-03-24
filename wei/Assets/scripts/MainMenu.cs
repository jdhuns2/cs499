using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	// Use this for initialization
	private string instructionText = " Instructions:\n Press Left and Right ACrrows to Move.\n Press";
	private int buttonWidth = 200;
	private int buttonHeight = 50;
	
	// Update is called once per frame
	void OnGUI () {
		GUI.Label(new Rect(10, 10, 250, 200), instructionText);
		if(GUI.Button(new Rect(Screen.width/2 - buttonWidth/2, 
							Screen.height/2- buttonHeight/2, buttonWidth, buttonHeight),"Start Game"))
		{
			Debug.Log("HHHHHHH");
			Application.LoadLevel(1);
		}
	}
}
