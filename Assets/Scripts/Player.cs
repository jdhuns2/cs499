using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float PlayerSpeed;
	public GameObject ProjectilePrefab;
	public GameObject ExplosionPrefab;
	public static int Score = 0;
	public static int Lives = 3;
	public static int Missed = 0;
	// Update is called once per frame
	void Update () {
		
		// Amount to move
		float amtToMove = Input.GetAxisRaw ("Horizontal")*PlayerSpeed*Time.deltaTime;
		
		// Move the player
		transform.Translate(Vector3.right * amtToMove);
		
		// Wrap
		if (transform.position.x <= -7.5f)
			transform.position = new Vector3(7.4f, transform.position.y, transform.position.z);
		else if (transform.position.x >= 7.5f)
			transform.position = new Vector3(-7.4f, transform.position.y, transform.position.z);
		if(Input.GetKeyDown("space"))
		{
			Vector3 position = new Vector3(transform.position.x, transform.position.y + transform.localScale.y/2);
			Instantiate(ProjectilePrefab, position, Quaternion.identity);
		}
	}
	
	void OnGUI(){
		GUI.Label(new Rect(10, 10, 120, 20), "Score: " + Player.Score.ToString());
		GUI.Label(new Rect(10, 30, 60, 20), "Lives: " + Player.Lives.ToString());
		GUI.Label(new Rect(10, 50, 120, 20), "Missed: " + Player.Missed.ToString());
	}
	void OnTriggerEnter(Collider otherObject){
		Debug.Log("We hit   " + otherObject.name);
		if(otherObject.tag == "enemy")
		{
			Player.Lives -- ;
			Enemy enemy = (Enemy)otherObject.gameObject.GetComponent("Enemy");
			enemy.SetPositionandSpeed();
			
			StartCoroutine(DestroyShip());
			
		}
    }
	
	IEnumerator DestroyShip(){
		Instantiate(ExplosionPrefab, transform.position, Quaternion.identity);
		gameObject.renderer.enabled = false;
		transform.position = new Vector3(0f, transform.position.y, transform.position.z);
		yield return new WaitForSeconds(1.5f);
		
		if (Player.Lives > 0)
		gameObject.renderer.enabled = true;
		else 
			Application.LoadLevel(2);
	}
}
