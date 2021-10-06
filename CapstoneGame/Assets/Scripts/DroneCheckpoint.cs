using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DroneCheckpoint : MonoBehaviour
{
    public GameObject droneScoreText;
    public GameObject thisCheckpoint;
    public GameObject nextCheckpoint;
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
            nextCheckpoint.SetActive(true);
            thisCheckpoint.SetActive(false);
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
}
