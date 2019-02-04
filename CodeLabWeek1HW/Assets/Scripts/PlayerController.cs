using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //set player control variables
    public KeyCode upKey;
    public KeyCode downKey;
    public KeyCode rightKey;
    public KeyCode leftKey;

    //public int score = 0;

    public float forceAmount = 0.5f;
    
    //create a reference to RigidBody
    Rigidbody2D rb; 
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //set the rigidbody
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newForce = new Vector2(0,0); // the force we are adding to our player
        
        //checking to see what key is pressed
        if (Input.GetKey(upKey))
        {
            newForce.y += forceAmount;
        }

        if (Input.GetKey(downKey))
        {
            newForce.y -= forceAmount;
        }

        if (Input.GetKey(rightKey))
        {
            newForce.x += forceAmount;
        }

        if (Input.GetKey(leftKey))
        {
            newForce.x -= forceAmount;
        }
        
        //apply the new force into the RigidBody
        rb.AddForce(newForce);
    }
}
