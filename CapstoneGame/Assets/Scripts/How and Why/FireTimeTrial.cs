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
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject subText;
    public GameObject characterName;
    public GameObject subBox;
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

            timeRemaining = timer_length;
            num_burning_collected = 0;
            internal_start = false;
            timerIsRunning = true;

        }

        if (timerIsRunning)
        {
            //timer has run out - win scenario and goodbye
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
                    subText.SetActive(true);
                    subText.GetComponent<Text>().text = "Fantastic work little man. You saved the town! Thanks for helping us out.";
                    characterName.GetComponent<Text>().text = "Fireman Fred";
                    subBox.SetActive(true);
                    characterName.SetActive(true);
                    StartCoroutine(ExitConversation2());
                }
            }
            else
            {
                //timer has run out - lose scenario
                start = false;
                timeRemaining = 0;
                timerIsRunning = false;
                Timer.GetComponent<Text>().text = "You ran out of time and didn't manage to put out all the embers! Go back to the truck to try again!";
                Timer.SetActive(true);
                StartCoroutine(ExitConversation());
                Reset();
            }
        }
        // first time teleporting to firetruck - say scripting
        if(story_ready == true && check == false && internal_start == true)
        {
            check = true;

            subText.GetComponent<Text>().text = "Alright we need to act fast! See if you can put out all nine embers by stomping on them before this place becomes a blaze! Try to find them all!";
            characterName.GetComponent<Text>().text = "Fireman Fred";
            subBox.SetActive(true);
            characterName.SetActive(true);
            StartCoroutine(Conversation1());

            Reset();
        }
    }

    //exit final conversation
    IEnumerator Conversation1()
    {
        yield return new WaitForSeconds(4f);
        subBox.SetActive(false);
        subText.SetActive(false);
        characterName.SetActive(false);
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

    //display count down timer in seconds
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

    IEnumerator ExitConversation2()
    {
        yield return new WaitForSeconds(4.5f);
        Timer.SetActive(false);
        subText.GetComponent<Text>().text = "Your work here is now complete. Feel free to explore the town or return home. We will miss you!";
        characterName.GetComponent<Text>().text = "Fireman Fred";
        StartCoroutine(ExitConversation3());
    }

    IEnumerator ExitConversation3()
    {
        yield return new WaitForSeconds(4.5f);
        subBox.SetActive(false);
        subText.SetActive(false);
        characterName.SetActive(false);

    }

    // reset all embers and place them accordingly
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
