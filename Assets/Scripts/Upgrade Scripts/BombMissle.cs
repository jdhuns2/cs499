using UnityEngine;
using System.Collections;

public class BombMissle : MonoBehaviour {
	
	public GameObject explosion;
	
	float timer = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		timer += 1 *Time.deltaTime;
		if(timer > 5)
			Destroy(gameObject);
		
		if(Input.GetButton("Fire3"))
		{
			Explode();
		}
	}
	
	void OnTriggerEnter(Collider c)
	{
		Explode ();
	}
	
	void Explode()
	{
		Instantiate(explosion, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
}
