using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {
	
	// lose scene GUI skin
	public GUISkin lose;
		
	void OnGUI()
	{
		GUI.skin = lose;
		// Label for displaying game over
		GUI.Label(new Rect(Screen.width/2-Screen.width/10,Screen.height/2-Screen.height/10-Screen.height/5,Screen.width/5,Screen.height/5),"Game Over");
		// button for restart
		if(GUI.Button(new Rect(Screen.width/2-Screen.width/10,(Screen.height/2-Screen.height/10+Screen.height/10),Screen.width/5,Screen.height/10),"Restart"))
			Application.LoadLevel("Waves");
		// button for save score
		if(GUI.Button(new Rect(Screen.width/2-Screen.width/10,(Screen.height/2-Screen.height/10+Screen.height*2/10),Screen.width/5,Screen.height/10),"Save Score"))
			Application.LoadLevel("SaveScores");
		// button for quit
		if(GUI.Button(new Rect(Screen.width/2-Screen.width/10,(Screen.height/2-Screen.height/10+Screen.height*3/10),Screen.width/5,Screen.height/10),"Quit"))
			Application.Quit();
	}
}
