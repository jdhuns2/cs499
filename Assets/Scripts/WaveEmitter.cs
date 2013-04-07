using UnityEngine;
using System.Collections;
using System.Threading;


public class WaveEmitter : MonoBehaviour {
	EnemyManager myEnemyManager;
	private WaveCreator myWaveCreator;
	public int activeEnemies;
	private float timer;//used for timed waves
	private int enemieslost;//used for waves that end after certain amount of enemies killed
	private EnemyEmitter myEnemyEmitter;
	public int wavenum;
	private int totalEnemies;
	private bool isWaveActive;
	// Use this for initialization
	void Awake () {
		GameObject go = (GameObject)GameObject.FindGameObjectWithTag("WaveGen");
		myEnemyEmitter=(EnemyEmitter)go.GetComponent ("EnemyEmitter");
		myWaveCreator = (WaveCreator)go.GetComponent ("WaveCreator");
		//initialize enemies
		go = (GameObject)GameObject.FindGameObjectWithTag("ObjectManager");
		myEnemyManager = (EnemyManager)go.GetComponent("EnemyManager");
		myEnemyManager.initEnemies ();
		//initialize local variables
		wavenum = 0;
		activeEnemies=0;
		isWaveActive = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(!isWaveActive){//create a new wave!!
			
			
		}
		/*
		 
	if (wavenum==0)
			newTimedWave (0,8,0,0,0,0);
	if(activeEnemies<totalEnemies){
			//Debug.Log (activeEnemies);
			myEnemyEmitter.isActive=true;
		}*/
	}
	/////////////My functions/////////////
	
	public void newTimedWave(float seconds,int loc1, int loc2, int loc3, int loc4, int loc5){
		//sets up timed wave
		timer = 0.0f;
		wavenum++;
		//emitter and waveEmitter are on same wave
		myEnemyEmitter.m_wavenum = wavenum;
		//create enemies for each starting location specified
		for(int i=0;i<loc1;i++){
			spawnFromLocation(1,1);
			totalEnemies++;
		}
		for(int i=0;i<loc2;i++){
			spawnFromLocation(2,2);
			totalEnemies++;
		}
		for(int i=0;i<loc3;i++){
			spawnFromLocation(3,3);
			totalEnemies++;
		}
		for(int i=0;i<loc4;i++){
			spawnFromLocation(4,4);
			totalEnemies++;
		}
		for(int i=0;i<loc5;i++){
			spawnFromLocation(5,5);
			totalEnemies++;
		}
		Debug.Log ("Activeenemies"+activeEnemies);
		//done setting up enemies, now to release them
		myEnemyEmitter.isActive=true;
	}
	private void spawnFromLocation(int min, int max){
		GameObject go;
		GetPath e;
			go = myEnemyManager.giveEnemy();
			e = (GetPath)go.GetComponent("GetPath");
			e.waveNum = wavenum;
			e.createPath(min,max);
			//place enemy at end of list
		    myEnemyManager.recieveEnemy (go);
	}

}
