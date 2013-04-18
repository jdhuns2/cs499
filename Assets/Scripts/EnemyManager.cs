using UnityEngine;
using System.Collections;
/// <summary>
/// EnemyManager.cs by Cron Broaddus and James Hunsucker
/// The EnemyManager is responsible for creating and supplying enemies when called upon.  An ArrayList is used to store
/// the enemies.
/// </summary>
public class EnemyManager : MonoBehaviour {

	private int basicAmount = 30;	//number of enemies
	ArrayList basicList;			//enemy ref array
	
	public GameObject basicFab; 
	//create cache of enemies
	public void initEnemies() //future: pass number of enemy types (int t1, int t2....)
	{
		basicList = new ArrayList();
		if(basicFab != null)
			for(int i = 0; i < basicAmount; i++)
			{
				GameObject ne = (GameObject)Instantiate(basicFab);
				ne.SendMessage("Start");//initialize enemy
				ne.renderer.enabled = false;	//don't want to see them before "spawning"
				ne.SendMessage("setParent", this);	//let them know who's boss
				basicList.Add(ne);
			}
	}
	
	public GameObject giveEnemy() //future : add switch to give differnt enemies. Pass in type (int 0-whatever)
	{//returns a reference to an enemy to the caller, if one is not available in the list, a new enemy is created
		GameObject r;
		if(basicList.Count != 0)	//if list is not empty
		{
			r = (GameObject)basicList[0];
			basicList.Remove(r);
			basicAmount = basicList.Count;
		}
		else{//if list is empty create a new enemy
			r = (GameObject)Instantiate(basicFab);
			r.SendMessage ("Start");
			r.SendMessage("setParent", this);	//let them know who's boss
		}
		return r;
	}
	public GameObject createEnemy(){
		//Used to create enemies if no more are available to be re-assigned to the current wave.
		GameObject r;
		r = (GameObject)Instantiate (basicFab);
		r.SendMessage ("Start");
		r.SendMessage ("setParent");
		return r;
	}
	public void recieveEnemy(GameObject enemy){
		//returns an enemy to the enemy cache.
		//call this when an enemy goes out of play or is killed.
		basicList.Add(enemy);
	}
	public void killEnemies(){
	//used to kill off the enemies at the end of a wave. Ineffective
		basicFab.BroadcastMessage ("killPath");
	}
	public int listCount(){
		return basicList.Count;
	}
}
