using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DroneMinigameController : MonoBehaviour
{
    public GameObject Waypoint;
    public GameObject photoOverlay;
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject subText;
    public GameObject characterName;
    public GameObject subBox;
    public GameObject droneScoreText;
    public GameObject droneScoreBox;
    public GameObject firstCheckpoint;
    public GameObject qMark4;
    public GameObject qMark3;
    public static int droneScore = 0;
    private bool insideRange = false;
    public static bool CompletedCheckpoints = false;

    void Update()
    {
        if (insideRange && Input.GetKeyDown(KeyCode.E))
        {
            insideRange = false;
            if (CompletedCheckpoints == false)
            {
                Waypoint.SetActive(false);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Confined;
                subBox.SetActive(true);
                subText.GetComponent<Text>().text = "Alright, so Richard says he needs a nice wide angle shot of the land. Show me what you’ve got! Just steer along those flags that i've set up and ill take the photos of what we need.";
                characterName.GetComponent<Text>().text = "Fred";
                this.GetComponent<BoxCollider>().enabled = false;
                ActionDisplay.SetActive(false);
                ActionText.SetActive(false);
                SwitchCharacter.switchcommand = true;
                StartCoroutine(ExitConversation1());
            }
            else
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Confined;
                subBox.SetActive(true);
                subText.GetComponent<Text>().text = "That photo should be the ticket. Why don't you go ahead and take it back to richard";
                characterName.GetComponent<Text>().text = "Fred";
                qMark4.SetActive(false);
                qMark3.SetActive(true);
                this.GetComponent<BoxCollider>().enabled = false;
                ActionDisplay.SetActive(false);
                ActionText.SetActive(false);
                StartCoroutine(PhotoConversation());
            }
        }
    }

    IEnumerator PhotoConversation()
    {
        yield return new WaitForSeconds(2.5f);
        subBox.SetActive(false);
        subText.GetComponent<Text>().text = "";
        characterName.GetComponent<Text>().text = "";
        this.GetComponent<BoxCollider>().enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
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

        firstCheckpoint.SetActive(true);
        droneScoreBox.SetActive(true);
        droneScoreText.GetComponent<Text>().text = droneScore.ToString() + "/8";
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
