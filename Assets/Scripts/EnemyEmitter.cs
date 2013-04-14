using UnityEngine;
using System.Collections;
/// <summary>
/// EnemyEmitter.cs written by James Hunsucker
/// The EnemyEmitter is responsible for making sure an enemy is ready to be released.
/// The enemy is put on it's path, is set visible, collisions enabled on the enemy object, the enemy
/// firing is turned on, and the enemy's color is changed for a new wave.
/// </summary>
public class EnemyEmitter : MonoBehaviour {
	static Color[] Ecolors = {Color.blue,Color.green,Color.yellow,Color.white,Color.red,Color.cyan,Color.gray};
	private int colorIndex;//Which color the enemies will be. Incremented in WaveEmitter
	GameObject go;
	private GetPath e;//enemy pathing script
	private EnemyManager myEnemyManager;
	private WaveEmitter WE;
	// Use this for initialization
	void Start () {
		//set up the references to other objects
		go = (GameObject)GameObject.FindGameObjectWithTag("ObjectManager");
		myEnemyManager = (EnemyManager)go.GetComponent ("EnemyManager");
		go = (GameObject)GameObject.FindGameObjectWithTag("WaveGen");
		WE = (WaveEmitter)go.GetComponent("WaveEmitter");
		colorIndex=0;
	}
	
	public void sendEnemy(){
		//sendEnemy is called by the WaveEmitter whenever the the number of activeEnemies is less than
		//the number of enemies in the wave.
			go = myEnemyManager.giveEnemy ();
			e = (GetPath)go.GetComponent ("GetPath");
			if(e.waveNum==WE.wavenum){//enemy has path and is ready to go
				e.startPath ();
				go.renderer.enabled=true;//make enemy visible
				go.rigidbody.detectCollisions=true;	
				KillEnemy ke = (KillEnemy)go.GetComponent(typeof(KillEnemy));
				SpiralEmitter se = (SpiralEmitter)go.GetComponent(typeof(SpiralEmitter));
				ke.SetAlive();
				se.TimerOn();//turn enemy firing on
				go.renderer.material.SetColor ("_Color",Ecolors[colorIndex]);
			}
			else//enemy is not on the current wave.  Return to Sender
				myEnemyManager.recieveEnemy (go);
	}
public void nextColor(){
	//changes the colors of the enemies
		if(colorIndex<5)
			colorIndex++;
		else//reset index to 0
			colorIndex=0;
	}
}
