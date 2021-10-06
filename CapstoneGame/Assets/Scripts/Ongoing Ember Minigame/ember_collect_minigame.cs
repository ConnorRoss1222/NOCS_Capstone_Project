using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Threading;

public class ember_collect_minigame : MonoBehaviour
{
    public GameObject ActionText;
    public GameObject Count;
    public GameObject Ember;
    private bool nearEmber = false;

    // periodic updating
    private void Update()
    {
        //check if inside collider box and press e 
        if (nearEmber && Input.GetKeyDown(KeyCode.E))
        {
            // remove object and its collider box
            this.GetComponent<BoxCollider>().enabled = false;
            //remove press e text
            ActionText.SetActive(false);

            //increment global variable and print to logs
            ember_minigame.num_embers_collected++;
            nearEmber = false;
            Count.GetComponent<Text>().text = ember_minigame.num_embers_collected + "/10 Collected!";
            Count.SetActive(true);
            StartCoroutine(ExitCount());
        }
    }

    // Check if player enters colliderbox of ember
    // player tag on player object
    private void OnTriggerEnter(Collider other)
    {
        //only allow if timer has started

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


    IEnumerator ExitCount()
    {
        yield return new WaitForSeconds(3f);
        Count.SetActive(false);
        Ember.SetActive(false);
    }
}


