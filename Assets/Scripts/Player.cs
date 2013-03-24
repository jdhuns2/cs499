using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 

{
    public float PlayerSpeed;
 
    // Use this for initialization
    void Start()
    {
        //change start position of player
        transform.position = new Vector3(1, 1,0);
        PlayerSpeed = 2.0f;
    }
    // Update is called once per frame
    void Update()
    {
        //amount to move
        float amtToMove = Input.GetAxisRaw("Vertical") * PlayerSpeed*Time.deltaTime;
        //move player
        transform.Translate(Vector3.up * amtToMove);     
        //player wrap
        if (transform.position.y <= -0.5f)
            transform.position = new Vector3(transform.position.x, 10.8f,transform.position.z);
        else if (transform.position.y > 10.9f)
            transform.position = new Vector3(transform.position.x, -0.4f, transform.position.z);
        if (Input.GetKeyDown("space"))
        {
            
            
        }
    }
}
