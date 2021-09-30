using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class dronemovementscript : MonoBehaviour
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

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position/*creating a sphere at the location of the object */, groundDistance /*creating the radius of the sphere*/, groundMask /*looking for this layer mask */);
        isDead = Physics.CheckSphere(groundCheck.position, groundDistance, Deathbox); //checking if the player has fallen beneath the world


        if (isGrounded && velocity.y < 0) // resetting the players velocity when they're grounded.
        {
            velocity.y = -2f;
        }

        if (isDead) // killing the player
        {
            Destroy(FirstPlayer);
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z; //creating the direction for the player to move, based on the players local rotation, not the world.

        controller.Move(move * speed * Time.deltaTime); // moving the player

        if (Input.GetButtonDown("Jump"))  //jumping when the player touches the ground
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }
        if (Input.GetButtonUp("Jump"))  //jumping when the player touches the ground
        {
            velocity.y = 0;
        }

        if (Input.GetButtonDown("Sprint"))  //jumping when the player touches the ground
        {
            velocity.y = -Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        if (Input.GetButtonUp("Sprint"))  //jumping when the player touches the ground
        {
            velocity.y = 0;
        }


        velocity.y += gravity * Time.deltaTime; // increasing the velocity as the player falls.

        controller.Move(velocity * Time.deltaTime); // adding gravity
    }
}
