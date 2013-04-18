using UnityEngine;
using System.Collections;

public class AddLife : MonoBehaviour {

	void OnTriggerEnter(Collider c)
	{
		PlayerInfo.lives++;
		Destroy (gameObject);
	}
}
