using UnityEngine;
using System.Collections;

//timed wave = 0,3 kill count wave = 1, kill streak = 2
/// <summary>
/// WaveCreator.cs Written by James Hunsucker
/// This script is used to create the new enemy waves.  It determines the wave type or goal the player must
/// achieve to progress to the next wave.  There are three different types of waves: timed(player just has to survive
/// until the timer has run out), kill count (the player must accumulate a determined amount of kills to progress), and
/// kill streak(the player must kill a determined amount of enemies before any enemies finish their path).
/// 
/// </summary>
public class WaveCreator : MonoBehaviour {
	//varaiables to keep track of last wave to increment them
	public float twaveDuration;
	private int killamt, killStreak;
	//keeps track of minimum and maximum enemies to appear in a wave and their start locations
	public int locmin,locmax,minEnemies,maxEnemies;
	//private int difficulty;
	public int WaveType;
	private WaveEmitter WE;
	private int loc1,loc2,loc3,loc4,loc5;//number of enemies generated from a certain location
	
	public int createWave(int prevWave){
	//randomly select between timed, killcount, and kill streak	
	//and make sure that the next wave is a different type than the previous
		switch (prevWave){
		case 0://previous wave was timed
		case 3:
			WaveType = Random.Range (1,2);
			break;
		case 1://previous wave was kill count
			WaveType = Random.Range (2,3);
			break;
		case 2://previous wave was kill streak
			WaveType = Random.Range (0,1);
			break;
		default:
			WaveType=Random.Range (0,1);
			break;
		}//end of switch statement
		prevWave = WaveType;
		//change variables that affect all wave types
		minEnemies += 1;
		maxEnemies += 2;
		locmax++;
		if(WaveType==0||WaveType==3){//timed wave
			//determine # of enemies and start location distribution and length of time
			twaveDuration+=5.0f;
			startLocations();
			//tell the WaveEmitter to create the new timed wave
			WE.newTimedWave(twaveDuration,loc1,loc2,loc3,loc4,loc5,0.0f);
		}
		if(WaveType==1||WaveType==2){//kill count wave
			killamt += Random.Range (5,10);
			startLocations();
			WE.newKillCountWave (killamt,loc1,loc2,loc3,loc4,loc5,0.0f);
		}
		//will not be implemented in this version
		//if(WaveType==2){//kill streak wave
		//	killStreak += Random.Range (2,5);
	//		startLocations();
	//	}
		return WaveType;
	}
	
		void startLocations(){
		//this function randomly decides where the enemies will spawn from.  
			//reset all values
			int amtEnemies = Random.Range (minEnemies,maxEnemies);
			int t = 0;
			loc1 = 0;
			loc2 = 0;
			loc3 = 0;
			loc4 = 0;
			loc5 = 0;
				while(t<amtEnemies){
				//continue to loop until all enemies have a starting location
					if(locmin==1&&t<amtEnemies){//spawn from area 1
						int a = Random.Range (1,amtEnemies-t);
						t+=a;
						loc1+=a;
					}
					if(locmin<3&&locmax>2&&t<amtEnemies){//spawn from area 2
						int a = Random.Range (1,amtEnemies-t);
						t+=a;
						loc2+=a;
					}
					if(locmin<4&&locmax>3&&t<amtEnemies){//spawn from area 3
						int a = Random.Range (1,amtEnemies-t);
						t+=a;
						loc3+=a;
					}
					if(locmin<3&&locmax>4&&t<amtEnemies){//spawn from area 4
						int a = Random.Range (1,amtEnemies-t);
						t+=a;
						loc4+=a;
					}
					if(locmax>4&&t<amtEnemies){//spawn from area 5
						t += Random.Range (1,amtEnemies-t);
						loc5+=t;
					}
		}//end of while loop
	}//end of startLocations

	public void setDifficulty(int difficulty){
		//used to set the defaul values for the waves
		locmin = 1;
		if ( difficulty>4)
			locmax = 5;
		else
			locmax = 1+difficulty;
		twaveDuration = 10.0f;
		minEnemies = 2+difficulty;
		maxEnemies = 4+difficulty;
		WaveType = -1;
		//set initial wave goals they will be incremented with the first wave so they should start lower
		killamt = 6+difficulty;
		//killStreak = 3+difficulty;
		//create reference to the WaveEmitter
		GameObject go = (GameObject)GameObject.FindGameObjectWithTag("WaveGen");
		WE = (WaveEmitter)go.GetComponent ("WaveEmitter");
	//TODO change the rest of the game settings
	}
}//end of class