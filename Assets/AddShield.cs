using UnityEngine;
using System.Collections;

public class AddShield : MonoBehaviour {

	public GameObject shieldFab;
	
	void OnTriggerEnter(Collider c)
	{
		Instantiate(shieldFab, c.gameObject.transform.position,Quaternion.identity);
		Destroy(gameObject);
	}
}
