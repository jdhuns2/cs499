using UnityEngine;
using System.Collections;

public class SpiralEmitter : MonoBehaviour {

	private BulletManager bm;	//bullet cache
	public Vector3 direction = new Vector3(0,1,0);	//firing direction
	public float angle = 0;	//rotation angle
	public float speed = 1;	//speed of the bullets
	private float timer = 0;
	public float delay = 0.2f;
	public float angleInc = 5;
	public float angleMax = 45;
	
	public bool timerOn = true;
	// Use this for initialization
	void Start () {
		GameObject go = (GameObject)GameObject.FindGameObjectWithTag("ObjectManager");
		bm = (BulletManager)go.GetComponent("BulletManager");
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if(timer > delay && timerOn)
		{	
			fire();
			timer = 0;
		}
	}
	
	void fire()
	{
		//Fire a bullet
		GameObject fireMe = bm.giveBullet();
		fireMe.transform.position = this.gameObject.transform.position;
		fireMe.renderer.enabled = true;
		fireMe.rigidbody.velocity = direction * speed;
		
		//rotate fire direction
		Quaternion q = Quaternion.AngleAxis(angle,Vector3.forward);
		direction = q * direction;
		direction.Normalize();
		angle+= angleInc;
		if(angle >=  angleMax)
			angle = 0;
	}
}
