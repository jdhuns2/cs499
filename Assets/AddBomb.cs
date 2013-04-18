using UnityEngine;
using System.Collections;

public class AddBomb : MonoBehaviour {

	
	void OnTriggerEnter(Collider c)
	{
		PlayerInfo.bombs++;
		Destroy(gameObject);
	}
}
