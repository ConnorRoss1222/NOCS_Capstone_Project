using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadPoster2 : MonoBehaviour
{
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject posterOverlay;
    private bool insideRange = false;
    public GameObject optButton;


    void Update()
    {
        if (insideRange && Input.GetKeyDown(KeyCode.E))
        {
            GameObject.Find("FirstPersonPlayer").GetComponent<PlayerMovementScript>().enabled = false;
            GameObject.Find("Main Camera").GetComponent<MouseLook>().enabled = false;
            GameObject.Find("Canvas").GetComponent<PauseMenu>().enabled = false;
            this.GetComponent<BoxCollider>().enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
            insideRange = false;
            Ranger.Poster2 = true;
            posterOverlay.SetActive(true);
            optButton.GetComponentInChildren<Text>().text = "Close Poster";
            optButton.SetActive(true);
        }
    }

    public void CloseButtonPressed()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        this.GetComponent<BoxCollider>().enabled = true;
        posterOverlay.SetActive(false);
        optButton.SetActive(false);
        GameObject.Find("FirstPersonPlayer").GetComponent<PlayerMovementScript>().enabled = true;
        GameObject.Find("Main Camera").GetComponent<MouseLook>().enabled = true;
        GameObject.Find("Canvas").GetComponent<PauseMenu>().enabled = true;
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
}
