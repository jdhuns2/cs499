using UnityEngine;
using System.Collections;

public class _blankEmitter : MonoBehaviour {
	
	private BulletManager bm;	//Bullet cache
	private Vector3 direction;	//direction to fire
	private float timer = 0;	//time keeper
	public float speed = 0;		//speed of the bullets
	
	// Use this for initialization
	void Start () {
		GameObject go = (GameObject)GameObject.FindGameObjectWithTag("ObjectManager");
		bm = (BulletManager)go.GetComponent("BulletManager");
	}
	
	// Update is called once per frame
	void Update () {
	
		timer += Time.deltaTime;	//keep track of time in seconds
	}
}
