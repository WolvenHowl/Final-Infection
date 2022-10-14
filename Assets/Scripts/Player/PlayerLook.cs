using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    //PlayerLook variables
    [SerializeField] private float playerLookSpeed = 400;
    [SerializeField] private float xRotation = 0f;
    [SerializeField] private Transform playerBody;

    void Start()
    {
        //Keeps cursor in game
        Cursor.lockState = CursorLockMode.Locked;
        playerBody = transform.parent.transform;
    }

    void Update()
    {
        //MouseLook 
        float mouseX = Input.GetAxis("Mouse X") * playerLookSpeed * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * playerLookSpeed * Time.deltaTime;

        xRotation -= mouseY;

        //Clamps max up and down look
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);

    }
}
