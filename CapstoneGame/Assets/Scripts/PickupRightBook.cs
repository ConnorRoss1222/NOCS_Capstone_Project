using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupRightBook : MonoBehaviour
{
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject subText;
    public GameObject subBox;
    public GameObject Book;
    private bool insideRange = false;

    void Update()
    {
        if (insideRange && Input.GetKeyDown(KeyCode.E))
        {
            this.GetComponent<BoxCollider>().enabled = false;

            insideRange = false;

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
            subBox.SetActive(true);
            subText.GetComponent<Text>().text = "This is the book! Let's take it back to the librarian";
            LibrarianNPC.statePickupBook = true;
            ActionDisplay.SetActive(false);
            ActionText.SetActive(false);
            StartCoroutine(ExitConversation());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hit detected");
        if (other.CompareTag("Player")) insideRange = true;
        ActionText.GetComponent<Text>().text = "Press [E] to Interact";
        ActionText.SetActive(true);
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) insideRange = false;
        ActionText.SetActive(false);
    }


    IEnumerator ExitConversation()
    {
        yield return new WaitForSeconds(2.5f);
        subBox.SetActive(false);
        Book.SetActive(false);
        subText.GetComponent<Text>().text = "";
        this.GetComponent<BoxCollider>().enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Book.SetActive(false);
    }
}
