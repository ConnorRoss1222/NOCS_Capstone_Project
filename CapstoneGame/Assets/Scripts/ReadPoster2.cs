using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadPoster2 : MonoBehaviour
{
    //Creates needed variables
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject posterOverlay;
    private bool insideRange = false;
    public GameObject optButton;


    void Update()
    {
        //Checks if inside range and interaction key is pressed
        if (insideRange && Input.GetKeyDown(KeyCode.E))
        {
            //Locks camera
            GameObject.Find("FirstPersonPlayer").GetComponent<PlayerMovementScript>().enabled = false;
            GameObject.Find("Main Camera").GetComponent<MouseLook>().enabled = false;
            GameObject.Find("Canvas").GetComponent<PauseMenu>().enabled = false;
            this.GetComponent<BoxCollider>().enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
            //Changes required bools
            insideRange = false;
            Ranger.Poster2 = true;
            //Turns on poster overlay
            posterOverlay.SetActive(true);
            //Calls button activation method
            StartCoroutine(FoundPosterCloseButton());
        }
    }

    public void CloseButtonPressed()
    {
        //Turns off ui
        this.GetComponent<BoxCollider>().enabled = true;
        posterOverlay.SetActive(false);
        optButton.SetActive(false);
        //Unlocks camera
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        GameObject.Find("FirstPersonPlayer").GetComponent<PlayerMovementScript>().enabled = true;
        GameObject.Find("Main Camera").GetComponent<MouseLook>().enabled = true;
        GameObject.Find("Canvas").GetComponent<PauseMenu>().enabled = true;
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

    IEnumerator FoundPosterCloseButton()
    {
        //Waits 10 seconds
        yield return new WaitForSeconds(10f);
        //Turns on poster button ui
        optButton.GetComponentInChildren<Text>().text = "Close Poster";
        optButton.SetActive(true);
    }
}
