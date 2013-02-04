using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	// Use this for initialization
	#region
	
	public float MinSpeed;
	public float MaxSpeed;
	private float currentSpeed;
	private float x, y, z;
	
	#endregion
	
	#region

	void Start () {
		SetPositionandSpeed();
		
	}
	#endregion
	// Update is called once per frame
	
	#region
	
	  void Update () {
		float amtToMove = currentSpeed*Time.deltaTime;
		transform.Translate(Vector3.down * amtToMove);
		if (transform.position.y < -5.5)
		{
			SetPositionandSpeed();
		}
		}
	
	public void SetPositionandSpeed(){
	
		currentSpeed = Random.Range(MinSpeed,MaxSpeed);
		transform.position = new Vector3(x,y,z);
		x = Random.Range(-6f, 6f);
		y = 5.5f;
		z = 0.0f;
		transform.position = new Vector3(x,y,z);
	}
	
	#endregion
}
