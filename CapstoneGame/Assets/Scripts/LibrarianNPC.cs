using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LibrarianNPC : MonoBehaviour
{
    public float TheDistance;
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject subText;
    public GameObject characterName;
    public GameObject subBox;
    public GameObject bookOverlay;
    public static bool statePickupBook = false;
    public static bool statePossum = false;
    public static bool statePossumConversation = false;

    void Update()
    {
        TheDistance = PlayerCasting.DistanceFromTarget;
    }

    void OnMouseOver()
    {
        if (TheDistance <= 3)
        {
            ActionDisplay.SetActive(true);
            ActionText.GetComponent<Text>().text = "Talk";
            ActionText.SetActive(true);
        }
        else
        {
            ActionDisplay.SetActive(false);
            ActionText.SetActive(false);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            if (TheDistance <= 3)
            {

                if (LibrarianNPC.statePossum == false && LibrarianNPC.statePickupBook == false)
                {
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.Confined;
                    subBox.SetActive(true);
                    subText.GetComponent<Text>().text = "I want to talk but that possum is really freaking me out";
                    characterName.GetComponent<Text>().text = "Librarian";
                    this.GetComponent<BoxCollider>().enabled = false;
                    ActionDisplay.SetActive(false);
                    ActionText.SetActive(false);
                    StartCoroutine(ExitConversation());
                }
                else if(LibrarianNPC.statePossum == true && LibrarianNPC.statePickupBook == false)
                {
                    if (LibrarianNPC.statePossumConversation == false)
                    {
                        Cursor.visible = true;
                        Cursor.lockState = CursorLockMode.Confined;
                        subBox.SetActive(true);
                        subText.GetComponent<Text>().text = "Thank you very much for lending a helping hand there! The whole ecosystem has been going crazy since the bushland was destroyed. Ohh, and my name is Liam, by the way, Liam the Librarian. What brings you into the library today?";
                        this.GetComponent<BoxCollider>().enabled = false;
                        ActionDisplay.SetActive(false);
                        ActionText.SetActive(false);
                        StartCoroutine(FoundPossumConversation());
                    }
                    else
                    {
                        Cursor.visible = true;
                        Cursor.lockState = CursorLockMode.Confined;
                        subBox.SetActive(true);
                        subText.GetComponent<Text>().text = "I'm sorry to be like this but I cannot help you learn until you find that book.";
                        this.GetComponent<BoxCollider>().enabled = false;
                        ActionDisplay.SetActive(false);
                        ActionText.SetActive(false);
                        StartCoroutine(ExitConversation());
                    }
                }
                else if (LibrarianNPC.statePossum == true && LibrarianNPC.statePickupBook == true)
                {
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.Confined;
                    subBox.SetActive(true);
                    subText.GetComponent<Text>().text = "Oh great you found it! Let's give it a read.";
                    this.GetComponent<BoxCollider>().enabled = false;
                    ActionDisplay.SetActive(false);
                    ActionText.SetActive(false);
                    StartCoroutine(FoundBookConversation());
                }
            }
        }
    }

    IEnumerator FoundBookConversation()
    {
        yield return new WaitForSeconds(3.5f);
        subBox.SetActive(false);
        subText.GetComponent<Text>().text = "";
        characterName.GetComponent<Text>().text = "";
        bookOverlay.SetActive(true);
        StartCoroutine(ExitBook());
    }

    IEnumerator FoundPossumConversation()
    {
        yield return new WaitForSeconds(5.5f);
        subText.GetComponent<Text>().text = "Ohhh you’d like some information on bushfires! Have I got just the book for you, if I could just……ahhh…..find it. Rats, I must’ve put it back on the shelf. Now if I remember correctly, it should be in the nonfiction section.";
        characterName.GetComponent<Text>().text = "Librarian";
        statePossumConversation = true;
        StartCoroutine(ExitConversation());
    }

    IEnumerator ExitBook()
    {
        yield return new WaitForSeconds(20f);
        this.GetComponent<BoxCollider>().enabled = true;
        bookOverlay.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
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