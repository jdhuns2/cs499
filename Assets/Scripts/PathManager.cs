using UnityEngine;
using System.Collections;
	public struct PathDirections
	{public float min, max;
	}
public class PathManager : MonoBehaviour {
	PathDirections LEFT,UP,DOWN,LEFT_UP,LEFT_DOWN;
	float radius;
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
		this.radius = radius;
if(startMin<1)
	startMin=1;
if(startMax>5)
	startMax=5;
if(startMin>startMax)
	startMax=5;
		
	startloc = Random.Range (startMin,startMax);
	path[0] = startNode (startloc);
	path[1] = secondNode (startloc,path[0]);
	for (int i=2; i<NUMNODES-1;i++)
			path[i] = nextNode (path[i-1]);
	path[NUMNODES-1] = lastNode (path[NUMNODES-2]);
	Debug.Log ("path");	
	}
	private Vector3 startNode(int location){
	//generates a random start location outside of the play area based on location given
		switch(location){
		case 1:
			return new Vector3(1.1f,Random.Range (0.0f,1.0f),0);
		case 2:
			return new Vector3(Random.Range(0.5f,1.0f),-0.1f,0);
		case 3:
			return new Vector3(Random.Range (0.5f,1.0f),1.1f,0);
		case 4:
			return new Vector3(Random.Range (0.25f,0.5f),-1.1f,0);
		case 5:
			return new Vector3(Random.Range (0.25f,0.5f),1.1f,0);
		default:
			return new Vector3(1.1f,0.5f,0);
	}//end of switch
	}//end of startNode
	private Vector3 secondNode(int first,Vector3 previous){
	//generates random second node based on starting location
	  if(first==1)
			return left(previous);
	  if(first==2)
			return functionMap (Random.Range (0,1),previous);
	  if(first==3)
			return functionMap (Random.Range (3,4),previous);
	  if(first==4)
			return functionMap (Random.Range (7,8),previous);
	  if(first==5)
			return functionMap (Random.Range (4,5),previous);
		//if here then an error happened
		return left (previous);
	}//end of secondNode()
	private Vector3 nextNode(Vector3 previous){
	//determines possible directions that will keep the path in the play area and then picks a random direction	
		float fbottom,ftop,fleft,fright;
		fbottom = previous.y-radius;//must be >0
		ftop = previous.y+radius;//must be <1
		fleft = previous.x-radius;//must be >0
		fright = previous.x+radius;//must be <1
		//enemy in middle
		if(fbottom>0&&ftop<1&&fleft>0&&fright<1)
			return functionMap (Random.Range (0,7),previous);
		//check corners
		//bottomleft corner
		if(fbottom<0&&fleft<0)
			return functionMap (Random.Range (6,8),previous);
		//bottomright corner
		if(fbottom<0&&fright>1)
			return functionMap (Random.Range (0,2),previous);
		//topright corner
		if(ftop>1&&fright>1)
			return functionMap (Random.Range (2,4),previous);
		//topleft corner
		if(ftop>1&&fleft<0)
			return functionMap (Random.Range (4,6),previous);
		//if we made it here enemy isn't in middle or corners..must be close to play area edge though
		//enemy close to right side of play area
		if(fright>1)
			return functionMap (Random.Range (0,4),previous);
		//enemy close to left side of play area
		if(fleft<0)
			return functionMap (Random.Range (4,8),previous);
		//enemy close to bottom of play area
		if(fbottom<0)
			return functionMap (Random.Range (6,10),previous);
		//enemy close to top of play area
		if(ftop>1)
			return functionMap (Random.Range (2,6),previous);
		//default if logic is faulty
		return left (previous);
	}
	private Vector3 lastNode(Vector3 previous){
	//checks for playarea edge and goes for it
		if(previous.y+radius>1)
			return up (previous);
		if(previous.y-radius<0)
			return down (previous);
		if(previous.x+radius>1)
			return right (previous);
		if(previous.x-radius<0)
			return left (previous);
		//if we made it here enemy is not within one move from any edge
		//look for closest edge if this becomes an issue
		return new Vector3(-0.2f,Random.Range (0.0f,1.0f),0);
	}//end of lastNode()
	//functions to return the next node in the requested direction
	private Vector3 up(Vector3 previous){
		float angle = Random.Range (UP.min,UP.max);
		Vector3 a = new Vector3((radius*Mathf.Cos(angle))+previous.x,(radius*Mathf.Sin(angle))+previous.y,0);
		return a;
	}
	private Vector3 down(Vector3 previous){
		float angle = Random.Range (DOWN.min,DOWN.max);
		Vector3 a = new Vector3((radius*Mathf.Cos(angle))+previous.x,(radius*Mathf.Sin(angle))+previous.y,0);
		return a;
	
	}
	private Vector3 left(Vector3 previous){
		float angle = Random.Range (LEFT.min,LEFT.max);
		Vector3 a = new Vector3((radius*Mathf.Cos(angle))+previous.x,(radius*Mathf.Sin(angle))+previous.y,0);
		return a;
	}
	private Vector3 right(Vector3 previous){
		float angle = Random.Range (LEFT.min,LEFT.max);
		angle+=Mathf.PI;//reverse left to make direction right
		Vector3 a = new Vector3((radius*Mathf.Cos(angle))+previous.x,(radius*Mathf.Sin(angle))+previous.y,0);
		return a;
	}
	private Vector3 left_down(Vector3 previous){
		float angle = Random.Range (LEFT_DOWN.min,LEFT_DOWN.max);
		Vector3 a = new Vector3((radius*Mathf.Cos(angle))+previous.x,(radius*Mathf.Sin(angle))+previous.y,0);
		return a;
	}
	private Vector3 left_up(Vector3 previous){
		float angle = Random.Range (LEFT_UP.min,LEFT_UP.max);
		Vector3 a = new Vector3((radius*Mathf.Cos(angle))+previous.x,(radius*Mathf.Sin(angle))+previous.y,0);
		return a;
	}
	private Vector3 right_down(Vector3 previous){
		float angle = Random.Range (LEFT_DOWN.min,LEFT_DOWN.max);
		angle+=Mathf.PI;//reverse left to make direction right
		Vector3 a = new Vector3((radius*Mathf.Cos(angle))+previous.x,(radius*Mathf.Sin(angle))+previous.y,0);
		return a;
	}
	private Vector3 right_up(Vector3 previous){
		float angle = Random.Range (LEFT_UP.min,LEFT_UP.max);
		angle+=Mathf.PI;//reverse left to make direction right
		Vector3 a = new Vector3((radius*Mathf.Cos(angle))+previous.x,(radius*Mathf.Sin(angle))+previous.y,0);
		return a;
	}
	private Vector3 functionMap(int index,Vector3 previous){
	//this function calls the corresponding direction function so that directions can be generated randomly
	//0/8-up 1-leftup 2-left 3-leftdown 4-down 5-rightdown 6-right 7-rightup
		switch(index){
		case 0://up is mapped twice so random.range can be used
		case 8:
			return up (previous);
		case 1:
		case 9:
			return left_up(previous);
		case 2:
		case 10:
			return left (previous);
		case 3:
			return left_down (previous);
		case 4:
			return down (previous);
		case 5:
			return right_down (previous);
		case 6:
			return right (previous);
		case 7:
			return right_up (previous);
		default:
			return left (previous);
		}//end of switch
	
	
	}//end of functionMap()
}
