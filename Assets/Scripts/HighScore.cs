using UnityEngine;
using System.Collections;
using System.IO;


public class HighScore : MonoBehaviour {
    private string[] scores = new string[20];
    private int count = 0;
    private string newstring;
    
    private int screenPosition = 2 * Screen.width / 5;
	public GUISkin HighScoreSkin;
    void OnGUI()
    {
       /* foreach (string line in File.ReadAllLines("Scores.txt"))
        {
            scores[count+1] = line;
            count++;
        }
        */
		GUI.skin = HighScoreSkin;
		GUI.Label(new Rect(screenPosition, 10,250,200),  "Top 10 High Scores");
       
		using (var reader = new StreamReader("Scores.txt"))
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
            newstring = (i+1).ToString() +"\t\t"+ scores[2*i] + "\t\t"+ scores[2*i + 1];
            
			//GUI.Label(new Rect(screenPosition - 25, 25, 250, 200+10*i), " ");
            GUI.Label(new Rect(screenPosition - 25, 50+10*i, 250, 200+20*i), newstring);
			
        }
       
    }




	
}
