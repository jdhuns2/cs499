using UnityEngine;
using System.Collections;

public class RPathGen : MonoBehaviour
{

    public Camera cam1;
    public ArrayList paths;
    const int NUMPATHS = 50;
    const int NUMNODES = 5;
    public Vector3[] a;
    #region Functions
    // Use this for initialization
    void Start()
    {

    }
    public void init()
    {
    paths = new ArrayList();
    genPaths();    
    }

    // Update is called once per frame
    void Update()
    {

    }
    public Vector3 getNode(int p, int i)
    {
        a = new Vector3[NUMNODES];
        a = (Vector3[])paths[p];
        return a[i];
        //return new Vector3(1, 1, 1);
    }
   public void setParent(Camera c)
    {
        cam1 = c;
    }
    public void genPaths()
    {
        Vector3 temp;
        a = new Vector3[NUMNODES];
        for (int i = 0; i < NUMPATHS; i++)
        {
            a = new Vector3[NUMNODES];
            a[0].z = 0;
            a[0].y = Random.Range(0.0f,1.0f);
            a[0].x = 1.2f;
            for (int j = 1; j < NUMNODES-1; j++)
            {
                a[j].z = 0;//can we remove this?
                a[j].y = Random.Range(0, 1);//generate next point based on current point
                a[j].x = Random.Range(a[j - 1].x + Random.Range(0.05f, 0.15f), 0.25f);
            }
                a[NUMNODES-1].z = 0;
                a[NUMNODES-1].y = Random.Range(0.0f,1.0f);
                a[NUMNODES-1].x = -0.2f;

                for (int j = 0; j < NUMNODES; j++)
                {
                    temp = cam1.camera.ViewportToWorldPoint(new Vector3(a[j].x, a[j].y, cam1.camera.farClipPlane));
                    a[j].x = temp.x;
                    a[j].y = temp.y;
                    a[j].z = temp.z;
                }
            paths.Add(a);
        }
    }
 

    #endregion
}