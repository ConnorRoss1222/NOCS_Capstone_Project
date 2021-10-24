using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DroneLastCheckpoint : MonoBehaviour
{
    public GameObject subText;
    public GameObject subBox;
    public GameObject droneScoreText;
    public GameObject droneScoreBox;
    public GameObject thisCheckpoint;
    private bool checkpointCompleted = false;
    private bool insideRange = false;

    void Update()
    {
        if (insideRange && checkpointCompleted == false)
        {
            checkpointCompleted = true;
            this.GetComponent<BoxCollider>().enabled = false;
            DroneMinigameController.droneScore++;
            droneScoreText.GetComponent<Text>().text = DroneMinigameController.droneScore.ToString() + "/8";
            subBox.SetActive(true);
            subText.GetComponent<Text>().text = "Good job that covers everywhere! I'll take control now, why dont you take these back to Richard";
            DroneMinigameController.CompletedCheckpoints = true;
            SwitchCharacter.switchcommand = true;
            StartCoroutine(ExitConversation());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hit detected");
        if (other.CompareTag("Drone")) insideRange = true;
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Drone")) insideRange = false;
    }

    IEnumerator ExitConversation()
    {
        yield return new WaitForSeconds(2.5f);
        subBox.SetActive(false);
        droneScoreBox.SetActive(false);
        subText.GetComponent<Text>().text = "";
        droneScoreText.GetComponent<Text>().text = "";
        this.GetComponent<BoxCollider>().enabled = true;
        thisCheckpoint.SetActive(false);
    }
}
