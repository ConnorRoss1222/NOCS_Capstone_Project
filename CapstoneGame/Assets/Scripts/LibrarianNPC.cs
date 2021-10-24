using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LibrarianNPC : MonoBehaviour
{
    public GameObject ReporterOn;
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject subText;
    public GameObject characterName;
    public GameObject subBox;
    public GameObject bookOverlay;
    public static bool statePickupBook = false;
    public static bool statePossum = false;
    private bool statePossumConversation = false;
    private bool stateBookConversation = false;
    private bool insideRange = false;
    public GameObject optButton;


    void Update()
    {
        if (insideRange && Input.GetKeyDown(KeyCode.E))
        {
            insideRange = false;

            if (LibrarianNPC.statePossum == false && LibrarianNPC.statePickupBook == false)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Confined;
                subBox.SetActive(true);
                subText.GetComponent<Text>().text = "I want to talk but that bird is really freaking me out";
                characterName.GetComponent<Text>().text = "Liam";
                this.GetComponent<BoxCollider>().enabled = false;
                ActionDisplay.SetActive(false);
                ActionText.SetActive(false);
                StartCoroutine(ExitConversation());
            }
            else if (LibrarianNPC.statePossum == true && LibrarianNPC.statePickupBook == false)
            {
                if (statePossumConversation == false)
                {
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.Confined;
                    subBox.SetActive(true);
                    subText.GetComponent<Text>().text = "Thank you very much for lending a helping hand there! The whole ecosystem has been going crazy since the bushland was destroyed.";
                    characterName.GetComponent<Text>().text = "Liam";
                    this.GetComponent<BoxCollider>().enabled = false;
                    ActionDisplay.SetActive(false);
                    ActionText.SetActive(false);
                    StartCoroutine(FoundPossumConversation1());
                    
                }
                else
                {
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.Confined;
                    subBox.SetActive(true);
                    subText.GetComponent<Text>().text = "I'm sorry to be like this but I cannot help you learn until you find that book.";
                    characterName.GetComponent<Text>().text = "Liam";
                    this.GetComponent<BoxCollider>().enabled = false;
                    ActionDisplay.SetActive(false);
                    ActionText.SetActive(false);
                    StartCoroutine(ExitConversation());
                }
            }
            else if (LibrarianNPC.statePossum == true && LibrarianNPC.statePickupBook == true)
            {
                if (stateBookConversation == false)
                {
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.Confined;
                    subBox.SetActive(true);
                    subText.GetComponent<Text>().text = "Oh great you found it! Let's give it a read.";
                    characterName.GetComponent<Text>().text = "Liam";
                    this.GetComponent<BoxCollider>().enabled = false;
                    ActionDisplay.SetActive(false);
                    ActionText.SetActive(false);
                    StartCoroutine(FoundBookConversation());
                    stateBookConversation = true;
                    ReporterOn.SetActive(true);
                }
                else
                {
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.Confined;
                    subBox.SetActive(true);
                    subText.GetComponent<Text>().text = "Oh you're back, are you here to see the book again?";

                    this.GetComponent<BoxCollider>().enabled = false;
                    ActionDisplay.SetActive(false);
                    ActionText.SetActive(false);
                    StartCoroutine(FoundBookConversation());
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) insideRange = true;
        ActionText.GetComponent<Text>().text = "Press [E] to Interact";
        ActionText.SetActive(true);
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) insideRange = false;
        ActionText.SetActive(false);
    }

    IEnumerator FoundBookConversation()
    {
        yield return new WaitForSeconds(3.5f);
        subBox.SetActive(false);
        subText.GetComponent<Text>().text = "";
        characterName.GetComponent<Text>().text = "";
        bookOverlay.SetActive(true);
        optButton.GetComponentInChildren<Text>().text = "Close Book";
        optButton.SetActive(true);
    }

    public void CloseButtonPressed()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        this.GetComponent<BoxCollider>().enabled = true;
        bookOverlay.SetActive(false);
        optButton.SetActive(false);
    }

    IEnumerator FoundPossumConversation1()
    {
        yield return new WaitForSeconds(5.5f);
        subText.GetComponent<Text>().text = "Ohh, and my name is Liam, by the way, Liam the Librarian.What brings you into the library today ?";
        characterName.GetComponent<Text>().text = "Liam";
        statePossumConversation = true;
        StartCoroutine(FoundPossumConversation2());
    }

    IEnumerator FoundPossumConversation2()
    {
        yield return new WaitForSeconds(5.5f);
        subText.GetComponent<Text>().text = "Ohhh you’d like some information on bushfires! Have I got just the book for you, if I could just……ahhh…..find it.";
        characterName.GetComponent<Text>().text = "Liam";
        statePossumConversation = true;
        StartCoroutine(FoundPossumConversation3());
    }

    IEnumerator FoundPossumConversation3()
    {
        yield return new WaitForSeconds(5.5f);
        subText.GetComponent<Text>().text = "Rats, I must’ve put it back on the shelf. Now if I remember correctly, it should be in the nonfiction section. Go find it and we can give it a read together!";
        characterName.GetComponent<Text>().text = "Liam";
        statePossumConversation = true;
        StartCoroutine(ExitConversation());
    }

   IEnumerator ExitConversation()
    {
        yield return new WaitForSeconds(5.5f);
        subBox.SetActive(false);
        subText.GetComponent<Text>().text = "";
        characterName.GetComponent<Text>().text = "";
        this.GetComponent<BoxCollider>().enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}