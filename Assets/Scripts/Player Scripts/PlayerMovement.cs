using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CaractherAnimation player_Anim;
    private Rigidbody myBody;

    public float walk_Speed = 2f;
    public float z_Speed = 1.5f;

    private float rotation_Y = -90f;
    private float rotation_Speed = 15f;
    
    
    void Awake(){
         
        myBody = GetComponent<Rigidbody>();
        player_Anim = GetComponentInChildren<CaractherAnimation>();
        
    }

    // Update is called once per frame
    void Update()
    {
        RotatePlayer();
        AnimatePlayerWalk();
        
    }

    void FixedUpdate()
    {
        DetectMovement();
    }

    void DetectMovement()//
    {
        myBody.velocity = new Vector3(
            Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) * (-walk_Speed),
            myBody.velocity.y,
            Input.GetAxisRaw(Axis.VERTICAL_AXIS) * (-z_Speed)); // HORIZONTAL, Y normal, VERTICAL
    }//movement 


    void RotatePlayer(){

        if(Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) > 0){ //POSITIVE SIDE 1...-90

            transform.rotation = Quaternion.Euler(0f, rotation_Y, 0f);  
        
        }else if (Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) < 0) { // NEGATIVE SIDE  -1...90

            transform.rotation = Quaternion.Euler(0f, Mathf.Abs(rotation_Y), 0f);
        }
        
    }// roatation


    void AnimatePlayerWalk(){//

        if (Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) != 0 ||
           Input.GetAxisRaw(Axis.VERTICAL_AXIS) != 0)
        {

            player_Anim.Walk(true);

        }else{
            player_Anim.Walk(false);

        }
             
        
    }// animate player walk
  
}// class

