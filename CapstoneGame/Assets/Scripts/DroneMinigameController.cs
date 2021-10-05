using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DroneMinigameController : MonoBehaviour
{
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject subText;
    public GameObject characterName;
    public GameObject subBox;
    public GameObject droneScoreText;
    public GameObject droneScoreBox;
    public GameObject firstCheckpoint;
    public static int droneScore = 0;
    private bool insideRange = false;

    void Update()
    {
        if (insideRange && Input.GetKeyDown(KeyCode.E))
        {
            insideRange = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
            subBox.SetActive(true);
            subText.GetComponent<Text>().text = "Alright, so I need a nice wide angle shot of the land. Show me what you�ve got! Just steer along those flags that i've set up and ill take the photos of what we need. When you are ready to start press P";
            characterName.GetComponent<Text>().text = "Reporter";
            this.GetComponent<BoxCollider>().enabled = false;
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
        yield return new WaitForSeconds(4.5f);
        subBox.SetActive(false);
        subText.GetComponent<Text>().text = "";
        characterName.GetComponent<Text>().text = "";
        this.GetComponent<BoxCollider>().enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        firstCheckpoint.SetActive(true);
        droneScoreBox.SetActive(true);
        droneScoreText.GetComponent<Text>().text = droneScore.ToString();
    }
}