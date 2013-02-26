using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour
{
  private Vector3 mousepos;
  
    #region Functions
    // Use this for initialization
    void Start()
    {// initial position for the camera. On my computer this results in (0,0,0) being the bottom left coordinate
        //with the play area being in the +x, +y plane.  Since this depends on the screen aspect ratio there is case
        //statement and if statement to check for repeating decimals ratios
        switch (camera.aspect.ToString())
        {case "1.25":
                transform.position = new Vector3(6.55f, 5.2f, -10);
                break;
            case "1.5":
                transform.position = new Vector3(7.85f, 5.2f, -10);
                break;
            case "1.6":
                transform.position = new Vector3(8.35f, 5.2f, -10);
                break;
        }
        if (camera.aspect > 1.30 && camera.aspect < 1.34)
        {
            transform.position = new Vector3(6.95f, 5.2f, -10);
        }
        if (camera.aspect > 1.70 && camera.aspect < 1.79)
        {
            transform.position = new Vector3(9.25f, 5.2f, -10);
        }

        //transform.position = new Vector3(10.65f, 5.2f, -10);
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