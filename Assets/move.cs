
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public CharacterController controller;

    public float player_speed = 5f; 
   
    public float player_jumpSpeed = 3.5f;
  
    public float player_gravity = -9.18f;
    
    bool jump = false;

    Vector3 velocity;
   

    void Update()
    {
        if (controller.isGrounded && velocity.y < 0)
        
        {
            velocity.y = 0f;
            
        }

        float x = Input.GetAxis("Horizontal");
        
        float z = Input.GetAxis("Vertical");
        

        Vector3 move = transform.right * x + transform.forward * z;

        if (controller.isGrounded)
        {
            if (Input.GetButton("Jump"))
            {
                if (jump == true)
                {
                    velocity.y = 15f;
                    jump = false;
                }
                else 
                {
                     velocity.y = player_jumpSpeed;
                }
            }
        }

        controller.Move(move * player_speed * Time.deltaTime);
        velocity.y += player_gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("jump"))
        {
            jump = true;
        }
    }
}