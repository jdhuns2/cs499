using UnityEngine;
using System.Collections;

public class GameCamera : MonoBehaviour
{
  private Vector3 mousepos;
    #region Functions
    // Use this for initialization
    void Start()
    {
 
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