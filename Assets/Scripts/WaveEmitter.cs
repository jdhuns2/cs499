using UnityEngine;
using System.Collections;

public class WaveEmitter : MonoBehaviour {

	RPathGen myPathgen;
	EnemyManager myEnemyManager;
	public int activeEnemies;
	private float timer;//used for timed waves
	private int enemieslost;//used for waves that end after certain amount of enemies killed
	private EnemyEmitter myEnemyEmitter;
	public int wavenum;
	// Use this for initialization
	void Awake () {
		GameObject go = (GameObject)GameObject.FindGameObjectWithTag("WaveGen");
		myPathgen = (RPathGen)go.GetComponent("RPathGen");
		myEnemyEmitter=(EnemyEmitter)go.GetComponent ("EnemyEmitter");
		myPathgen.init();
		//initialize the first paths
		myPathgen.genPaths (0,10);
		//initialize enemies
		go = (GameObject)GameObject.FindGameObjectWithTag("ObjectManager");
		myEnemyManager = (EnemyManager)go.GetComponent("EnemyManager");
		myEnemyManager.initEnemies ();
		wavenum = 0;
		activeEnemies=0;
	}
	
	// Update is called once per frame
	void Update () {
	if (wavenum==0)
			newTimedWave (0,8,0,0,0,0);
	if(activeEnemies<8){
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
		for(int i=0;i<loc1;i++){
			spawnFromLocation1 ();
			activeEnemies++;
		}
		//TODO add int other locations
		
		//done setting up enemies, now to release them
		myEnemyEmitter.isActive=true;
	}
	private void spawnFromLocation1(){
		GameObject go;
		GetPath e;
			go = myEnemyManager.giveEnemy();
			e = (GetPath)go.GetComponent("GetPath");
			e.waveNum = wavenum;
			e.setPath (0,9);//need to change to array indexes that correspond to location
			//place enemy at end of list
		    myEnemyManager.recieveEnemy (go);
	}
	
	void newWave()
	{
		//put enemies on paths and set wavenum
		myEnemyManager.initEnemies();	//futue: here we pass the type of enemies
		this.activeEnemies=10;
	}
}
