using UnityEngine;
using System.Collections;

public class EnemyEmitter : MonoBehaviour {
	static Color[] Ecolors = {Color.blue,Color.green,Color.yellow,Color.white,Color.red,Color.cyan,Color.gray};
	public bool isActive;
	private int colorIndex;
	public float delay;
	private float timeElapsed;
	GameObject go;
	GetPath e;//enemy object
	private EnemyManager myEnemyManager;
	public int m_wavenum;
	// Use this for initialization
	void Awake () {
		go = (GameObject)GameObject.FindGameObjectWithTag("ObjectManager");
		myEnemyManager = (EnemyManager)go.GetComponent ("EnemyManager");
		isActive=false;
		delay = 0.0f;
		timeElapsed = 0.0f;
		m_wavenum=0;
		colorIndex=0;
	}
	
	public void sendEnemy(){
			go = myEnemyManager.giveEnemy ();
			e = (GetPath)go.GetComponent ("GetPath");
			if(e.waveNum==m_wavenum){//enemy has path and is ready to go
				e.startPath ();
				go.renderer.enabled=true;
				go.rigidbody.detectCollisions=true;	
				KillEnemy ke = (KillEnemy)go.GetComponent(typeof(KillEnemy));
				SpiralEmitter se = (SpiralEmitter)go.GetComponent(typeof(SpiralEmitter));
				ke.SetAlive();
				se.TimerOn();
				go.renderer.material.SetColor ("_Color",Ecolors[colorIndex]);
			}
			else
				myEnemyManager.recieveEnemy (go);
	}
public void nextColor(){
	//changes the colors of the enemies
		colorIndex++;
	}
}
