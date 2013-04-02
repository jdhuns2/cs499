using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	// Use this for initialization
	public GameObject ExplosionPrefab;
	
	public float ProjectileSpeed;
	//public GameObject ProjectilePrefab;
	private Transform myTransform;
	void Start () {
		myTransform = transform;
	}
	
	// Update is called once per frame
	void Update () {
		float amtToMove = ProjectileSpeed * Time.deltaTime;
		myTransform.Translate(Vector3.up * amtToMove);
		
		if (myTransform.position.y >  6.3f) {
			Player.Missed++;
			Destroy(this.gameObject);}
	}
	
	void OnTriggerEnter(Collider otherObject){
		Debug.Log("We hit   " + otherObject.name);
		if(otherObject.tag == "enemy")
		{
			Player.Score += 100;
			Enemy enemy = (Enemy)otherObject.gameObject.GetComponent("Enemy");
			
			Instantiate(ExplosionPrefab, enemy.transform.position, enemy.transform.rotation);
			//Instantiate(
			enemy.SetPositionandSpeed();
			Destroy(gameObject);
			if(Player.Score >= 2000)
				Application.LoadLevel(3);
	}
    }
	
}