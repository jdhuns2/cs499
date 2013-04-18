using UnityEngine;
using System.Collections;

public class AddRapidFire : MonoBehaviour {

	void OnTriggerEnter(Collider c)
	{
		GameObject go = GameObject.FindGameObjectWithTag("Player");
		Player p = (Player)go.GetComponent(typeof(Player));
		
		p.fireDelay /=2;
		
		Destroy(gameObject);
	}
}
