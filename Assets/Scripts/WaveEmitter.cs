using UnityEngine;
using System.Collections;

public class WaveEmitter : MonoBehaviour {

	RPathGen myPathgen;
	EnemyManager myEnemyManager;
	// Use this for initialization
	void Start () {
		GameObject go = (GameObject)GameObject.FindGameObjectWithTag("WaveGen");
		myPathgen = (RPathGen)go.GetComponent("RPathGen");
		
		go = (GameObject)GameObject.FindGameObjectWithTag("ObjectManager");
		myEnemyManager = (EnemyManager)go.GetComponent("EnemyManager");
		
		myPathgen.init();
		
		newWave();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	
	/////////////My functions/////////////
	
	//Before each wave - create new paths 
	void genPaths()
	{
		myPathgen.genPaths();
	}
	
	void newWave()
	{
		genPaths();
		myEnemyManager.initEnemies();	//futue: here we pass the type of enemies
	}
}
