using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LibrarianNPC : MonoBehaviour
{
    //Creates needed variables
    public GameObject ReporterOn;
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject subText;
    public GameObject characterName;
    public GameObject subBox;
    public GameObject bookOverlay;
    public GameObject notifications;
    public GameObject book1;
    public GameObject book2;
    public GameObject book3;
    public GameObject book4;
    public GameObject qMark1;
    public static bool statePickupBook = false;
    public static bool statePossum = false;
    private bool stateBirdConversation = false;
    private bool stateBookConversation = false;
    private bool insideRange = false;
    public GameObject optButton;
    public int firsttime = 1;


    void Update()
    {
        //Checks if inside range and interaction key is pressed
        if (insideRange && Input.GetKeyDown(KeyCode.E))
        {
            //Turns inside range to false to prevent loop
            insideRange = false;

            //Check what stage of minigame player is at
            if (LibrarianNPC.statePossum == false && LibrarianNPC.statePickupBook == false)
            {
                //Locks Camera
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Confined;
                //Turns on dialogue ui
                subBox.SetActive(true);
                subText.GetComponent<Text>().text = "I want to talk but that bird is really freaking me out!";
                characterName.GetComponent<Text>().text = "Lilly";
                this.GetComponent<BoxCollider>().enabled = false;
                //Turns of action ui
                ActionDisplay.SetActive(false);
                ActionText.SetActive(false);
                //Calls exit conversation method
                StartCoroutine(ExitConversation());
            }
            else if (LibrarianNPC.statePossum == true && LibrarianNPC.statePickupBook == false)
            {
                //Checks if this is the first time the player has talked to the librarian after picking up the bird
                if (stateBirdConversation == false)
                {
                    //Locks Camera
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.Confined;
                    //Turns on dialogue ui
                    subBox.SetActive(true);
                    subText.GetComponent<Text>().text = "Thank you very much for lending a helping hand there! The whole ecosystem has been going crazy since the bushland was destroyed.";
                    characterName.GetComponent<Text>().text = "Lilly";
                    this.GetComponent<BoxCollider>().enabled = false;
                    //Turns of action ui
                    ActionDisplay.SetActive(false);
                    ActionText.SetActive(false);
                    //Continues Conversation
                    StartCoroutine(FoundPossumConversation1());
                    
                }
                else
                {
                    //Locks Camera
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.Confined;
                    //Turns on dialogue ui
                    subBox.SetActive(true);
                    subText.GetComponent<Text>().text = "I'm sorry to be like this but I cannot help you learn until you find that book.";
                    characterName.GetComponent<Text>().text = "Lilly";
                    this.GetComponent<BoxCollider>().enabled = false;
                    //Turns of action ui
                    ActionDisplay.SetActive(false);
                    ActionText.SetActive(false);
                    //Calls exit conversation method
                    StartCoroutine(ExitConversation());
                }
            }
            else if (LibrarianNPC.statePossum == true && LibrarianNPC.statePickupBook == true)
            {
                //Checks if this is the first time the player has talked to the librarian after picking up the right book
                if (stateBookConversation == false)
                {
                    //Locks Camera
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.Confined;
                    //Turns on dialogue ui
                    subBox.SetActive(true);
                    subText.GetComponent<Text>().text = "Oh great you found it! Let's give it a read.";
                    characterName.GetComponent<Text>().text = "Lilly";
                    this.GetComponent<BoxCollider>().enabled = false;
                    //Turns of action ui
                    ActionDisplay.SetActive(false);
                    ActionText.SetActive(false);
                    //Calls book conversation
                    StartCoroutine(FoundBookConversation());
                    //Turns off question mark object
                    qMark1.SetActive(false);
                    //Sets stateBookConversation to true
                    stateBookConversation = true;
                    //Turns on Reporter object
                    ReporterOn.SetActive(true);

                }
                else
                {
                    //Locks Camera
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.Confined;
                    //Turns on dialogue ui
                    subBox.SetActive(true);
                    subText.GetComponent<Text>().text = "Oh you're back, are you here to see the book again?";
                    characterName.GetComponent<Text>().text = "Lilly";
                    this.GetComponent<BoxCollider>().enabled = false;
                    //Turns of action ui
                    ActionDisplay.SetActive(false);
                    ActionText.SetActive(false);
                    //Calls book conversation
                    StartCoroutine(FoundBookConversation());
                }
            }
        }
    }

    //Brings up ui and changes insideRange bool to true when entity is detected in range
    private void OnTriggerEnter(Collider other)
    {
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


    IEnumerator FoundBookConversation()
    {
        //Locks camera for button movement
        GameObject.Find("FirstPersonPlayer").GetComponent<PlayerMovementScript>().enabled = false;
        GameObject.Find("Main Camera").GetComponent<MouseLook>().enabled = false;
        GameObject.Find("Canvas").GetComponent<PauseMenu>().enabled = false;
        //Waits 3.5 seconds
        yield return new WaitForSeconds(3.5f);
        //Truns off dialogue ui
        subBox.SetActive(false);
        subText.GetComponent<Text>().text = "";
        characterName.GetComponent<Text>().text = "";
        //Turns on book ui
        bookOverlay.SetActive(true);
        //Continues book method
        StartCoroutine(FoundBookCloseButton());

    }

    IEnumerator FoundBookCloseButton()
    {
        //Waits 10 Seconds
        yield return new WaitForSeconds(10f);
        //Turns on book button ui
        optButton.GetComponentInChildren<Text>().text = "Close Book";
        optButton.SetActive(true);
    }

    public void CloseButtonPressed()
    {
        //Unlocks camera
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        this.GetComponent<BoxCollider>().enabled = true;
        //Truns off ui
        bookOverlay.SetActive(false);
        optButton.SetActive(false);
        //Unlocks camera for button press
        GameObject.Find("FirstPersonPlayer").GetComponent<PlayerMovementScript>().enabled = true;
        GameObject.Find("Main Camera").GetComponent<MouseLook>().enabled = true;
        GameObject.Find("Canvas").GetComponent<PauseMenu>().enabled = true;
        //Calls Reporter method if this is the first time closing the book
        if (firsttime == 1)
        {
            firsttime = 0;
            ReporterInLibrary.finishedbook = 1;
        }
    }

    IEnumerator FoundPossumConversation1()
    {
        //Waits 5.5 Seconds
        yield return new WaitForSeconds(5.5f);
        //Edits Dialogue ui
        subText.GetComponent<Text>().text = "Ohh, and my name is Lilly, by the way, Lilly the Librarian. What brings you into the library today?";
        characterName.GetComponent<Text>().text = "Lilly";
        //Changes story bool to true
        stateBirdConversation = true;
        //Continues story
        StartCoroutine(FoundPossumConversation2());
    }

    IEnumerator FoundPossumConversation2()
    {
        //Waits 5.5 Seconds
        yield return new WaitForSeconds(5.5f);
        //Edits Dialogue ui
        subText.GetComponent<Text>().text = "Ohhh you’d like some information on bushfires! Have I got just the book for you, if I could just……ahhh…find it.";
        characterName.GetComponent<Text>().text = "Lilly";
        //Continues story
        StartCoroutine(FoundPossumConversation3());
    }

    IEnumerator FoundPossumConversation3()
    {
        //Waits 6 Seconds
        yield return new WaitForSeconds(6f);
        //Edits Dialogue ui
        subText.GetComponent<Text>().text = "Rats, I must’ve put it back on the shelf. Now if I remember correctly, it should be in the nonfiction section. Go find it and we can give it a read together!";
        characterName.GetComponent<Text>().text = "Lilly";
        //Activates notification ui
        notifications.GetComponent<Text>().text = "Help Lilly find the right book!";
        notifications.SetActive(true);
        //Enables book objects
        book1.GetComponent<BoxCollider>().enabled = true;
        book2.GetComponent<BoxCollider>().enabled = true;
        book3.GetComponent<BoxCollider>().enabled = true;
        book4.GetComponent<BoxCollider>().enabled = true;
        //Calls exit conversation method
        StartCoroutine(ExitConversation());
    }

   IEnumerator ExitConversation()
    {
        //Waits 5.5 Seconds
        yield return new WaitForSeconds(5.5f);
        //Turns off dialogue ui
        subBox.SetActive(false);
        subText.GetComponent<Text>().text = "";
        characterName.GetComponent<Text>().text = "";
        this.GetComponent<BoxCollider>().enabled = true;
        //Unlocks camera
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}