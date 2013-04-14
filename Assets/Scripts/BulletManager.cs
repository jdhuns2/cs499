//BulletManager.cs
//By Cron Broaddus
//Creates a cache of bullets on start. Can give away bullets to emitters.
//

using UnityEngine;
using System.Collections;

public class BulletManager : MonoBehaviour {
	
	public int cacheAmount = 10;	//initial amount of bullets
	ArrayList cache;	//Houses the bullets
	public GameObject bulletFab;	//the bullet - this is set in Unity
	
	//Unity Functions/// 
	
	// Use this for initialization
	void Start () {
		//create cache on start
		initializeCache();	
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	
	//Custom Functions//
	
	void initializeCache()	//initialize and populate array list
	{
		cache = new ArrayList();
		if(bulletFab != null)
			for(int i = 0; i < cacheAmount; i++)
			{
				GameObject nb = (GameObject)Instantiate(bulletFab);//create a new bullet
				nb.renderer.enabled = false;	//don't want to see them before firing
				nb.SendMessage("setParent", this);	//let them know who's boss
				nb.rigidbody.detectCollisions = false;	//do not need collisions while bullet is in cache
				cache.Add(nb);//add new bullet to cache
			}
	}
	
	public GameObject giveBullet()	//returns a bullet from the cache;
	{
		GameObject r;
		if(cache.Count != 0)	//if cache is not empty give already created bullet
		{
			r = (GameObject)cache[0];
			cache.Remove(r);
			cacheAmount = cache.Count;	//this was used for debugging. Cahce amount can be seen in Unity editor
		}
		else{					//if cache is empty create a new bullet
			r = (GameObject)Instantiate(bulletFab);
			r.renderer.enabled = false;
			r.SendMessage("setParent", this);	//let them know who's boss
			r.rigidbody.detectCollisions = false;
			Debug.Log("Bullet Made " + cache.Count.ToString());//debug line - outputs to debug prompt 
		}
		return r;//return bullet
	}
	
	public void recieveBullet(GameObject bullet)	//get bullet back
	{
		cache.Add(bullet);	
		cacheAmount = cache.Count; //line used for debug purposes
	}
}
