using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	// Use this for initialization
	private string instructionText = "Press Left and Right Arrows to Move.";
    private string title = "AWESOME SPACE SHOOTER!";
	private int buttonWidth = Screen.width / 5;
	//private int buttonHeight = 50;
    private int selectionGridInt = 0;
	//private int selectionGridInt_1 = 1;
    private string[] selectionString = {"Start Game", "High Scores", "Options", "Exit"};
    private int screenPosition = 2 * Screen.width / 5;
    private int screenHeight = Screen.height / 2;
    public GUISkin menuSkin;

	// Update is called once per frame
	void OnGUI () {
        GUI.skin = menuSkin;
		GUI.Label(new Rect(screenPosition - 25, 10, 250, 200), title);
        GUI.Label(new Rect(screenPosition - 35, 50, 250, 200), instructionText);
		/*if(GUI.Button(new Rect(Screen.width/2 - buttonWidth/2, 
							Screen.height/2- buttonHeight/2, buttonWidth, buttonHeight),"Start Game"))
		{
			Debug.Log("HHHHHHH");
			Application.LoadLevel(1);
		}*/
        selectionGridInt = GUI.SelectionGrid(new Rect (screenPosition, screenHeight, buttonWidth, 100), selectionGridInt, selectionString,1);
        selectionGridInt = GUI.SelectionGrid(new Rect (screenPosition, screenHeight, buttonWidth, 100), 1, selectionString,1);
		
		
		if (GUI.changed)
        {
            if (selectionGridInt == 0)
            {
                Debug.Log("HHHHHHH");
                Application.LoadLevel(1);
            }
			else if (selectionGridInt == 1)
			{
				Application.LoadLevel(4);	
			}
         } 
	}
}
