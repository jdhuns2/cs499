using UnityEngine;
using System.Collections;

public class WaveEmitter : MonoBehaviour {

	RPathGen myPathgen;
	EnemyManager myEnemyManager;
	public int activeEnemies;
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
	if (activeEnemies<=0){
			myEnemyManager.reAnimate ();
			activeEnemies=myEnemyManager.basicAmount;
			genPaths();
		}
	}
	
	
	/////////////My functions/////////////
	
	//Before each wave - create new paths 
	void genPaths()
	{
		myPathgen.genPathsRange(5,10);
	}	
	
	void newWave()
	{
		genPaths();
		myEnemyManager.initEnemies();	//futue: here we pass the type of enemies
		this.activeEnemies=10;
	}
}
