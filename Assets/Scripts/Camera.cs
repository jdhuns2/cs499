using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour
{
  private Vector3 mousepos;
  public RPathGen enemyPaths;
  public Sphere enemy;
    #region Functions
    // Use this for initialization
    void Start()
    {
        enemyPaths = new RPathGen();
        enemyPaths.setParent(this);
        enemyPaths.init();
        enemy.setPaths(enemyPaths);
        Vector3 a = camera.ViewportToWorldPoint(new Vector3(0, 0, 0));
        enemy.minx = a.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))//debuging function
            //this will show the bottome left and top right screen coordinates in pixels
        {
            Debug.Log(this.camera.aspect.ToString());
            Debug.Log("botleft: " + camera.ViewportToWorldPoint(new Vector3(0, 0, camera.farClipPlane)));
            Debug.Log("topright: " + camera.ViewportToWorldPoint(new Vector3(1, 1, camera.farClipPlane)));

        }


        if (Input.GetMouseButtonDown(0))
            //this will display the screen coordinates where the mouse is clicked
        {
            mousepos = Input.mousePosition;
            mousepos.z = this.camera.farClipPlane;
            Debug.Log(this.camera.ScreenToWorldPoint(mousepos));
            Debug.Log(mousepos.x + " " + mousepos.y + " " + mousepos.z);
        }
    }

    #endregion
}