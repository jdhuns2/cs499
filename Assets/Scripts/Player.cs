using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 

{
    public float PlayerSpeed;
    public Camera cam;
    private float maxY, minY;//determine play area independent of camera position


    void Start()
    {
        //change start position of player
        Vector3 pos;
        pos = cam.camera.ViewportToWorldPoint(new Vector3(0,0.5f,cam.camera.farClipPlane));
        transform.position = pos;
        PlayerSpeed = 7.0f;
        pos = cam.camera.ViewportToWorldPoint(new Vector3(1,1,cam.camera.farClipPlane));
        maxY = pos.y;
        pos = cam.camera.ViewportToWorldPoint(new Vector3(0, 0, cam.camera.farClipPlane));
        minY = pos.y;
    }
    // Update is called once per frame
    void Update()
    {
        //amount to move

        float amtToMove = Input.GetAxisRaw("Vertical") * PlayerSpeed*Time.deltaTime;

        //float amtToMove = Input.GetAxisRaw("Vertical") * PlayerSpeed * Time.deltaTime;

        //move player
        transform.Translate(Vector3.up * amtToMove);
        //player wrap
        if (transform.position.y <= minY)
            transform.position = new Vector3(transform.position.x, maxY, transform.position.z);
        else if (transform.position.y > maxY)
            transform.position = new Vector3(transform.position.x, minY, transform.position.z);
        if (Input.GetKeyDown("space"))
        {
			this.gameObject.SendMessage("fire");
        }
    }
}
