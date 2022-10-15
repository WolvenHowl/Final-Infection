using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //PlayerMovement variables
    [SerializeField] private CharacterController playerController;
    [SerializeField] private float playerMovementSpeed = 4;

    //Gravity
    [SerializeField] private Vector3 playerVelocity;
    [SerializeField] private float playerGravity = -9.81f;

    //Jump
    [SerializeField] private float playerJumpHeight = 3f;


    void Start()
    {
        playerController = gameObject.GetComponent<CharacterController>();
    }

    void Update()
    {
        //PlayerMovement
        float xMovement = Input.GetAxis("Horizontal");
        float zMovement = Input.GetAxis("Vertical");

        Vector3 move = transform.right * xMovement + transform.forward * zMovement;

        playerController.Move(move * playerMovementSpeed * Time.deltaTime);

        //Gravity
        playerVelocity.y += playerGravity * Time.deltaTime;
        playerController.Move(playerVelocity * Time.deltaTime);

        if(playerController.isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f;
        }

        //Jump
        if(Input.GetButtonDown("Jump") && playerController.isGrounded)
        {
            playerVelocity.y  = Mathf.Sqrt(playerJumpHeight -2f * playerGravity);
        }
    }
}
