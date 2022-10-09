using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


//TODO https://www.google.com/search?q=physics+movement+with+3rd+person+camera+unity&oq=physics+movement+with+3rd+person+camera+unity&aqs=edge..69i57j0i546j69i64.9952j0j4&sourceid=chrome&ie=UTF-8
public class OwnPlayerMovement : MonoBehaviour
{
    private Rigidbody rb;

    private Vector3 inputVector;
    private Vector2 mouseInput;

    [SerializeField] private float moveSpeed, sensitivity, jumpForce;

    [SerializeField]private Collider coll;

    private GameObject cameraObject;
    private Camera mainCamera;

    private float xRot;

    private Transform feetTransform;

    [SerializeField] private LayerMask floorMask;
    
    
    void Start()
    {
        feetTransform = GameObject.FindGameObjectWithTag("feet").transform;
        if (moveSpeed == 0) moveSpeed = 0.5f;
        rb = GetComponent<Rigidbody>();
        cameraObject = GameObject.FindGameObjectWithTag("MainCamera");
        mainCamera = cameraObject.GetComponent<Camera>();
        distance = cameraObject.GetComponent<CameraController>().GetDistance();
    }

    // Update is called once per frame
    void Update()
    {
        float horInput = Input.GetAxis("Horizontal");
        float vertInput = Input.GetAxis("Vertical");


        if (horInput != 0 && vertInput != 0)
        {
            
            inputVector = new Vector3(horInput * moveSpeed, rb.velocity.y,vertInput *moveSpeed);
            mouseInput = new Vector2(Input.GetAxis("Mouse X")*sensitivity, Input.GetAxis("Mouse Y")*sensitivity);
            MovePlayer();

        }
    }

    private void FixedUpdate()
    {
        rb.velocity = inputVector;

    }

    private float distance;
    private void MovePlayer()
    {
        Vector3 moveVector = transform.TransformDirection(inputVector)*moveSpeed;
        
        
        rb.velocity = new Vector3(moveVector.x , 0, moveVector.z);
        rb.rotation = Quaternion.Euler(0,cameraObject.transform.rotation.y, 0);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Physics.CheckSphere(feetTransform.position, 0.1f, floorMask))
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
            
        }
    }
    
}
