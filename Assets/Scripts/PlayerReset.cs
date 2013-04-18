//PlayerReset.cs
//By Cron Broaddus
//Resets the static variables in PlayerInfo.cs if the game restarts

using UnityEngine;
using System.Collections;

public class PlayerReset : MonoBehaviour {
	
	public int startingLives = 2, startingBombs = 2;
	// Use this for initialization
	void Start () {
		PlayerInfo.lives = startingLives;
		PlayerInfo.bombs = startingBombs;
		PlayerInfo.score = 0;
	}
}
