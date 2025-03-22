using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;

    public float moveSpeed = 10f;

    public bool isPaddle1;

    private float movement;
    public Transform ball;
    public float paddleSpeed = 5f;
    public float SetActiveTimer = 0f;

    void Update()
    {
        
        if (isPaddle1)
        {
            movement = Input.GetAxisRaw("Vertical");
 
        }
        else
        {
            if(OpenPong.is1Player == false)
            {
                movement = Input.GetAxisRaw("Vertical2");
            }
            if(OpenPong.is1Player == true)
            {
                Vector3 targetPosition = new Vector3(transform.position.x, ball.position.y, transform.position.z);
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, paddleSpeed * Time.deltaTime);
            }
            
        }

        rb.velocity = new Vector2(rb.velocity.x, movement*moveSpeed);

        if (PowerDownScript.startTimer)
        {
            this.GetComponent<Collider2D>().enabled = false;
            this.GetComponent<Renderer>().material.color = Color.black;
            
            SetActiveTimer += Time.deltaTime;
            
            if (SetActiveTimer >= 10f)
            {
                this.GetComponent<Collider2D>().enabled = true;
                this.GetComponent<Renderer>().material.color = Color.white;
                PowerDownScript.startTimer = false;
            }
        }
    }
    
    
}
