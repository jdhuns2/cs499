//PlayerInfo.cs
//Talks to gui
//Houses player lives/score/upgrades

//TODO script

using UnityEngine;
using System.Collections;

public class PlayerInfo : MonoBehaviour {

	public GUIText GUIscore;
	public GUIText GUIlives;
	public GUIText GUIbombs;
	
	public int score = 0;
	
	public GameObject upgrade1, upgrade2;
	
	public int lives = 2;
	
	public int bombs = 0;
	
	
	// Use this for initialization
	void Start () {
		GUIscore.text = score.ToString();
		GUIlives.text = "Lives: " + lives.ToString();
		GUIbombs.text = "Bombs: " + bombs.ToString();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	
	//My Functions//
	
	//AddsUpgrade to the player
	public void AddUpdrage(GameObject newUp)
	{
		//Probs need to set location too;
		newUp.transform.parent = gameObject.transform;
		
		if(upgrade1 == null)
		{
			upgrade1 = newUp;
		}
		else if(upgrade2 == null)
		{	
			upgrade2 = newUp;
		}
		else
		{	
			Destroy(upgrade1);	
			upgrade1 = upgrade2;
			Destroy(upgrade2);
			upgrade2 = newUp;
		}	
	}
	
	public void AddScore(int aScore)
	{
		score+= aScore;
		GUIscore.text = score.ToString();
	}
	
	//Need to add and sub lives etc.
}
