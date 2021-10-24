using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovementScript : MonoBehaviour
{

    public CharacterController controller;

    public float speed = 20f;
    public float gravity = -19.62f;
    public float jumpHeight = 3f;
    public float sprint = 40f;
 
    public GameObject FirstPlayer;

    public Transform groundCheck;
    public float groundDistance = 0.2f;  //creating the ground check distance
    public LayerMask groundMask; //the name of the mask that will identify as ground.
    public LayerMask Deathbox;

    Vector3 velocity;
    bool isGrounded;
    bool isDead;
    bool currentlyTalking;


    public GameObject textbox;
    public GameObject runningSound;

    private void Start()
    {
        speed = 20f;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) && !currentlyTalking)
        {
            runningSound.SetActive(true);
        }
        else 
        {
            runningSound.SetActive(false);
        }

            isGrounded = Physics.CheckSphere(groundCheck.position/*creating a sphere at the location of the object */, groundDistance /*creating the radius of the sphere*/, groundMask /*looking for this layer mask */);
        isDead = Physics.CheckSphere(groundCheck.position, groundDistance, Deathbox); //checking if the player has fallen beneath the world

        currentlyTalking = textbox.activeSelf;

        if(isGrounded && velocity.y < 0) //&& !currentlyTalking) // resetting the players velocity when they're grounded.
        {
            velocity.y = -2f;
        }

        if (isDead) // killing the player
        {
            Destroy(FirstPlayer); 
            SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (!currentlyTalking)
        {
            Vector3 move = transform.right * x + transform.forward * z; //creating the direction for the player to move, based on the players local rotation, not the world.

            controller.Move(move * speed * Time.deltaTime); // moving the player
        }
        
        

        if(Input.GetButtonDown("Jump") && isGrounded && !currentlyTalking)  //jumping when the player touches the ground
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity); 
        }

        if (Input.GetButton("Sprint") && isGrounded && !currentlyTalking) //toggling the sprint on
        {
            speed = 40f; 
        }
        if (Input.GetButtonUp("Sprint") && isGrounded && !currentlyTalking) // toggling the sptin off
        {
            speed = 20f;
        }

        velocity.y += gravity * Time.deltaTime; // increasing the velocity as the player falls.

        controller.Move(velocity * Time.deltaTime); // adding gravity
    }
}
