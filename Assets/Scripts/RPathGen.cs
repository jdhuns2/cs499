using UnityEngine;
using System.Collections;

public class RPathGen : MonoBehaviour
{
	
    public Camera cam1;
    public ArrayList paths;
    public const int NUMPATHS = 10;
    public const int NUMNODES = 10;
	float R = .18f;//max distance between path nodes
    public Vector3[] a;
    #region Functions
	
    public void init()
    //void Start()
	{
    	paths = new ArrayList();
    	//genPaths();    
    }
    public Vector3 getNode(int p, int i)
    {
        a = new Vector3[NUMNODES];
        a = (Vector3[])paths[p];
        return a[i];
    }
   public void setParent(Camera c)
    {
        cam1 = c;
    }
    public void genPaths()
    {
        Vector3 temp;
        //a = new Vector3[NUMNODES];
        for (int i = 0; i < NUMPATHS; i++)
        {//random starting position outside of camera view
            a = new Vector3[NUMNODES];
            a[0].z = 0;
            a[0].y = Random.Range(0.0f,1.0f);
            a[0].x = 1.2f;
            for (int j = 1; j < NUMNODES-1; j++)
            {//get random angle in radians
				float theta = Random.Range (3*Mathf.PI/4,5*Mathf.PI/4);
				//float theta = Mathf.PI;
				//next point calculation based on semicircle for equidistant points
				a[j].x = a[j-1].x + R*Mathf.Cos (theta);
				a[j].y = a[j-1].y + R*Mathf.Sin (theta);
                a[j].z = 0;//can we remove this?

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
            paths.Add(a);
        }
    }
    public void drawPaths(int i)
    {
    Vector3 f = getNode(i,0);
    Debug.Log(f.x);
    Debug.Log(f.y);

    }

    #endregion
}