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
			Tester enemy = (Tester)otherObject.gameObject.GetComponent("Tester");
			
			Instantiate(ExplosionPrefab, enemy.transform.position, enemy.transform.rotation);
			//Instantiate(
			enemy.SetPosition();
			
			iTween.Stop(otherObject.gameObject);
			
			Destroy(otherObject.gameObject);
			Debug.Log("Destroy");
			if(Player.Score >= 2000)
				Application.LoadLevel(3);
	}
    }
	
}