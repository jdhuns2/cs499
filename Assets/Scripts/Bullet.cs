using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	
	BulletManager parent; //reference to manager
	float timer = 0;
	
	public float lifetime = 1;
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
	
	void OnTriggerEnter(Collider other)	//if we collide we return
	{
		Debug.Log ("collision in bullet object");
		returnToParent ();
	}
	void onCollisionEnter(){
	Debug.Log ("collision");
	
	}
	
	//Custom Functions//
	void setParent(BulletManager p)
	{
		parent = p;
	}
	
	//return to cache
	void returnToParent()	
	{
		timer = 0;
		renderer.enabled = false;
		parent.recieveBullet(this.gameObject);
	}
}
