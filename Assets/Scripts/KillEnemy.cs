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
	
	//Explosion particle effect is dropped here via Unity
	public GameObject explosion;
	
	
	public GameObject shieldFab;
	public GameObject lifeFab;
	public GameObject rapidFab;
	public GameObject bombFab;
	
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
			//Explode!
			Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
			
			//send message to enemy to stop itween movement
			gameObject.SendMessage("killPath");
			
			//add score to player
			po.AddScore(100);
			
			//Debug.Log ("collision in enemy object");
			
			//enemy is now dead
			isAlive = false;
			
			//turn off emiiter
			se.TimerOff();
			
			
			if(Random.Range(1,10) == 5)
			{
				switch(Random.Range(1,4))
				{
				case 1:
					Instantiate(rapidFab,transform.position, Quaternion.identity);
					break;
				case 2:
					Instantiate(bombFab,transform.position, Quaternion.identity);
					break;
				case 3:
					Instantiate(lifeFab,transform.position, Quaternion.identity);
					break;
				case 4:
					Instantiate(shieldFab,transform.position, Quaternion.identity);
					break;
				default:
					break;
				}
			}
			
		}
	}
	
	//My Functions//
	
	//SetAlive: sets isAlive to true
	public void SetAlive()
	{
		isAlive = true;
	}
}
