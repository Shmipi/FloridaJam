using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwnPlayerMovement2 : MonoBehaviour
{
    public float speed = 1f;
    public float jumpForce = 10f;

    public Rigidbody rb;
    public Vector3 movement;
    //public float gravity;

    public float maxVelocity = 10f;
 
 
    // Use this for initialization
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }
 
    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.magnitude >= maxVelocity) return;
        float horInput = Input.GetAxis("Horizontal");
        float vertInput = Input.GetAxis("Vertical");
        if (horInput != 0 || vertInput != 0)
        {
            movement = new Vector3(horInput, rb.velocity.y ,vertInput).normalized;
            //movement = new Vector3(horInput, -rb.mass*gravity ,vertInput).normalized;
        }
        
        if(Input.GetKey(KeyCode.W)) rb.AddForce(speed * transform.forward);
        if(Input.GetKey(KeyCode.S)) rb.AddForce(speed * -transform.forward);
        if(Input.GetKey(KeyCode.A)) rb.AddForce(speed * -transform.right);
        if(Input.GetKey(KeyCode.D)) rb.AddForce(speed * transform.right);
        if(Input.GetKey(KeyCode.Space)) rb.AddForce(jumpForce *transform.up);
    }
 
 
    void FixedUpdate()
    {

        moveCharacter(movement);
    }
 
 
    void moveCharacter(Vector3 direction)
    {
        rb.velocity = direction * speed;
    }
}
