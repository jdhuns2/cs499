using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	// game title
    private string title = "AWESOME SPACE SHOOTER!";
	// button width
	private float buttonWidth = Screen.width/5;
	// button height
	private float buttonHeight = Screen.height/10;
	// position of the button -- to the left of the screen
	private float width = Screen.width/2 - Screen.width/10;
	// position of the button -- to the top of the screen
	private float height = Screen.height/3 - Screen.height/20;
 	//GUI skin instatiation
    public GUISkin menuSkin;

	// Update is called once per frame
	void OnGUI () {
		// set the gui skin as menuSkin
        GUI.skin = menuSkin;
		// Label for displaying the main title
		GUI.Label(new Rect(Screen.width/2-130, 30, 260, 200), title);
       
    	// button for starting the game 
		if(GUI.Button(new Rect(width, height, buttonWidth, buttonHeight),"Start Game"))
			Application.LoadLevel("Waves");
		// button for high score screen
		else if(GUI.Button(new Rect(width, height+buttonHeight, buttonWidth, buttonHeight),"High Score"))
			Application.LoadLevel("HighScore");
		// button for options
		else if(GUI.Button(new Rect(width, height+2*buttonHeight, buttonWidth, buttonHeight),"Options"))
			Application.LoadLevel("Options");
		// button for exiting
		else if(GUI.Button(new Rect(width, height+3*buttonHeight, buttonWidth, buttonHeight),"Exit"))
				Application.Quit();
		
	}
}

