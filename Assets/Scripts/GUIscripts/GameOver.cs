using UnityEngine;
using System.Collections;
using System.IO;
public class GameOver : MonoBehaviour {
	
	// lose scene GUI skin
	public GUISkin lose;
	public static string[] scores = new string[20];
	public static int pos;
	private bool HSFlag = true;
	void OnGUI()
	{
		GUI.skin = lose;
		//check that player's score is eligible for a high score
		if(HSFlag)
		checkScore();
		// Label for displaying game over
		GUI.Label(new Rect(Screen.width/2-Screen.width/10,Screen.height/2-Screen.height/10-Screen.height/5,Screen.width/5,Screen.height/5),"Game Over");

		// button for restart
		if(GUI.Button(new Rect(Screen.width/2-Screen.width/10,(Screen.height/2-Screen.height/10+Screen.height/10),Screen.width/5,Screen.height/10),"Restart"))
			Application.LoadLevel("Waves");
		// button for save score
		
		if(GUI.Button(new Rect(Screen.width/2-Screen.width/10,(Screen.height/2-Screen.height/10+Screen.height*3/10),Screen.width/5,Screen.height/10),"Quit"))
			Application.Quit();
	}
	private void checkScore(){
		int newscore = PlayerInfo.score;
		pos = 1;
		int count = 0;
		// read the text file and store the names and scores in an array.
			using (var reader = new StreamReader("Assets/Scores.txt"))
        	{
        	    string line;
           	 	while ((line = reader.ReadLine()) != null && count<20)
            	{
                	scores[count] = line;
                	count++;
            	}
	}
		//newscore = 100;
		//determine if player has made high score ranking
		for (int i = 0; i<10; i++)
			{
				if (newscore <  System.Convert.ToInt32(scores[2*i+1]))
					// get the position when the new score is higher than the one stored in the array
				pos = 2*i+3;
			}
		if(pos<19){//NEW HIGH SCORE!!!
			Application.LoadLevel ("SaveScores");
		}
		HSFlag=false;//no high score set flag so not to continuously call this function
	}
}

			