using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {

	public int basicAmount = 30;	//number of enemies
	ArrayList basicList;			//enemy ref array
	
	
	/// <summary>
	/// Create more prefabs here for each enemy type
	/// </summary>
	public GameObject basicFab; 
	//....
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	
	//My functions///
	
	//create cache of enemies - should be done each wave
	public void initEnemies() //future: pass number of enemy types (int t1, int t2....)
	{
		basicList = new ArrayList();
		if(basicFab != null)
			for(int i = 0; i < basicAmount; i++)
			{
				GameObject ne = (GameObject)Instantiate(basicFab);
				ne.SendMessage("Start");
				ne.renderer.enabled = false;	//don't want to see them before "spawning"
				ne.SendMessage("setParent", this);	//let them know who's boss
				//nb.rigidbody.detectCollisions = false;
				//ne.collider.enabled = false;
				basicList.Add(ne);
			}
	}
	
	public GameObject giveEnemy() //future : add switch to give differnt enemies. Pass in type (int 0-whatever)
	{
		GameObject r;
		if(basicList.Count != 0)	//if list is not empty
		{
			r = (GameObject)basicList[0];
			basicList.Remove(r);
			basicAmount = basicList.Count;
		}
		else{					//if list is empty create a new bullet
			r = (GameObject)Instantiate(basicFab);
			r.SendMessage ("Start");
//			r.renderer.enabled = false;
			r.SendMessage("setParent", this);	//let them know who's boss
			//r.rigidbody.detectCollisions = false;
			//r.collider.enabled = false;
		}
		return r;
	}
	public void recieveEnemy(GameObject enemy){
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
