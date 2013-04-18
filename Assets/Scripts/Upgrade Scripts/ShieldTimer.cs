using UnityEngine;
using System.Collections;

public class ShieldTimer : MonoBehaviour {
	
	//timer to count how long object has been alive
	float timer;
	//how long to stay alive
	public float life; 
	//angle for rotation
	float angle = 5.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		//inc timer and angle per second
		timer+= 1* Time.deltaTime;
		//angle += 1*Time.deltaTime;
		
		//rotate object
		gameObject.transform.Rotate(Vector3.up, angle);
		
		//if time is up destroy object
		if(timer >= life)
			Destroy(gameObject);
	}
}
