//PlayerInfo.cs
//Talks to gui
//Houses player lives/score/upgrades

//TODO script

using UnityEngine;
using System.Collections;

public class PlayerInfo : MonoBehaviour {
	
	public int score = 0;
	
	public GameObject upgrade1, upgrade2;
	
	public int lives = 2;
	
	
	
	// Use this for initialization
	void Start () {
	
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
}
