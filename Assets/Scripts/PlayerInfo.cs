//PlayerInfo.cs
//Talks to gui object in scene
//Houses player lives/score/upgrades
using UnityEngine;
using System.Collections;

public class PlayerInfo : MonoBehaviour {
	
	//GUItext objects to be change - these are refrenced using Unity editor
	public GUIText GUIscore;
	public GUIText GUIlives;
	public GUIText GUIbombs;
	public GUIText GUIgoal;
	
	//Player score
	public static int score;
	
	//Ref to upgrades
	public GameObject upgrade1, upgrade2;
	
	//player lives
	public  static int lives = 2;
	
	//number of available bombs
	public static int bombs = 2;
	
	
	// Use this for initialization
	void Start () {
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {
	//Init gui texts
		GUIscore.text = score.ToString();
		GUIlives.text = "Lives: " + lives.ToString();
		GUIbombs.text = "Bombs: " + bombs.ToString();
	}

	
	//My Functions//
	
	public void AddUpgrade(int id)
	{
	}
	//AddsUpgrade to the player
	public void AddUpdrage2(GameObject newUp)
	{
		//Probs need to set location too;
		newUp.transform.parent = gameObject.transform;
		
		//adds upgrade - if slots are full drops upgrade 1
		if(upgrade1 == null)
		{
			upgrade1 = newUp;
		}
		else if(upgrade2 == null)
		{	
			upgrade2 = newUp;
		}
		else
		{	
			Destroy(upgrade1);	
			upgrade1 = upgrade2;
			Destroy(upgrade2);
			upgrade2 = newUp;
		}	
	}
	
	//AddScore: increments score - called by KillEnemy script
	public void AddScore(int aScore)
	{
		score+= aScore;
		GUIscore.text = score.ToString();
	}
	
	//decrement lives and update gui
	public void TakeLife()
	{
		lives --;
		GUIlives.text = "Lives: " + lives.ToString();
	}
	
	//decrement bombs and update gui
	public void UseBomb()
	{
		bombs--;
		GUIbombs.text = "Bombs: " + bombs.ToString();
	}
	
	public void setGoal(int killamt, float time){
	if(killamt>0){
			//GUIgoal.guiText = "Kill: ";
			GUIgoal.text = killamt.ToString ();
		}
	else
		{
		//GUIgoal.guiText = "Time Left: ";
		GUIgoal.text = time.ToString ();	
		}
	}
	public void updateKillGoal(int a){
		if(a>=0)
		GUIgoal.text = a.ToString();
		}
	public void updateTimedGoal(float t){
		GUIgoal.text = t.ToString ().Substring (0,4);	
	}
	public void clearGoal(){
		GUIgoal.text = "Wave Completed!";	
	}
}
