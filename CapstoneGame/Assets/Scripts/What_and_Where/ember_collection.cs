using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ember_collection : MonoBehaviour
{
    public GameObject ActionText;
    public GameObject Ember;
    private bool nearEmber = false;

    // periodic updating
    private void Update()
    {
        //check if inside collider box and press e 
        if (nearEmber && Input.GetKeyDown(KeyCode.E))
        {
            // remove object and its collider box
            Ember.SetActive(false);
            this.GetComponent<BoxCollider>().enabled = false;
            //remove press e text
            ActionText.SetActive(false);

            //increment global variable and print to logs
            FireTimeTrial.num_burning_collected++;
            Debug.Log(FireTimeTrial.num_burning_collected);
        }
    }
    // Check if player enters colliderbox of ember
    // player tag on player object
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hit detected");
        if (other.CompareTag("Player")) nearEmber = true;
        ActionText.GetComponent<Text>().text = "Press [E] to Extinguish";
        ActionText.SetActive(true);
    }
    // Check if player leaves colliderbox of ember
    // player tag on player object
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) nearEmber = false;
        ActionText.SetActive(false);
    }
}


