using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Threading;

public class FireTimeTrial : MonoBehaviour
{
    public static int num_burning_collected = 0;
    public float timeRemaining = 10;
    public bool timerIsRunning = false;
    public bool win_minigame = false;

    public GameObject ActionText;
    public GameObject Timer;
    public GameObject Ember1;
    public GameObject Ember2;
    public GameObject Ember3;
    public static bool start = false;
    public bool internal_start = false;

    private void Update()
    {
        //check if inside collider box and press e 
        if (internal_start && Input.GetKeyDown(KeyCode.E))
        {
            start = true;
           
            //remove press e text
            ActionText.SetActive(false);
            this.GetComponent<BoxCollider>().enabled = false;
            //increment global variable and print to logs
            Debug.Log("started");
            timeRemaining = 10;
            num_burning_collected = 0;
            internal_start = false;
            timerIsRunning = true;

        }

        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
                if (num_burning_collected >= 3)
                {
                    start = false;
                    timerIsRunning = false;
                    win_minigame = true;
                    Timer.GetComponent<Text>().text = "You Win!";
                    Timer.SetActive(true);
                    StartCoroutine(ExitConversation());
                }
            }
            else
            {
                start = false;
                timeRemaining = 0;
                timerIsRunning = false;
                Timer.GetComponent<Text>().text = "You ran out of time!";
                Timer.SetActive(true);
                StartCoroutine(ExitConversation());
                Reset();
            }
        }
    }

    // Check if player enters colliderbox of ember
    // player tag on player object
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hit detected start");
        if (other.CompareTag("Player"))
        {
            internal_start = true;
        }
        ActionText.GetComponent<Text>().text = "Press [E] to Start Time Trial (example for now)";
        ActionText.SetActive(true);
    }

    // Check if player leaves colliderbox of ember
    // player tag on player object
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            internal_start = false;
        }
        ActionText.SetActive(false);
    }

    private void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        Timer.GetComponent<Text>().text = "Quickly put out the embers! " + string.Format("{0:00}:{1:00}", minutes, seconds);
        Timer.SetActive(true);
    }

    IEnumerator ExitConversation()
    {
        yield return new WaitForSeconds(2.5f);
        Timer.SetActive(false);
    }

    void Reset()
    {
        this.GetComponent<BoxCollider>().enabled = true;
        Ember1.SetActive(true);
        Ember1.GetComponent<BoxCollider>().enabled = true;
        Ember2.SetActive(true);
        Ember2.GetComponent<BoxCollider>().enabled = true;
        Ember3.SetActive(true);
        Ember3.GetComponent<BoxCollider>().enabled = true;
    }
}
