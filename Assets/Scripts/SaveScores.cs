using UnityEngine;
using System.Collections;
using System.IO;

public class SaveScores : MonoBehaviour {

	// Use this for initialization
	private string username = "Username";
	private string title = "Enter Your Name:";
	private string[] scores = new string[20];
	private int screenPosition = 2 * Screen.width / 5;
	private int newscore = 25000;
	private int count = 0;
	private int pos;
	void OnGUI()
	{
		GUI.Label(new Rect(screenPosition - 25, 10, 250, 200), title);
		username = GUI.TextField(new Rect(screenPosition - 25, 50, 200, 25),username,10);
		if (GUI.Button(new Rect(screenPosition - 25, 100, 50, 20),"OK"))
			username = GUI.TextField(new Rect(screenPosition - 25, 50, 200, 25),username,10);
		GUI.Button(new Rect(screenPosition + 50, 100, 50, 20),"Cancel");
		
		GUI.Label(new Rect(screenPosition, 10,250,200),  "Top 10 High Scores");
        
		using (var reader = new StreamReader("Scores.txt"))
        {
            string line;
            while ((line = reader.ReadLine()) != null&count<20)
            {
                scores[count] = line;
                count++;
            }
        }
        
		for (int i = 0; i<10; i++)
		{
			if (newscore >  System.Convert.ToInt32(scores[2*i+1]))
				pos = 2*i+1;
			break;
		}
		
	for (int i = 10 - 1; 2*i+1 > pos; i--)
	{
		scores[2*i+2] = scores[2*i+1];
	}
		string tempstring = username.ToString();
		scores[pos] = tempstring;
		scores[pos-1] = username;
		Debug.Log(username);
		
		
	}
}
