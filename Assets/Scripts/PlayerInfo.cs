//PlayerInfo.cs
//Talks to gui object in scene
//Houses player lives/score/upgrades
using UnityEngine;
using System.Collections;

public class PlayerInfo : MonoBehaviour {
	
	//GUItext objects to be change - these are refrenced using Unity editor
	public GUIText GUIscore;
	public GUIText GUIlives;
	public GUIText GUIbombs;
	
	//Player score
	public int score = 0;
	
	//Ref to upgrades
	public GameObject upgrade1, upgrade2;
	
	//player lives
	public int lives = 2;
	
	//number of available bombs
	public int bombs = 0;
	
	
	// Use this for initialization
	void Start () {
		//Init gui texts
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
		
		//adds upgrade - if slots are full drops upgrade 1
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
	
	//AddScore: increments score - called by KillEnemy script
	public void AddScore(int aScore)
	{
		score+= aScore;
		GUIscore.text = score.ToString();
	}
	
	//Need to add and sub lives etc.
}
