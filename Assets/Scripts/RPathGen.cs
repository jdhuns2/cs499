using UnityEngine;
using System.Collections;

public class RPathGen : MonoBehaviour
{
	
    public Camera cam1;
    public ArrayList paths;
    public const int NUMPATHS = 10;
    public const int NUMNODES = 6;
	float R = .35f;//max distance between path nodes
    public Vector3[] a;
	public bool doneGenerating;
	private PathManager pathMGR;
	private int m_min, m_max;
    #region Functions
	
    public void init()
	{
		GameObject go = (GameObject)GameObject.FindGameObjectWithTag("WaveGen");
		pathMGR = (PathManager)go.GetComponent("PathManager");
    	paths = new ArrayList();
		doneGenerating=false;
		m_min = 0;
		m_max = NUMPATHS;
		pathMGR.init ();
    }
    public Vector3 getNode(int p, int i)
    {//used in GetPath to overwrite default itween path
		//returns a Vector3 containing the requested node
        a = new Vector3[NUMNODES];
        a = (Vector3[])paths[p];
        return a[i];
    }
//	public void genPathsRange(int min, int max){
//		doneGenerating=false;
//		m_min = min;
//		m_max = max;
//		genPaths (m_min, m_max);
		//StartCoroutine (genPaths(m_min,m_max));
//	}
    //private IEnumerator genPaths()
	public void genPaths(int min, int max)
    {
        Vector3 temp;
		for (int i= min;i<max;i++){
			a = new Vector3[NUMNODES];
			//use NUMNODES-1 so that last node can move enemy out of play area via z axis
			pathMGR.createPath (1,1,a,R,NUMNODES);
			for (int j = 0; j < NUMNODES; j++)
                {//convert to world points
                    temp = cam1.camera.ViewportToWorldPoint(new Vector3(a[j].x, a[j].y, cam1.camera.farClipPlane));
                    a[j].x = temp.x;
                    a[j].y = temp.y;
                    a[j].z = temp.z;
                }
			//a[NUMNODES-1].x = a[NUMNODES-2].x;
			//a[NUMNODES-1].y = a[NUMNODES-2].y;
			//a[NUMNODES-1].z = a[NUMNODES-2].z-1;
			if(paths.Count<i)//overwrite path if it exists
            	paths[i] = a;
			else
				paths.Add (a);
        
		doneGenerating=true;
		//yield return null;
    }
    #endregion
	}
}
