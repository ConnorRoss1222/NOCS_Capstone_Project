using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

//edit,project settings, input -- shows pre labelled inputs
public class MouseLook : MonoBehaviour
{

    //Camera Settings
    public GameObject PlayerCamera;

    public GameObject textbox;

    //mouse Sensitivity
    public float MouseSensitivity = 100f;
    public Transform playerBody;
    float xRotation = 180f;

    bool currentlyTalking;

    // Start is called before the first frame update
    void Start()
    {
        //lock the cursor to the center of the screen and hide it.
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame

    void Update()
    {
       
        currentlyTalking = textbox.activeSelf;
        float mouseX = Input.GetAxis("Mouse X") * MouseSensitivity * Time.deltaTime;  //making sure the player isn't moving faster if the frame rate is slower 
        float mouseY = Input.GetAxis("Mouse Y") * MouseSensitivity * Time.deltaTime;

        if (!currentlyTalking)
        {
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f); //Stops the player from looking beyond the body.

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);
            //need to rotate around the x axis and along the y
            PlayerCamera.SetActive(true);
        }
        
       
       
    }
}
