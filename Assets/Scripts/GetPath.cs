using UnityEngine;
using System.Collections;

public class GetPath : MonoBehaviour
{
    Vector3[] a,b;
    public RPathGen pths;
	//extern int NUMPATHS;
    public bool isActive;
    Vector3 temp;
    public float minx;
	
	public int NUMNODES = 10;
	
	iTweenPath path;
    #region Functions
    // Use this for initialization
	void setPath(){
	    isActive = false;
        transform.position = new Vector3(0, 0, 0);
		
		
		//gets available paths
		GameObject go = (GameObject)GameObject.FindGameObjectWithTag("WaveGen");
		pths = (RPathGen)go.GetComponent("RPathGen");
		
		//add iTween component and get ref
		this.gameObject.AddComponent("iTweenPath");
		path = (iTweenPath)this.gameObject.GetComponent("iTweenPath");		
       	
		//give path required amount of nodes
		for(int i = path.nodeCount; i < NUMNODES; i++)
		{
			path.nodes.Add(new Vector3());
		}
		//get the name for dictionary (it's the Key)
		b = iTweenPath.GetPath(path.pathName);
		            int p = Random.Range(0, 9);//change these to max/min paths
            for (int i = 0; i < 10; i++)//change to NUMNODES
            {
                temp = pths.getNode(p, i);
                b[i].x = temp.x;
                b[i].y = temp.y;
                b[i].z = temp.z;
            }
            isActive = true;
            iTween.PutOnPath(this.gameObject, b, 0.0f);
	}
	
    void Start()
    {
setPath();
    }
    
    // Update is called once per frame
    void Update()
    {
        //if (transform.position.x < minx)
       // {
       //     isActive = false;
           // Debug.Log("inactive");
            
     //   }
        if(isActive)
        {
			this.gameObject.renderer.enabled = true;
            iTween.MoveTo(gameObject, iTween.Hash("easetype",iTween.EaseType.linear,"path", b, "time", 15));
        }
		if(Input.GetKeyDown ("k"))
			killPath ();
    }
	void killPath(){
		iTween.Stop();
		isActive=false;
	}
    #endregion
}