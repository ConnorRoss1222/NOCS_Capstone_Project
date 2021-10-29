using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DroneCheckpoint : MonoBehaviour
{
    //Creates needed variables
    public GameObject droneScoreText;
    public GameObject thisCheckpoint;
    public GameObject nextCheckpoint;
    private bool checkpointCompleted = false;
    private bool insideRange = false;


    void Update()
    {
        //Checks if inside range and checkpoint is not already complete
        if (insideRange && checkpointCompleted == false)
        {
            //Sets checkpoint to completed
            checkpointCompleted = true;
            this.GetComponent<BoxCollider>().enabled = false;
            //Increase number of completed checkpoints
            DroneMinigameController.droneScore++;
            droneScoreText.GetComponent<Text>().text = DroneMinigameController.droneScore.ToString() + "/8";
            //Turns off completed checkpoint and turns on next checkpoint
            nextCheckpoint.SetActive(true);
            thisCheckpoint.SetActive(false);
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
}
