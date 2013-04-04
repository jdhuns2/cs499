using UnityEngine;
using System.Collections;

public class GetPath : MonoBehaviour
{
    Vector3[] a,b;
    public static RPathGen pths;
	public static WaveEmitter WE;
    public bool isActive,outofplay;
	public int waveNum;
    Vector3 temp;
    public static float minx;
	public iTweenPath path;
	private EnemyManager parent;
    #region Functions
    // Use this for initialization
	void init(){
	    isActive = false;
		outofplay = false;
		waveNum = 0;
		//gets available paths
		GameObject go = (GameObject)GameObject.FindGameObjectWithTag("WaveGen");
		WE = (WaveEmitter)go.GetComponent ("WaveEmitter");
		pths = (RPathGen)go.GetComponent("RPathGen");
		
		//add iTween component and get ref
		gameObject.AddComponent("iTweenPath");
		path = (iTweenPath)gameObject.GetComponent("iTweenPath");
		//setPath (0,9);
	}
	public void startPath(){
		//puts the enemy back at beginning of path
		transform.Translate (b[0]);
		iTween.PutOnPath (this.gameObject,b,0.0f);
		isActive=true;
	}
	public void setPath(int min,int max){
		//gets a random path and activates the enemy
		//give path required amount of nodes
		if(path.nodes.Count<RPathGen.NUMNODES){
			for(int i = path.nodes.Count; i < RPathGen.NUMNODES; i++)
			{
				path.nodes.Add(new Vector3());
			}
		}
		//get the name for dictionary (it's the Key)
		b = iTweenPath.GetPath(path.pathName);
		    int p = Random.Range(min, max);
            for (int i = 0; i < RPathGen.NUMNODES; i++)
            {
                temp = pths.getNode(p, i);
                b[i].x = temp.x;
                b[i].y = temp.y;
                b[i].z = temp.z;
            }
            //isActive = true;
            //iTween.PutOnPath(this.gameObject, b, 0.0f);
		//renderer.enabled=true;
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
		
            iTween.MoveTo(gameObject, iTween.Hash("easetype",iTween.EaseType.easeInSine,"path", b, "time", 15));
			if(gameObject.transform.position.z>-2){//enemy is out of play
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
		//send enemy back to cache to be reanimated
		parent.recieveEnemy(this.gameObject);
	}
	void setParent(EnemyManager e){
		parent=e;
	}

#endregion

}