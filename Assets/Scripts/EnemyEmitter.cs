using UnityEngine;
using System.Collections;

public class EnemyEmitter : MonoBehaviour {
	
	public bool isActive;
	GameObject go;
	GetPath e;//enemy object
	private EnemyManager myEnemyManager;
	public int m_wavenum;
	// Use this for initialization
	void Awake () {
		go = (GameObject)GameObject.FindGameObjectWithTag("ObjectManager");
		myEnemyManager = (EnemyManager)go.GetComponent ("EnemyManager");
		isActive=false;
		m_wavenum=0;
	}
	
	// Update is called once per frame
	void Update () {
		if(isActive){
		//release the enemies!!
		go = myEnemyManager.giveEnemy ();
			
			//go.transform.collider.isTrigger = true;
		e = (GetPath)go.GetComponent ("GetPath");
			if(e.waveNum==m_wavenum)//enemy has path and is ready to go
			{	
				e.startPath ();
				go.renderer.enabled=true;
				go.rigidbody.detectCollisions=true;
				
				KillEnemy ke = (KillEnemy)go.GetComponent(typeof(KillEnemy));
				SpiralEmitter se = (SpiralEmitter)go.GetComponent(typeof(SpiralEmitter));
				
				ke.SetAlive();
				se.TimerOn();
				//go.SendMessage("SetAlive");
				//go.SendMessage("TimerOn");
			}
			else
				myEnemyManager.recieveEnemy (go);
			
			isActive=false;
		}//end of if(isActive)
	}

}
