using UnityEngine;
using System.Collections;
using System.IO;


public class HighScore : MonoBehaviour {
	// array of a string to store names and scores from a text file.
    private string[] scores = new string[20];
	// the array counter
    private int count = 0;
	// the rank of scores
    private string rank;
	// the names of player stored in the file
    private string names;
	// the score in the file stored in the text file
	private string score;
    // GUI skin for highscore scene
	public GUISkin HighScoreSkin;
	// position to the label left
	private float labelLeft = Screen.width/2-125;
	
	
	// button width
	private float buttonWith = Screen.width/5;
	// button height
	private float buttonHeight = Screen.height/20;
    void OnGUI()
    {
       
		GUI.skin = HighScoreSkin;
		// label of high score display
		GUI.Label(new Rect(labelLeft, -50,250,200),  "Top 10 High Scores");
        // read the text file and store the names and scores into an array
		using (var reader = new StreamReader("Assets/Scores.txt"))
        {
            string line;
            while ((line = reader.ReadLine()) != null&count<20)
            {
                scores[count] = line;
				//print(count);
                count++;
				//print(count);
            }
        }
        for (int i = 0; i < 10; i++)
        {
            rank = (i+1).ToString() ;
			names = scores[2*i];
			score = scores[2*i + 1];
            
			//GUI.Label(new Rect(screenPosition - 25, 25, 250, 200+10*i), " ");
			// label for displaying the ranks
            GUI.Label(new Rect(labelLeft, 0+10*i, 50, 200+20*i), rank);
			// label for displaying player names
			GUI.Label(new Rect(labelLeft-20, 0+10*i, 250, 200+20*i), names);
			// label for displaying scores
			GUI.Label(new Rect(labelLeft+80, 0+10*i, 250, 200+20*i), score);
			
        }
		// create the button for back to main screen
		if(GUI.Button(new Rect(Screen.width/2-buttonWith/2, Screen.height-50, buttonWith, buttonHeight),"Back"))
			Application.LoadLevel("MainMenu");
       
    }




	
}
