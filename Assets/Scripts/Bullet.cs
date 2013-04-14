//Bullet.cs
//by Cron Broaddus
//handles the life span of a bullet.
//Life ends if enough time has elapsed or a collision has occured.
//Upon death the bullet returns to the BulletManager location

//Requires a bullet manager in the scene to function correctly
using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	
	BulletManager parent; //reference to manager
	
	//used with lifetime to end life of bullet
	float timer = 0;
	//how many seconds the bullet stays alive
	public float lifetime = 10;
	
	//Unity Functions//
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		//return to cache after set time
		if(renderer.enabled)
		{
			timer += 1 * Time.deltaTime;
			if(timer > lifetime)
				returnToParent();
		}
	}
	
	void OnTriggerEnter(Collider other)	//if we collide we return to parent
	{
		//Debug.Log ("collision in bullet object");
		if(renderer.enabled)
			returnToParent ();
	}
	
	//My Functions//
	
	//Sets parent (bullet manager)
	void setParent(BulletManager p)
	{
		parent = p;
	}
	
	//return to cache
	void returnToParent()	
	{
		//reset all values
		timer = 0;
		//dont draw while inactive
		renderer.enabled = false;
		//return to parent
		parent.recieveBullet(this.gameObject);
		//reset velocity to 0
		rigidbody.velocity = Vector3.zero;
		//change position to the bullet manager location
		gameObject.transform.position = parent.transform.position;
	}
}
