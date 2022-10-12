using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class SimpleMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float jumpSpeed = 0.5f;
    [SerializeField] private float gravity = 2f;
    private CharacterController controller;
    private bool isGrounded;

    private Vector3 moveDirection;
    private Transform camera;
    private float rotate;
    public float rotationSpeed = 75f;
    private bool jumped => controller.isGrounded && Input.GetKey(KeyCode.Space);

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        camera = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");


        Vector3 inputDirection = new Vector3(horizontal, 0, vertical);
        Vector3 transformDirection = transform.TransformDirection(inputDirection);

        Vector3 flatMovement = moveSpeed * Time.fixedDeltaTime * transformDirection;

        moveDirection = new Vector3(flatMovement.x, moveDirection.y, flatMovement.z);

        if (jumped)
        {
            moveDirection.y = jumpSpeed;
        }
        else
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        controller.Move(moveDirection);

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            transform.Rotate(Vector3.up * rotate );
        }

        if (moveDirection != Vector3.zero)
        {
            transform.forward = new Vector3(camera.forward.x, 0, camera.forward.z);
        }

    }

}
