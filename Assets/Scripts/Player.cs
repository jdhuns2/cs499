//Player.cs
//by Cron Broaddus and James Hunsucker
//controls the player based on the inpupt manager provided by Unity.
//Resolves collisions and updates hud
using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	//how fast the player moves
    public float PlayerSpeed;
	//refrence to game camera for player placement
    public Camera cam;
	
    private float maxY, minY;//determine play area independent of camera position
	
	//timer used to compare delay for firing bullets
	private float timer = 0;
	public float fireDelay = 0.2f;
	
	//ref to playerinfo object
	PlayerInfo pi;
	
	private bool vulnerable = true;

	float respwanTimer = 0.0f;
	float invTime = 2.0f;
	
	float flashTimer = 0;
	float flashTime = 0.2f;
	
	public GameObject daBomb;
	GameObject db;
	//ref to particle system for explosion - connected through unity
	public GameObject explosion;
	
    void Start()
    {
        Vector3 pos;
        pos = cam.camera.ViewportToWorldPoint(new Vector3(0.05f,0.5f,cam.camera.farClipPlane-.75f));
        //set start position
		transform.position = pos;
        PlayerSpeed = 7.0f;
		//set max and minimum y for player wrap
        pos = cam.camera.ViewportToWorldPoint(new Vector3(1,1,cam.camera.farClipPlane));
        maxY = pos.y;
        pos = cam.camera.ViewportToWorldPoint(new Vector3(0, 0, cam.camera.farClipPlane));
        minY = pos.y;
		
		//grab ref to playerInfo
		pi = (PlayerInfo)gameObject.GetComponent(typeof(PlayerInfo));
    }
	
    // Update is called once per frame
    void Update()
    {
        //amount to move
        float amtToMove = Input.GetAxisRaw("Vertical") * PlayerSpeed*Time.deltaTime;

        //float amtToMove = Input.GetAxisRaw("Vertical") * PlayerSpeed * Time.deltaTime;

        //move player
        transform.Translate(Vector3.up * amtToMove);
        //player wrap
        if (transform.position.y <= minY)
            transform.position = new Vector3(transform.position.x, maxY, transform.position.z);
        else if (transform.position.y > maxY)
            transform.position = new Vector3(transform.position.x, minY, transform.position.z);
        
		//handle fire speed and fire bullet
		timer += 1* Time.deltaTime;
		if (Input.GetButton("Fire1") && timer >= fireDelay)
        {
			gameObject.SendMessage("fire");
			audio.Play ();
			timer = 0;
        }
		
		if(Input.GetButton("Fire2"))
		{
			FireBomb();
		}
		//call respawn update
		RespwanUpdate();
    }
	
	void OnTriggerEnter(Collider c){
		
		if(vulnerable && c.gameObject.tag != "Upgrade")
		{
			//explode
			Instantiate(explosion,gameObject.transform.position, Quaternion.identity);
			//decrement live counter
			pi.TakeLife();
			//gameover if out of lives
			if(PlayerInfo.lives <=0)
			{	
				Application.LoadLevel("GameOver");
				Destroy(gameObject);
			}
			vulnerable = false;
		}		
	}
	
	//My functions//
	
	//Handles flickering and invulnerability on respawning
	void RespwanUpdate()
	{
		//only update if vulnerable
		if(!vulnerable)
		{
			respwanTimer += 1*Time.deltaTime;
			flashTimer += 1*Time.deltaTime;
			
			//flash the player model
			if(flashTimer >= flashTime)
			{	
				gameObject.renderer.enabled = !(gameObject.renderer.enabled);
				flashTimer = 0.0f;
			}
			//when time's up player is vulnerable again
			if(respwanTimer >= invTime)
			{
				vulnerable = true;
				gameObject.renderer.enabled = true;
				respwanTimer = 0;
				
			}
			
		}
	}
	
	//Fires the emp bomb
	void FireBomb()
	{
		//check to see if a bomb is already active and that a bomb is available
		if(db == null && PlayerInfo.bombs >0)
		{
			//make and launch the bomb
			db = (GameObject)Instantiate(daBomb, transform.position, Quaternion.identity);
			db.rigidbody.velocity = (new Vector3(1,0,0)) * 5;
			pi.UseBomb();
		}
	}
		
}
