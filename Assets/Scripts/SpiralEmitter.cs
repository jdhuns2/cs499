//Spiral Emitter.cs
//by Cron Broaddus
//Attached to a game object this emitter fires bullets provided
//by a bullet manager script.
//Can control direction, angle, angle change, fire speed, automate(yes/no)
//and collision layer of bullets

//Requires a Bullet manager in scene attached to an object with tag "ObjectManager"
using UnityEngine;
using System.Collections;

public class SpiralEmitter : MonoBehaviour {

	private BulletManager bm;	//bullet cache
	public Vector3 direction = new Vector3(0,1,0);	//firing direction
	private Vector3 oDirection;	//original set direction of the emitter - used when changing angle over time
	public float angle = 0;	//rotation angle
	public float speed = 1;	//speed of the bullets
	private float timer = 0;// used with delay. keeps track of how much time has passed
	public float delay = 0.2f;//delay between shots
	public float angleInc = 0;//how much to change the firing angle by. Leave 0 if you want straight line of bullets
	public float angleMax = 45;//How far around do you want the angle to change. Resets to 0 when it reaches this.
	
	public string phyLayer = "Player_Layer";//collision layer - see Unity/Physx documentation. Custom layers are used in this project
	public bool timerOn = true;//toggle to fire using timer or use manual firing by calling fire()
	
	public Color bulletColor;//Set in Unity Editor - fires bullets of this color
	//Unity Functions//
	
	// Use this for initialization - called at the start of the scene
	void Start () {
		
		//grab bullet manager from the scene
		GameObject go = (GameObject)GameObject.FindGameObjectWithTag("ObjectManager");
		bm = (BulletManager)go.GetComponent("BulletManager");
		
		//save original direction to reset for angle.
		oDirection = direction;
	}
	
	// Update is called once per frame
	void Update () {
		
		//inc timer according to real time
		timer += Time.deltaTime;
		
		//if delay time has been met and timer toggle is on we fire
		if(timer > delay && timerOn)
		{	
			fire();
			timer = 0;
		}
	}
	
	//My functions//
	
	//Fires a bullet
	void fire()
	{
		//Grab bullet from cache
		GameObject fireMe = bm.giveBullet();
		
		//set bullet position to emitter location
		fireMe.transform.position = this.gameObject.transform.position + direction;// + direction is the offset
		//make bullet visible
		fireMe.renderer.enabled = true;
		//set velocity of the bullet
		fireMe.rigidbody.velocity = direction * speed;
		//activate collisions
		fireMe.rigidbody.detectCollisions = true;
		//set collision layer
		fireMe.layer = LayerMask.NameToLayer(phyLayer);
		
		fireMe.renderer.material.color = bulletColor;
		
		//rotate fire direction according to angle
		Quaternion q = Quaternion.AngleAxis(angle,Vector3.forward);
		//update direction
		direction = q * direction;
		direction.Normalize();
		//inc angle
		angle+= angleInc;
		//reset angle and direction if max is reached
		if(angle >=  angleMax)
		{
			angle = 0;
			direction = oDirection;
		}	
	}
	
	//these functions toggle the timer on and off
	public void TimerOn()
	{
		timerOn = true;	
	}
	
	public void TimerOff()
	{
		timerOn = false;
	}
}
