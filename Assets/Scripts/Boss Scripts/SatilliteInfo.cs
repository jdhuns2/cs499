//SatilliteInfo.cs
//by Cron Broaddus
//handles the live of the boss satillies.
//Handles damage on collision and death
using UnityEngine;
using System.Collections;

public class SatilliteInfo : MonoBehaviour {
	
	//number of hits it can take
	public int health = 50;
	
	public bool vulnerable = true;
	
	public GameObject shield1, shield2;
	//Unity functions//
	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
		if(shield1 == null && shield2 == null)
			vulnerable = false;
		
	}
	
	//collision handler
	void OnTriggerEnter(Collider c){
		//decrement health
		if(vulnerable)
			health --;
		
		//kill check
		if(health <= 0)
			KillSelf();
	}
	
	//My Functions//
	
	//Destroys attached gameObject. 
	void KillSelf()
	{
		Destroy (gameObject);
	}
}
