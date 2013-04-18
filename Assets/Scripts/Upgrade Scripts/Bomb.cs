//Bomb.cs
//By Cron Broaddus
//Handles execution of the bomb weapon
//set layer to bomb layer to collide with both enemies and enemy bullets
using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour {
	
	float timer = 0;
	float life = 1;
	public float scale = 1;
	
	public bool blowUp = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if(blowUp)
		{
			timer += 1 * Time.deltaTime;
		
			transform.localScale += new Vector3( scale, scale, scale) * Time.deltaTime;
		
			if(timer >= life)
				Destroy(gameObject);
	
		}
		//rotate object
		gameObject.transform.Rotate(Vector3.up, 5.0f);
	}
	
	void OnTriggerEnter()
	{
		blowUp = true;
	}
}
