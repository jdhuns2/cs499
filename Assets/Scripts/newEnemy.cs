using UnityEngine;
using System.Collections;

public class newEnemy : MonoBehaviour {
	private Vector3[] vec1;
	
	// Use this for initialization
	//Hashtable ht = new Hashtable();
	/*
	void Awake(){
	ht.Add("x",3*Time.deltaTime);
	ht.Add("y",10*Time.deltaTime);
	ht.Add("time",1);
	ht.Add("delay",0);
	ht.Add("onupdate","myUpdateFunction");
	ht.Add("looptype",iTween.LoopType.pingPong);
	}
	 */
	void OnDrawGizmos(){
		vec1 = new Vector3[3];
		vec1[2] = new Vector3(-6,-4,0);
		vec1[1] = new Vector3(6,1,0);
		vec1[0] = new Vector3(0,5.5f,0);
       iTween.DrawPath(vec1);
    }
	void Start(){
	//iTween.MoveTo(gameObject,ht);
		
		//iTween.DrawPath(vec1);
		iTween.MoveTo(gameObject,iTween.Hash("path",vec1,"speed",5,"easetype","linear"));
	}	
	
}
