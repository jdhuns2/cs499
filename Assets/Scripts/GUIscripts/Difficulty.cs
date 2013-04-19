using UnityEngine;
using System.Collections;

public class Difficulty : MonoBehaviour {
	//set the prompt difficulty
    private string title = "Select Difficulty";
	
    private int screenPosition = 2 * Screen.width / 5;
	private WaveCreator WC;
	
	// difficulty level
 	public static int difficulty;
	
	// instantiate a GUI skin
    public GUISkin menuSkin;
	// the button width
	private float buttonWidth = Screen.width/5;
	// button height
	private float buttonHeight = Screen.height/10;
	
	// button position width
	private float width = Screen.width/2 - Screen.width/10;
	// button position height
	private float height = Screen.height/3 - Screen.height/20;
 	void Start(){
		//GameObject go = (GameObject)GameObject.FindGameObjectWithTag("WaveGen");
		//WC = (WaveCreator)go.GetComponent ("WaveCreator");	
	}
	// Update is called once per frame
	void OnGUI () {
        GUI.skin = menuSkin;
		// title lable
		GUI.Label(new Rect(Screen.width/2-75, 30, 150, 200), title);
       
    		// button to select easy level
		     if(GUI.Button(new Rect(width, height, buttonWidth, buttonHeight),"Easy"))
			{
		      difficulty = 0;
			  //WC.setDifficulty ();
			  Application.LoadLevel("Waves");
			}
		// button to select normal level
		else if(GUI.Button(new Rect(width, height+buttonHeight, buttonWidth, buttonHeight),"Normal"))
		{
			difficulty = 2;
			//WC.setDifficulty ();
			Application.LoadLevel("Waves");
		}
		
		// button to select hard level
		else if(GUI.Button(new Rect(width, height+2*buttonHeight, buttonWidth, buttonHeight),"Hard"))
		{
			difficulty = 5;
			//WC.setDifficulty ();
			Application.LoadLevel("Waves");
		}
		// button to back to main menu
		else if(GUI.Button(new Rect(width, height+3*buttonHeight, buttonWidth, buttonHeight),"Back"))
				Application.LoadLevel("MainMenu");
	}
}

