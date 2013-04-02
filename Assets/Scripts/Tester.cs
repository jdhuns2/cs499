using UnityEngine;
using System.Collections;

public class Tester : MonoBehaviour {
	private float x, y, z;
	// Use this for initialization
	void Start () {
		SetPosition();
		iTween.MoveTo(gameObject, iTween.Hash("path",iTweenPath.GetPath("path_1"),"time",20));
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (transform.position.y < -4.3)
		{
			SetPosition();
			int a = Random.Range(1,5);
			Debug.Log (a);
			if (a == 2)
			iTween.MoveTo(gameObject, iTween.Hash("path",iTweenPath.GetPath("path_2"),"time",20));
			if (a ==3)
			iTween.MoveTo(gameObject, iTween.Hash("path",iTweenPath.GetPath("path_3"),"time",20));
			if (a == 4)
			iTween.MoveTo(gameObject, iTween.Hash("path",iTweenPath.GetPath("path_4"),"time",20));
			if(a == 5)
			iTween.MoveTo(gameObject, iTween.Hash("path",iTweenPath.GetPath("path_5"),"time",20));
		}
	}
	public void SetPosition(){
	
		//currentSpeed = Random.Range(MinSpeed,MaxSpeed);
		transform.position = new Vector3(x,y,z);
		x = Random.Range(-6f, 6f);
		y = 5.5f;
		z = 0.0f;
		transform.position = new Vector3(x,y,z);
	}
	
}
