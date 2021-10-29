using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reporter2 : MonoBehaviour
{
    //Creates needed variables
    public GameObject optButton;
    public GameObject photoOverlay;
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject subText;
    public GameObject characterName;
    public GameObject subBox;
    public GameObject ranger;
    public GameObject fireman;
    public GameObject waypoint;
    public GameObject currentWaypoint;
    public GameObject qMark3;
    public GameObject qMark4;
    public GameObject qMark5;
    public bool seePhoto = false;
    public static int droneScore = 0;
    private bool insideRange = false;
    public static bool CompletedDrone = false;

    void Update()
    {
        //Checks if inside range and interaction key is pressed
        if (insideRange && Input.GetKeyDown(KeyCode.E))
        {
            //changes inside range bool to prevent looping
            insideRange = false;
            //Checks stage in story
            if (CompletedDrone == false)
            {
                //Locks camera
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Confined;
                //Turns on dialogue ui
                subBox.SetActive(true);
                subText.GetComponent<Text>().text = "Thanks again for the help, if you could just meet Fireman Fred at the station he'll set you up with a drone";
                characterName.GetComponent<Text>().text = "Rikki";
                this.GetComponent<BoxCollider>().enabled = false;
                //Turns off object
                qMark3.SetActive(false);
                //Turns on object
                qMark4.SetActive(true);
                //Turns off action ui
                ActionDisplay.SetActive(false);
                ActionText.SetActive(false);
                //Calls exit method
                StartCoroutine(ExitConversation1());
            }
            else if(seePhoto == true)
            {
                //Locks camera
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Confined;
                //Turns on dialogue ui
                subBox.SetActive(true);
                subText.GetComponent<Text>().text = "Back again so soon? Check out the photo you took!";
                characterName.GetComponent<Text>().text = "Rikki";
                //Turns off action ui
                ActionDisplay.SetActive(false);
                ActionText.SetActive(false);
                //Turns on photo ui
                photoOverlay.SetActive(true);
                //Calls button activation method
                StartCoroutine(PhotoConversation2());

            }
            else
            {
                //Locks camera
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Confined;
                //Turns on dialogue ui
                subBox.SetActive(true);
                subText.GetComponent<Text>().text = "Wow you and Fred make a great team. Here take a look at the photo for yourself.";
                characterName.GetComponent<Text>().text = "Rikki";
                //Truns off story objects not needed anymore
                qMark3.SetActive(false);
                fireman.SetActive(false);
                currentWaypoint.SetActive(false);
                //Changes bool for story progression
                seePhoto = true;
                //Turns off action ui
                this.GetComponent<BoxCollider>().enabled = false;
                ActionDisplay.SetActive(false);
                ActionText.SetActive(false);
                //Calls photo overlay method
                StartCoroutine(PhotoConversation());
            }
        }
    }

    IEnumerator PhotoConversation()
    {
        //Waits 3.5 seconds
        //Locks camera for button movement
        GameObject.Find("FirstPersonPlayer").GetComponent<PlayerMovementScript>().enabled = false;
        GameObject.Find("Main Camera").GetComponent<MouseLook>().enabled = false;
        GameObject.Find("Canvas").GetComponent<PauseMenu>().enabled = false;
        yield return new WaitForSeconds(3.5f);
        //Turns on dialogue ui
        subBox.SetActive(false);
        subText.GetComponent<Text>().text = "";
        characterName.GetComponent<Text>().text = "";
        //Turns on photo ui
        photoOverlay.SetActive(true);
        optButton.GetComponentInChildren<Text>().text = "Close Photo";
        optButton.SetActive(true);

    }

    IEnumerator PhotoConversation2()
    {
        //Waits 4 seconds
        yield return new WaitForSeconds(4f);
        //Turns off dialogue and photo ui
        subBox.SetActive(false);
        subText.GetComponent<Text>().text = "";
        characterName.GetComponent<Text>().text = "";
        photoOverlay.SetActive(false);
    }

    IEnumerator ExitConversation1()
    {
        //Waits 4.5 seconds
        yield return new WaitForSeconds(4.5f);
        //Truns off dialogue ui
        subBox.SetActive(false);
        subText.GetComponent<Text>().text = "";
        characterName.GetComponent<Text>().text = "";
        this.GetComponent<BoxCollider>().enabled = true;
        //Unlocks camera
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void CloseButtonPressed()
    {
        //Unlocks camera
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        this.GetComponent<BoxCollider>().enabled = true;
        //Unlocks camera for button press
        GameObject.Find("FirstPersonPlayer").GetComponent<PlayerMovementScript>().enabled = true;
        GameObject.Find("Main Camera").GetComponent<MouseLook>().enabled = true;
        GameObject.Find("Canvas").GetComponent<PauseMenu>().enabled = true;
        //Turns off phot overlay
        photoOverlay.SetActive(false);
        optButton.SetActive(false);
        subBox.SetActive(true);
        //Turns on dialogue ui
        subText.GetComponent<Text>().text = "Thanks so much for your help mate! Go find Ranger Sam, I'm sure he has some further learning for you!";
        characterName.GetComponent<Text>().text = "Rikki";
        StartCoroutine(ExitConversation2());

    }

    IEnumerator ExitConversation2()
    {
        //Waits 4.5 seconds
        yield return new WaitForSeconds(4.5f);
        //Turns on required story objects
        ranger.SetActive(true);
        waypoint.SetActive(true);
        qMark5.SetActive(true);
        //Turns off dialogue ui
        subText.GetComponent<Text>().text = "";
        characterName.GetComponent<Text>().text = "";
        subBox.SetActive(false);
        this.GetComponent<BoxCollider>().enabled = true;
        //unlocks camera
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    //Brings up ui and changes insideRange bool to true when entity is detected in range
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hit detected");
        if (other.CompareTag("Player")) insideRange = true;
        ActionText.GetComponent<Text>().text = "Press [E] to Interact";
        ActionText.SetActive(true);
    }

    //Removes ui and changes bool to false on exit of range
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) insideRange = false;
        ActionText.SetActive(false);
    }
}
