using UnityEngine;
using System.Collections;
	public struct PathDirections
	{public float min, max;
	}
public class PathManager : MonoBehaviour {
	PathDirections LEFT,UP,DOWN,LEFT_UP,LEFT_DOWN;
	// Use this for initialization
	void Start () {
		//add PI to left directions to get right directions
		UP.min=Mathf.PI/3;
		UP.max=3*Mathf.PI/4;
		LEFT.min=5*Mathf.PI/6;
		LEFT.max=7*Mathf.PI/6;
		DOWN.min=4*Mathf.PI/3;
		DOWN.max=5*Mathf.PI/3;
		LEFT_UP.min=2*Mathf.PI/3;
		LEFT_UP.max = 5*Mathf.PI/6;
		LEFT_DOWN.min=7*Mathf.PI/6;
		LEFT_DOWN.max=4*Mathf.PI/3;
	}
public void createPath(int startMin,int startMax,Vector3[] path,float radius,int NUMNODES){
//creates a path by choosing a random starting location from the minimum and maximum provided
//map of starting locations for enemies:
		///<map>
		//       |  5  |  3  | 
		//    ---+-----------+-----   
		//     0 |           |  1
		//     0 | play area |  1
		//    ---+-----------+-----
		//       |  4  |  2  |
	///</map> 
		//end locations cannot be adjacent or equal to starting location
//check to make sure range is in map	
		int startloc;
		int endloc;
if(startMin<1)
	startMin=1;
if(startMax>5)
	startMax=5;
if(startMin>=startMax)
	startMax=5;
		
startloc = Random.Range (startMin,startMax);
		
	
	
	
	
	
	
	
	}
}
