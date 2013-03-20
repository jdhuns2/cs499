using UnityEngine;
using System.Collections;

public class Sphere : MonoBehaviour
{
    Vector3[] a,b;
    public RPathGen pths;
    bool isActive;
    Vector3 temp;
    public float minx;
    public GameObject e;
    #region Functions
    // Use this for initialization
    void Start()
    {
        isActive = false;
        transform.position = new Vector3(0, 0, 0);
        b = iTweenPath.GetPath("New Path 1");
       
    }
    public void setPaths(RPathGen r)
    {
        pths = r;
    }
    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < minx)
        {
            isActive = false;
           // Debug.Log("inactive");
            
        }
        if (!isActive)
        {//choose random path
            int p = Random.Range(0, 9);//change these to max/min paths
            for (int i = 0; i < 5; i++)
            {
                temp = pths.getNode(p, i);
                b[i].x = temp.x;
                b[i].y = temp.y;
                b[i].z = temp.z;
            }
            isActive = true;
            iTween.PutOnPath(e, b, 0.0f);
        }
        else
        {
            iTween.MoveTo(gameObject, iTween.Hash("path", b, "time", 5));
        }
    }
    #endregion
}