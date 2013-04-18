using UnityEngine;
using System.Collections;

public class UpgradeMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
		rigidbody.velocity = new Vector3(-1,0,0);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.up, 0.2f);
	}
}
