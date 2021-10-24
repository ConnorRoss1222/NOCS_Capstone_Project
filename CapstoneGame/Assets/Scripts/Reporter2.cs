using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reporter2 : MonoBehaviour
{
    public GameObject optButton;
    public GameObject photoOverlay;
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject subText;
    public GameObject characterName;
    public GameObject subBox;
    public static int droneScore = 0;
    private bool insideRange = false;
    public static bool CompletedDrone = false;

    void Update()
    {
        if (insideRange && Input.GetKeyDown(KeyCode.E))
        {
            insideRange = false;
            if (CompletedDrone == false)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Confined;
                subBox.SetActive(true);
                subText.GetComponent<Text>().text = "Thanks again for the help, if you could just meet Fireman Fred at the station he'll set you up with a drone";
                characterName.GetComponent<Text>().text = "Richard";
                this.GetComponent<BoxCollider>().enabled = false;
                ActionDisplay.SetActive(false);
                ActionText.SetActive(false);
                StartCoroutine(ExitConversation1());
            }
            else
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Confined;
                subBox.SetActive(true);
                subText.GetComponent<Text>().text = "Wow you and Fred make a great team. Here take a look at the photo for yourself.";
                characterName.GetComponent<Text>().text = "Richard";
                this.GetComponent<BoxCollider>().enabled = false;
                ActionDisplay.SetActive(false);
                ActionText.SetActive(false);
                StartCoroutine(PhotoConversation());
            }
        }
    }

    IEnumerator PhotoConversation()
    {
        yield return new WaitForSeconds(3.5f);
        subBox.SetActive(false);
        subText.GetComponent<Text>().text = "";
        characterName.GetComponent<Text>().text = "";
        photoOverlay.SetActive(true);
        optButton.GetComponentInChildren<Text>().text = "Close Photo";
        optButton.SetActive(true);
    }

    IEnumerator ExitConversation1()
    {
        yield return new WaitForSeconds(4.5f);
        subBox.SetActive(false);
        subText.GetComponent<Text>().text = "";
        characterName.GetComponent<Text>().text = "";
        this.GetComponent<BoxCollider>().enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void CloseButtonPressed()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        this.GetComponent<BoxCollider>().enabled = true;
        photoOverlay.SetActive(false);
        optButton.SetActive(false);
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
}
