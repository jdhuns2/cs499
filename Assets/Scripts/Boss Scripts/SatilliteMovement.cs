//satilliteMovement.cs
//Cron Broaddus
//Controls the movement of boss's satillite ships
//Note that it moves in the xy plane
using UnityEngine;
using System.Collections;

public class SatilliteMovement : MonoBehaviour {
	
	//timer is used to change direction
	float timer = 0;
	
	//How long it takes to complete path
	public float delay = 5;
	//Movement speed
	public float speed = 5.0f;
	
	//Direction of the ship
	Vector3 direction = new Vector3(0,1,0);
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		//inc timer every second
		timer+= 1*Time.deltaTime;
		
		//Change direction after delay time has passed
		if(timer > delay)
		{
			direction.y *= -1;
			timer = 0;
		}
		//update the position of the object. Increase speed value to increase movement speed.
		gameObject.transform.position += (direction * speed) * Time.deltaTime;
	}
}
