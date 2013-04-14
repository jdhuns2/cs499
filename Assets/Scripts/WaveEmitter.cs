using UnityEngine;
using System.Collections;
using System.Threading;
/// <summary>
/// WaveEmitter.cs Written by James Hunsucker
/// The WaveEmitter is responsible for checking on wave completion status and emitting a new wave when
/// the current wave has been completed.
/// </summary>



public class WaveEmitter : MonoBehaviour {
	private EnemyManager myEnemyManager;
	public int activeEnemies;//# of enemies currently in the play area
	public float timer, delay;//used for timed waves
	private int enemieslost;//used for waves that end after certain amount of enemies killed
	private EnemyEmitter myEnemyEmitter;
	private WaveCreator myWaveCreator;
	public int wavenum;
	public int totalEnemies;//Total enemies that are part of the wave
	public int WAVETYPE;//the type of wave. SEE WaveCreator for descriptions
	private bool nextWave;//used to delay the appearance of the next wave of enemies
	// Use this for initialization
	void Start () {
		//set up references to other objects
		GameObject go = (GameObject)GameObject.FindGameObjectWithTag("WaveGen");
		myEnemyEmitter=(EnemyEmitter)go.GetComponent ("EnemyEmitter");
		myWaveCreator=(WaveCreator)go.GetComponent ("WaveCreator");
		//initialize WaveCreator
		myWaveCreator.setDifficulty(0);//default difficulty
		
		go = (GameObject)GameObject.FindGameObjectWithTag("ObjectManager");
		myEnemyManager = (EnemyManager)go.GetComponent("EnemyManager");
		//initialize enemies
		myEnemyManager.initEnemies ();
		//initialize local variables
		wavenum = 0;
		activeEnemies=0;
		delay = 0.0f;
		nextWave = false;
		WAVETYPE = myWaveCreator.createWave (Random.Range (0,0));//change to (1,3)
	}
	
	// Update is called once per frame
	void Update () {
		//this function checks if the current wave has been completed. If so a new wave is created and the delay for
		//the new wave to start is set.
		if(nextWave){
			delay += Time.deltaTime;
			if(delay > 3.0f){//time delay between waves
				delay = 0.0f;
				//delay is over create new wave
				WAVETYPE = myWaveCreator.createWave (WAVETYPE);
				nextWave = false;
				myEnemyEmitter.nextColor ();
			}
		}
		if(WAVETYPE==0||WAVETYPE == 3){//timed wave
			timer+=Time.deltaTime;
			//check if time has run out
			if(timer>myWaveCreator.twaveDuration){
				nextWave = true;
			}
		}
	if(activeEnemies<totalEnemies){
			myEnemyEmitter.sendEnemy ();
		}
	}

	public void newTimedWave(float seconds,int loc1, int loc2, int loc3, int loc4, int loc5, float emitterDelay){
		//sets up a new timed wave
		timer = 0.0f;
		wavenum++;
		//create enemies for each starting location specified
		enemySetUp (loc1,loc2,loc3,loc4,loc5);
	}
	public void newKillCountWave(int killamt, int loc1, int loc2, int loc3, int loc4, int loc5, float emitterDelay){
		wavenum++;
		enemySetUp (loc1,loc2,loc3,loc4,loc5);
	}
	public void newKillStreakWave(int killStreak,int loc1,int loc2,int loc3, int loc4, int loc5, float emitterDelay){
		wavenum++;
		enemySetUp (loc1,loc2,loc3,loc4,loc5);
	}
	private void enemySetUp(int loc1, int loc2, int loc3, int loc4, int loc5){
		//this is a helper function to reduce code redundancy and should be called whenever a new wave is created
		//sets up enemies on new paths for new wave.
		totalEnemies=0;
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
		
	}
	private void spawnFromLocation(int min,int max){
		//finds an enemy from an older wave and sets it on a new path
		GameObject go;
		GetPath e;
		//int trys = 0;
		go = myEnemyManager.giveEnemy();
		e = (GetPath)go.GetComponent("GetPath");
		while(e.waveNum==wavenum){//enemy is already member of wave need a new one
			myEnemyManager.recieveEnemy (go);	
			go = myEnemyManager.giveEnemy();
			e = (GetPath)go.GetComponent("GetPath");
			//trys++;
		}
		//we have enemy from older wave. Update it's wavenumber and give it a new path
		e.waveNum = wavenum;
		e.createPath(min,max);
		myEnemyManager.recieveEnemy (go);
			//place enemy at end of list	    
		}//end of spawnFromLocation
	}
