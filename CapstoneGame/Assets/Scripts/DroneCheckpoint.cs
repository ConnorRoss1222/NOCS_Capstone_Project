using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DroneCheckpoint : MonoBehaviour
{
    public GameObject droneScoreText;
    private int droneScore = 0;
    private bool checkpointCompleted = false;
    private bool insideRange = false;

    void Update()
    {
        if (insideRange && checkpointCompleted == false)
        {
            checkpointCompleted = true;
            this.GetComponent<BoxCollider>().enabled = false;
            droneScore++;
            droneScoreText.GetComponent<Text>().text = droneScore.ToString();
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
