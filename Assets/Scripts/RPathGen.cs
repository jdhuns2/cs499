using UnityEngine;
using System.Collections;

public class RPathGen : MonoBehaviour
{
	
    public Camera cam1;
    public ArrayList paths;
    public const int NUMPATHS = 50;
    public const int NUMNODES = 5;
	public PathManager pathMGR;
	float R = .35f;//max distance between path nodes
    public Vector3[] a;
	public bool doneGenerating;
	private int m_min, m_max;//area of array list to re-create
    #region Functions
	
    public void init()
	{
    	paths = new ArrayList();
		GameObject go = (GameObject)GameObject.FindGameObjectWithTag("ObjectManager");
		pathMGR=(PathManager)go.GetComponent("PathManager");
		doneGenerating=false;
		m_min = 0;
		m_max = NUMPATHS;
    }
    public Vector3 getNode(int p, int i)
    {
		//returns a Vector3 containing the requested node
        a = new Vector3[NUMNODES];
        a = (Vector3[])paths[p];
        return a[i];
    }
	public void genPathsRange(int min, int max){
		doneGenerating=false;
		m_min = min;
		m_max = max;
		//StartCoroutine (genPaths());
		genPaths ();
	}
    //private IEnumerator genPaths()
	private void genPaths()
    {
        Vector3 temp;
		for (int i=m_min;i<=m_max;i++){
			a = new Vector3[NUMNODES];
			pathMGR.createPath (1,1,a,R,NUMNODES);
			//convert newly created path from camera to world coordinates
			for (int j = 0; j < NUMNODES; j++){
                    temp = cam1.camera.ViewportToWorldPoint(new Vector3(a[j].x, a[j].y, cam1.camera.farClipPlane));
                    a[j].x = temp.x;
                    a[j].y = temp.y;
                    a[j].z = temp.z;
                }
			if(paths.Count<i)//overwrite path if it exists
            	paths[i] = a;
			else
				paths.Add (a);
		}
		doneGenerating=true;
		//yield return null;
    }
    #endregion
}
/*old code
 *         //a = new Vector3[NUMNODES];
        for (int i = 0; i < NUMPATHS; i++)
        {//random starting position outside of camera view
            a = new Vector3[NUMNODES];
            a[0].y = Random.Range(0.0f,1.0f);
            a[0].x = 1.2f;
            for (int j = 1; j < NUMNODES-1; j++)
            {//get random angle in radians
				float theta = Random.Range (3*Mathf.PI/4,5*Mathf.PI/4);
				//float theta = Mathf.PI;
				//next point calculation based on semicircle for equidistant points
				a[j].x = a[j-1].x + R*Mathf.Cos (theta);
				a[j].y = a[j-1].y + R*Mathf.Sin (theta);
              	//z value not needed for just 2 dimenions

            }
                a[NUMNODES-1].z = 0;
                a[NUMNODES-1].y = Random.Range(0.0f,1.0f);
                a[NUMNODES-1].x = -0.2f;

                for (int j = 0; j < NUMNODES; j++)
                {//convert to world points
                    temp = cam1.camera.ViewportToWorldPoint(new Vector3(a[j].x, a[j].y, cam1.camera.farClipPlane));
                    a[j].x = temp.x;
                    a[j].y = temp.y;
                    a[j].z = temp.z;
                }
			if(paths.Count<i)//overwrite path if it exists
            	paths[i] = a;
			else
				paths.Add (a);*/