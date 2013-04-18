using UnityEngine;
using System.Collections;
using System.IO;

public class SaveScores : MonoBehaviour {

	// Use this for initialization
	private string username = "Username";
	// prompt for entering name
	private string title = "Enter Your Name:";
	// an array for temperatly store scores and names
	private string[] scores = new string[20];
	// a constant for initiate the reletive position of labels and buttons
	private int screenPosition = 2 * Screen.width / 5;
	
	private int newscore = 55;
	// lines for print
	private string lines;
	// the start position of a score
	private int pos=1;
	// array counter for 
	private int count = 0;
	// 
	
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
			using (var reader = new StreamReader("Assets/Scores.txt"))
        	{
        	    string line;
           	 	while ((line = reader.ReadLine()) != null&count<20)
            	{
                	scores[count] = line;
					Debug.Log(line);
                	count++;
            	}
        	}
		
			File.WriteAllText("Assets/Scores.txt",System.String.Empty);
			for (int i = 0; i<10; i++)
			{
				if (newscore <  System.Convert.ToInt32(scores[2*i+1]))
					// get the position when the new score is higher than the one stored in the array
					pos = 2*i+1;
			}
			// when it's the first position put it at first position
			if(pos==1)
			{
				scores[pos-1] = username;
				scores[pos]=newscore.ToString();
			}
			// when it's not first position, put it in another situation
			else if(pos>1&&newscore>System.Convert.ToInt32(scores[19]))
			{
				scores[pos]=newscore.ToString();
				scores[pos-1]=username;
			}
			// write the array to the text file
			System.IO.StreamWriter file = new System.IO.StreamWriter("Assets/Scores.txt",true);
			for(int i = 0; i<20;i++)
			{
				lines = scores[i];
				file.WriteLine(lines);
				//Debug.Log(lines);
			}
		
			// close file
			file.Close();
			
			Application.LoadLevel("HighScore");
		
		}
		
	}
}
