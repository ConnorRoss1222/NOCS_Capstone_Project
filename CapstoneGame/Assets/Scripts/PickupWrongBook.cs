using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupWrongBook : MonoBehaviour
{
    //Creates needed variables
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject subText;
    public GameObject subBox;
    public GameObject Book;
    public GameObject characterName;
    private bool insideRange = false;

    void Update()
    {
        //Checks if inside range and interaction key is pressed
        if (insideRange && Input.GetKeyDown(KeyCode.E))
        {
            //Edits box collider for ui
            this.GetComponent<BoxCollider>().enabled = false;
            //Changes inside range bool to prevent loop
            insideRange = false;
            //Locks Camera
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
            //Turns on dialogue ui
            subBox.SetActive(true);
            subText.GetComponent<Text>().text = "This doesn't seem to be the right book. Let's keep looking";
            characterName.GetComponent<Text>().text = "Flurm";
            //Turns off action ui
            ActionDisplay.SetActive(false);
            ActionText.SetActive(false);
            //Calls exit method
            StartCoroutine(ExitConversation());
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

    IEnumerator ExitConversation()
    {
        //Waits 2.5 Seconds
        yield return new WaitForSeconds(2.5f);
        //Turns off dialogue ui and this book object
        subBox.SetActive(false);
        Book.SetActive(false);
        subText.GetComponent<Text>().text = "";
        characterName.GetComponent<Text>().text = "";
        this.GetComponent<BoxCollider>().enabled = true;
        //Unlocks camera
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
