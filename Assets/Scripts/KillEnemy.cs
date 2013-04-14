//KillEnemy.cs
//By Cron Broaddus
//Handles killing the enemy - dies when collision occurs
//Requires a valid Player object with "Player" as the tag.
//Requires a SpiralEmitter to be attached to it's gameObject
using UnityEngine;
using System.Collections;

public class KillEnemy : MonoBehaviour {
	
	//Toggle for is the enemy alive (active)
	bool isAlive = true;
	//ref to player info script to update score
	PlayerInfo po;
	//ref to enemies emitter - turns it off when enemy dies
	SpiralEmitter se;
	
	//Unit Functions//
	
	// Use this for initialization
	void Start () {
		
		//Grab references to needed scripts
		GameObject go = GameObject.FindGameObjectWithTag("Player");
		po = (PlayerInfo)go.GetComponent("PlayerInfo");
		
		se = (SpiralEmitter)gameObject.GetComponent("SpiralEmitter");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	 //collision handler
	void OnTriggerEnter(Collider c){
		
		//if object is alive it can die
		if(isAlive)
		{
			//send message to enemy to stop itween movement
			gameObject.SendMessage("killPath");
			
			//add score to player
			po.AddScore(100);
			
			//Debug.Log ("collision in enemy object");
			
			//enemy is now dead
			isAlive = false;
			
			//turn off emiiter
			se.TimerOff();
		}
	}
	
	//My Functions//
	
	//SetAlive: sets isAlive to true
	public void SetAlive()
	{
		isAlive = true;
	}
}
