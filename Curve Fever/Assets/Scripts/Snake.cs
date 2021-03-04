using UnityEngine;
using System.Collections.Generic;

public class Snake : MonoBehaviour
{
     //to move snake always we are declaring a variable in forward direction on at speed with a variable
     public float speed=3f; 

     //the ability to rotate the snake with another variable
     public float rotationSpeed =200f;

     //for creating another control
     public string inputAxis ="Horizontal";

     //here we have assign the value as 0 means movemnt  left and 1 to the right
    float horizontal =0f; 
    
    void Update()
    {
        //raw is used because we really don't need any smoothing on this movement
       horizontal= Input.GetAxisRaw(inputAxis);
    }
      void FixedUpdate()
    {
        //this is used to move our snake forward
        //translate allows us to move gow far we want to move on the XY and Z and in
        //vector2.up is because we want to move in upward direction
        //fixed deltaTime helps in mak eit independent on the rate of our fixed update
        //space self is used to make this movemnet to be local and not on the world 
        transform.Translate(Vector2.up * speed *Time.fixedDeltaTime,Space.Self); 

        //horizontal will help us in rotation by vector 3

        // if we want to reverse the controls just set (-)minus before horizontal
        transform.Rotate(Vector3.forward * - horizontal *rotationSpeed* Time.fixedDeltaTime);

    }

    //this collider is used to show what object we have hit
     void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag =="killsPlayer")
        {
            speed=0f;
            rotationSpeed=0f;

            GameObject.FindObjectOfType<Game_Manager>().EndGame();
            
        }
        
    }


}