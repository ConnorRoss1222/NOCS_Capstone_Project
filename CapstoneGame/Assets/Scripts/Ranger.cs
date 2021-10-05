using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ranger : MonoBehaviour
{
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject subText;
    public GameObject characterName;
    public GameObject subBox;
    public GameObject optButton01;
    public GameObject optButton02;
    private bool insideRange = false;
    public static int PostersRead = 0;
    private bool firstTimeMeeting = false;

    void Update()
    {
        if (insideRange && Input.GetKeyDown(KeyCode.E))
        {
            if (firstTimeMeeting == false)
            {
                this.GetComponent<BoxCollider>().enabled = false;
                insideRange = false;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Confined;
                subBox.SetActive(true);
                subText.GetComponent<Text>().text = "Hey there little mate, my name’s Ranger Sam. What brings you around here?";
                characterName.GetComponent<Text>().text = "Ranger";
                ActionDisplay.SetActive(false);
                ActionText.SetActive(false);
                firstTimeMeeting = true;
                StartCoroutine(Conversation0());
            }
            else
            {
                if (PostersRead >= 3)
                {
                    this.GetComponent<BoxCollider>().enabled = false;
                    insideRange = false;
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.Confined;
                    subBox.SetActive(true);
                    subText.GetComponent<Text>().text = "Alright, now you’ve got a basic understanding on how bushfires start, remind me – What are the three main parts of the fire triangle?";
                    characterName.GetComponent<Text>().text = "Ranger";
                    ActionDisplay.SetActive(false);
                    ActionText.SetActive(false);
                    optButton01.GetComponentInChildren<Text>().text = "oxygen, heat, fuel";
                    optButton02.GetComponentInChildren<Text>().text = "solid, liquid, gas";
                    optButton01.SetActive(true);
                    optButton02.SetActive(true);
                }
                else
                {
                    this.GetComponent<BoxCollider>().enabled = false;
                    insideRange = false;
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.Confined;
                    subBox.SetActive(true);
                    subText.GetComponent<Text>().text = "Sorry little dude but I don't wanna give you any jobs if you dont understand the risk. Try reading all of those posters and then come back.";
                    characterName.GetComponent<Text>().text = "Ranger";
                    ActionDisplay.SetActive(false);
                    ActionText.SetActive(false);
                    StartCoroutine(ExitConversation());
                }
            }
        }
    }


    public void Option01()
    {
        subText.GetComponent<Text>().text = "Great job! I knew you could-";
        optButton01.SetActive(false);
        optButton02.SetActive(false);
        StartCoroutine(Conversation1());
    }

    public void Option02()
    {
        subText.GetComponent<Text>().text = "Not quite right so lets try it again";
        optButton01.SetActive(false);
        optButton02.SetActive(false);
        StartCoroutine(ConversationWrong());
    }

    IEnumerator ConversationWrong()
    {
        yield return new WaitForSeconds(2.5f);
        subText.GetComponent<Text>().text = "What are the three main parts of the fire triangle?";
        characterName.GetComponent<Text>().text = "Ranger";
        optButton01.GetComponentInChildren<Text>().text = "oxygen, heat, fuel";
        optButton02.GetComponentInChildren<Text>().text = "solid, liquid, gas";
        optButton01.SetActive(true);
        optButton02.SetActive(true);
    }

    IEnumerator Conversation0()
    {
        yield return new WaitForSeconds(4.5f);
        subText.GetComponent<Text>().text = "Oh so you're helping out the mayor, well if you wanna learn more about bushfires why don't you give the posters I just put up a read";
        characterName.GetComponent<Text>().text = "Ranger";
        StartCoroutine(ExitConversation());
    }

    IEnumerator Conversation1()
    {
        yield return new WaitForSeconds(1.5f);
        subText.GetComponent<Text>().text = "Sam! Smouldering embers from the previous fire have been detected in the bush area. It may not be a problem now, but with a bit of wind and some heat, the whole thing could go up in flames!";
        characterName.GetComponent<Text>().text = "Fireman";
        StartCoroutine(Conversation2());
    }

    IEnumerator Conversation2()
    {
        yield return new WaitForSeconds(1.5f);
        subText.GetComponent<Text>().text = "Ok little dude, it’s our time to shine! Want to help us protect the town? Excellent let’s go! ";
        characterName.GetComponent<Text>().text = "Ranger";
        StartCoroutine(ExitConversation());
    }

    IEnumerator ExitConversation()
    {
        yield return new WaitForSeconds(3.5f);
        subBox.SetActive(false);
        subText.GetComponent<Text>().text = "";
        characterName.GetComponent<Text>().text = "";
        this.GetComponent<BoxCollider>().enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hit detected");
        if (other.CompareTag("Player")) insideRange = true;
        ActionText.GetComponent<Text>().text = "Press [E] to Interact";
        ActionText.SetActive(true);
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) insideRange = false;
        ActionText.SetActive(false);
    }
}
