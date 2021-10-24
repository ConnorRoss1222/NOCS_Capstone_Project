using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Threading;

public class FireTimeTrial : MonoBehaviour
{
    public static int num_burning_collected = 0;
    public static bool story_ready = false;
    public bool check = false;
    public float timer_length = 10;
    private float timeRemaining;
    public bool timerIsRunning = false;
    public bool win_minigame = false;

    public GameObject ActionText;
    public GameObject Timer;
    public GameObject Ember1;
    public GameObject Ember2;
    public GameObject Ember3;
    public GameObject Ember4;
    public GameObject Ember5;
    public GameObject Ember6;
    public GameObject Ember7;
    public GameObject Ember8;
    public GameObject Ember9;

    public static bool start = false;
    public static bool internal_start = false;

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

            timeRemaining = timer_length;
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
                if (num_burning_collected >= 9)
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
                Timer.GetComponent<Text>().text = "You ran out of time and didn't manage to put out all the embers! Go back to the truck to try again!";
                Timer.SetActive(true);
                StartCoroutine(ExitConversation());
                Reset();
            }
        }

        if(story_ready == true && check == false)
        {
            check = true;
            Reset();
        }
    }

    // Check if player enters colliderbox of ember
    // player tag on player object
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            internal_start = true;
        }
        ActionText.GetComponent<Text>().text = "Press [E] to Start Time Trial";
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
        Ember4.SetActive(true);
        Ember4.GetComponent<BoxCollider>().enabled = true;
        Ember5.SetActive(true);
        Ember5.GetComponent<BoxCollider>().enabled = true;
        Ember6.SetActive(true);
        Ember6.GetComponent<BoxCollider>().enabled = true;
        Ember7.SetActive(true);
        Ember7.GetComponent<BoxCollider>().enabled = true;
        Ember8.SetActive(true);
        Ember8.GetComponent<BoxCollider>().enabled = true;
        Ember9.SetActive(true);
        Ember9.GetComponent<BoxCollider>().enabled = true;
    }
}
