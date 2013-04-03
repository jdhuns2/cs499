using UnityEngine;
using System.Collections;

public class KillEnemy : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	 //enemy collision handler
void OnTriggerEnter(Collider c){
		gameObject.SendMessage("killPath");
			
		Debug.Log ("collision in enemy object");
		//Debug.Log (c.gameObject.name);
	//update player's score
	//tell enemy to stop shooting
		//Debug.Log ("We've been hit!!!");
	}
}
