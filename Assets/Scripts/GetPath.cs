using UnityEngine;
using System.Collections;
/// <summary>
/// GetPath.cs Written by James Hunsucker
/// GetPath is attached to the enemy object.  It is responsible for putting itself back at the beginning of it's path,
/// getting a new path(called from WaveEmitter::spawnLocation), checking to see if the enemy has reached the end of it's path,
///and deactivating itself when killed or out of play
/// </summary>
public class GetPath : MonoBehaviour
{
    Vector3[] b;//holds the enemy path
	public static WaveEmitter WE;
	public static PathManager PM;
	public Camera cam1;
    public bool isActive,outofplay;
	public int waveNum;
    Vector3 temp;
    public static float minx;
	public iTweenPath path;
	private EnemyManager parent;
	private float ptime;
	public const int NUMNODES = 6;
	float R = .35f;//max distance between path nodes
    #region Functions
    // Use this for initialization
	void init(){
	    isActive = false;
		outofplay = false;
		waveNum = -1;
		
		//gets available paths
		GameObject go = (GameObject)GameObject.FindGameObjectWithTag("WaveGen");
		WE = (WaveEmitter)go.GetComponent ("WaveEmitter");
		//pths = (RPathGen)go.GetComponent("RPathGen");
		PM = (PathManager)go.GetComponent ("PathManager");
		PM.init ();
		go = (GameObject)GameObject.FindGameObjectWithTag ("MainCamera");
		cam1 = (Camera)go.GetComponent ("Camera");
		//add iTween component and get ref
		gameObject.AddComponent("iTweenPath");
		path = (iTweenPath)gameObject.GetComponent("iTweenPath");

	}
	public void startPath(){
		//puts the enemy back at beginning of path
		ptime=0.0f;//reset time on path
		iTween.MoveTo (gameObject,b[0],0.0f);//move enemy to start of path
		iTween.PutOnPath (this.gameObject,b,0.0f);
		isActive=true;
		outofplay=false;
		WE.activeEnemies++;
	}
	public void createPath(int min,int max){
		//gets a random path from the location provided
		//give path required amount of nodes
		if(path.nodes.Count<NUMNODES){
			for(int i = path.nodes.Count; i <NUMNODES; i++)
				path.nodes.Add(new Vector3());
		}//end if
		//get the name for dictionary (it's the Key)
		b = iTweenPath.GetPath(path.pathName);
		//use NUMNODES-1 so that last node can move enemy out of play area via z axis
		PM.createPath (min,max,b,R,NUMNODES);
		for (int j = 0; j < NUMNODES; j++)
                {//convert from camera coordinates to world coordinates
                    temp = cam1.camera.ViewportToWorldPoint(new Vector3(b[j].x, b[j].y, cam1.camera.farClipPlane));
                    b[j].x = temp.x;
                    b[j].y = temp.y;
                    b[j].z = temp.z;
                }
	}
    void Start()
    {
		init();
    }
    
    // Update is called once per frame
    void Update()
    {
	
        if(isActive)
        {
			ptime+=Time.deltaTime;//increment time enemy has been on path
            iTween.MoveTo(gameObject, iTween.Hash("easetype",iTween.EaseType.linear,"path", b, "time", 15));
			//since enemy paths may start and end in similar locations we must wait to check if the enemy is out of play
			if(ptime>14.0)
				if(gameObject.transform.position.x-temp.x<0.05&&gameObject.transform.position.y-temp.y<0.05){//enemy is close to end of path
					outofplay=true;
					killPath();
			}
        }
	}
	void killPath(){
		//stops enemy movement and places them out of camera and play area
		if(isActive)//to make sure enemy count is only decremented once
			WE.activeEnemies--;
		isActive=false;
		renderer.enabled=false;
		rigidbody.detectCollisions=false;
		//send enemy back to cache to be reanimated
		parent.recieveEnemy(this.gameObject);
	}
	void setParent(EnemyManager e){
		//sets the reference to the enemy cache
		parent=e;
	}

#endregion

}