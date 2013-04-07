using UnityEngine;
using System.Collections;

public class GetPath : MonoBehaviour
{
    Vector3[] b;
  //  public static RPathGen pths;
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
		waveNum = 0;
		
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
		ptime=0.0f;
		iTween.MoveTo (gameObject,b[0],0.0f);
		iTween.PutOnPath (this.gameObject,b,0.0f);
		isActive=true;
		outofplay=false;
	}
	public void createPath(int min,int max){
		//gets a random path and activates the enemy
		//give path required amount of nodes
		if(path.nodes.Count<RPathGen.NUMNODES){
			for(int i = path.nodes.Count; i <NUMNODES; i++)
				path.nodes.Add(new Vector3());
		}//end if
		//get the name for dictionary (it's the Key)
		b = iTweenPath.GetPath(path.pathName);
		//use NUMNODES-1 so that last node can move enemy out of play area via z axis
		PM.createPath (min,max,b,R,NUMNODES);
		for (int j = 0; j < NUMNODES; j++)
                {//convert to world points
                    temp = cam1.camera.ViewportToWorldPoint(new Vector3(b[j].x, b[j].y, cam1.camera.farClipPlane));
                    b[j].x = temp.x;
                    b[j].y = temp.y;
                    b[j].z = temp.z;
                }
	}
	public void setPath(int min,int max){
		//gets a random path and activates the enemy
		//give path required amount of nodes
		if(path.nodes.Count<RPathGen.NUMNODES){
			for(int i = path.nodes.Count; i < RPathGen.NUMNODES; i++)
				path.nodes.Add(new Vector3());
		}//end if
		//get the name for dictionary (it's the Key)
		b = iTweenPath.GetPath(path.pathName);
		    int p = Random.Range(min, max);
            for (int i = 0; i < RPathGen.NUMNODES; i++)
            {
            //    temp = pths.getNode(p, i);
                b[i].x = temp.x;
                b[i].y = temp.y;
                b[i].z = temp.z;
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
			ptime+=Time.deltaTime;
            iTween.MoveTo(gameObject, iTween.Hash("easetype",iTween.EaseType.linear,"path", b, "time", 15));
			if(ptime>14.0)
				if(gameObject.transform.position.x-temp.x<0.05&&gameObject.transform.position.y-temp.y<0.05){//enemy is close to end of path
					outofplay=true;
					killPath();
			}
        }

		if(Input.GetKeyDown ("k")){
			killPath ();
			
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
		parent=e;
	}

#endregion

}