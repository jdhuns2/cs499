using UnityEngine;
using System.Collections;

public class BulletManager : MonoBehaviour {
	
	public int cacheAmount = 10;	//initial amount of bullets
	ArrayList cache;	//Houses the bullets
	public GameObject bulletFab;	//the bullet
	
	//Unity Functions/// 
	
	// Use this for initialization
	void Start () {
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
				GameObject nb = (GameObject)Instantiate(bulletFab);
				nb.renderer.enabled = false;	//don't want to see them before firing
				nb.SendMessage("setParent", this);	//let them know who's boss
				nb.rigidbody.detectCollisions = false;
				cache.Add(nb);
			}
	}
	
	public GameObject giveBullet()	//returns a bullet from the cache;
	{
		GameObject r;
		if(cache.Count != 0)	//if cache is not empty
		{
			r = (GameObject)cache[0];
			cache.Remove(r);
			//cacheAmount --;
			cacheAmount = cache.Count;
		}
		else{					//if cache is empty create a new bullet
			r = (GameObject)Instantiate(bulletFab);
			r.renderer.enabled = false;
			r.SendMessage("setParent", this);	//let them know who's boss
			r.rigidbody.detectCollisions = false;
		}
		return r;
	}
	
	public void recieveBullet(GameObject bullet)	//get bullet back
	{
		cache.Add(bullet);	
		//cacheAmount++;
		cacheAmount = cache.Count;
	}
}
