using UnityEngine;
using System.Collections;
using System.IO;

public class SaveScores : MonoBehaviour {

	// Use this for initialization
	private string username = "Username";
	// prompt for entering name
	private string title = "Enter Your Name:";
	// a constant for initiate the reletive position of labels and buttons
	private int screenPosition = 2 * Screen.width / 5;
	
	private int newscore;
	private string lines;
	
	void Start()
	{
		newscore = PlayerInfo.score;
	}
	void OnGUI()
	{
		// label for displaying the title
		GUI.Label(new Rect(screenPosition+25, 10,250,200),  title);
		// the textfield for getting the user input
		username = GUI.TextField(new Rect(screenPosition - 25, 50, 200, 25),username,10);
		// back button for going back to main screen
	    if (GUI.Button(new Rect(screenPosition + 50, 100, 60, 20),"Back"))
		{
			Application.LoadLevel(1);	
		}
		// save button to save the name of player
		else if (GUI.Button(new Rect(screenPosition - 25, 100, 60, 20),"Save"))
		{
			username = GUI.TextField(new Rect(screenPosition - 25, 50, 200, 25),username,10);
			
        	// read the text file and store the names and scores in an array.
			
			saveScore ();
		
	}
}
	public void saveScore(){
		//int newscore = PlayerInfo.score;
		//High scores file is re-written everytime a new high score is achieved
			File.WriteAllText("Assets/Scores.txt",System.String.Empty);
			// write the array to the text file
			System.IO.StreamWriter file = new System.IO.StreamWriter("Assets/Scores.txt",true);
			for(int i = 0; i<18;i++)
			{
				if(GameOver.pos==i+1){//new position found write new data 
					lines = username;
					file.WriteLine (lines);
					lines = PlayerInfo.score.ToString ();
					file.WriteLine (lines);
					}
				lines = GameOver.scores[i];
				file.WriteLine(lines);
				//Debug.Log(lines);
			}
		
			// close file
			file.Close();
			
			Application.LoadLevel("HighScore");
		
		}
		
		
	}
