using UnityEngine;
using System.Collections;
using System.Threading;
	public struct PathStartLocations
	{public int min, max;
	}
public class WaveEmitter : MonoBehaviour {
	PathStartLocations ONE,TWO,THREE,FOUR,FIVE;
	//RPathGen myPathgen;
	EnemyManager myEnemyManager;
	public int activeEnemies;
	private float timer;//used for timed waves
	private int enemieslost;//used for waves that end after certain amount of enemies killed
	private EnemyEmitter myEnemyEmitter;
	public int wavenum;
	private int totalEnemies;
	// Use this for initialization
	void Awake () {
		GameObject go = (GameObject)GameObject.FindGameObjectWithTag("WaveGen");
		//myPathgen = (RPathGen)go.GetComponent("RPathGen");
		myEnemyEmitter=(EnemyEmitter)go.GetComponent ("EnemyEmitter");
		//myPathgen.init();
		//initialize the first paths
		//myPathgen.genPaths (0,20);
		//initialize enemies
		go = (GameObject)GameObject.FindGameObjectWithTag("ObjectManager");
		myEnemyManager = (EnemyManager)go.GetComponent("EnemyManager");
		myEnemyManager.initEnemies ();
		//initialize local variables
		wavenum = 0;
		activeEnemies=0;
		//valid array range to get a path from
		ONE.min = 0;
		ONE.max = 19;
		TWO.min = 20;
		TWO.max = 39;
		THREE.min = 40;
		THREE.max = 59;
		FOUR.min = 60;
		FOUR.max = 79;
		FIVE.min = 80;
		FIVE.max = 99;
	}
	
	// Update is called once per frame
	void Update () {
	if (wavenum==0)
			newTimedWave (0,8,0,0,0,0);
	if(activeEnemies<totalEnemies){
			//Debug.Log (activeEnemies);
			myEnemyEmitter.isActive=true;
		}
	}
	/////////////My functions/////////////
	
	//Before each wave - create new paths 

	public void newTimedWave(float seconds,int loc1, int loc2, int loc3, int loc4, int loc5){
		//sets up timed wave
		timer = 0.0f;
		wavenum++;
		//emitter and waveEmitter are on same wave
		myEnemyEmitter.m_wavenum = wavenum;
		//create enemies for each starting location specified
		for(int i=0;i<loc1;i++){
			spawnFromLocation(ONE);
			totalEnemies++;
		}
		for(int i=0;i<loc2;i++){
			spawnFromLocation(ONE);
			totalEnemies++;
		}
		for(int i=0;i<loc3;i++){
			spawnFromLocation(ONE);
			totalEnemies++;
		}
		for(int i=0;i<loc4;i++){
			spawnFromLocation(ONE);
			totalEnemies++;
		}
		for(int i=0;i<loc5;i++){
			spawnFromLocation(ONE);
			totalEnemies++;
		}
		Debug.Log ("Activeenemies"+activeEnemies);
		//done setting up enemies, now to release them
		myEnemyEmitter.isActive=true;
	}
	private void spawnFromLocation(PathStartLocations l){
		GameObject go;
		GetPath e;
			go = myEnemyManager.giveEnemy();
			e = (GetPath)go.GetComponent("GetPath");
			e.waveNum = wavenum;
			e.createPath(1,1);
			//place enemy at end of list
		    myEnemyManager.recieveEnemy (go);
	}

}
