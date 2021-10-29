using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bird : MonoBehaviour
{
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject subText;
    public GameObject subBox;
    public GameObject PossumObject;
    private bool insideRange = false;

    void Update()
    {
        //Checks if player is inside range and pressing interaction button
        if (insideRange && Input.GetKeyDown(KeyCode.E))
        {
            //Changes inside range bool to stop 
            insideRange = false;
            //Locks camera
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
            //Brings up text box with text and removes interaction ui
            subBox.SetActive(true);
            subText.GetComponent<Text>().text = "After getting a hold of the bird it calms down and leaves on its merry way.";
            LibrarianNPC.statePossum = true;
            this.GetComponent<BoxCollider>().enabled = false;
            ActionDisplay.SetActive(false);
            ActionText.SetActive(false);
            //Starts dialogue exit after set time
            StartCoroutine(ExitConversation());
        }
    }

    //Brings up ui and changes insideRange bool to true when entity is detected in range
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) insideRange = true;
        ActionText.GetComponent<Text>().text = "Press [E] to Capture";
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
        //Waits 2.5 seconds
        yield return new WaitForSeconds(2.5f);
        //Removes dialogue and unlocks camera
        subBox.SetActive(false);
        PossumObject.SetActive(false);
        subText.GetComponent<Text>().text = "";
        this.GetComponent<BoxCollider>().enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
