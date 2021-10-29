using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DroneLastCheckpoint : MonoBehaviour
{
    //Creates needed variables
    public GameObject characterName;
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
            //Checks if inside range and checkpoint is not already complete
            checkpointCompleted = true;
            this.GetComponent<BoxCollider>().enabled = false;
            //Increase number of completed checkpoints
            DroneMinigameController.droneScore++;
            droneScoreText.GetComponent<Text>().text = DroneMinigameController.droneScore.ToString() + "/8";
            //Activates dialogue ui
            subBox.SetActive(true);
            characterName.GetComponent<Text>().text = "Fred";
            subText.GetComponent<Text>().text = "Good job that covers everywhere! I'll take control now, why dont you take these back to Richard.";
            //Sets required bools in other scripts to true
            DroneMinigameController.CompletedCheckpoints = true;
            Reporter2.CompletedDrone = true;
            SwitchCharacter.switchcommand = true;
            //Calls exit conversation
            StartCoroutine(ExitConversation());
        }
    }

    //Brings up ui and changes insideRange bool to true when entity is detected in range
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hit detected");
        if (other.CompareTag("Drone")) insideRange = true;
    }

    //Removes ui and changes bool to false on exit of range
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Drone")) insideRange = false;
    }

    IEnumerator ExitConversation()
    {
        //Waits 2.5 seconds
        yield return new WaitForSeconds(2.5f);
        //Removes dialogue and drone score ui then unlocks camera
        subBox.SetActive(false);
        droneScoreBox.SetActive(false);
        subText.GetComponent<Text>().text = "";
        droneScoreText.GetComponent<Text>().text = "";
        this.GetComponent<BoxCollider>().enabled = true;
        thisCheckpoint.SetActive(false);
        characterName.GetComponent<Text>().text = "";
    }
}
