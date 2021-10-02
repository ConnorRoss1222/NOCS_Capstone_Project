using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HowToWalk : MonoBehaviour
{
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject subText;
    public GameObject characterName;
    public GameObject subBox;
    public GameObject optButton01;
    public GameObject optButton02;
    public GameObject monkey;
    private bool insideRange = false;
    public static int PostersRead = 0;
    private bool firstTimeMeeting = false;


    private void Start()
    {
    }
    void Update()
    {
        monkey.transform.rotation = Quaternion.Euler(0, 0, 0);
     
        if (firstTimeMeeting == false)
        {
            insideRange = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
            subBox.SetActive(true);
            subText.GetComponent<Text>().text = "Hello fellow alien, how are you feeling today?";
            characterName.GetComponent<Text>().text = "Alien 7890";
            ActionDisplay.SetActive(false);
            ActionText.SetActive(false);
            firstTimeMeeting = true;
            StartCoroutine(Conversation0());
        }
           
           // StartCoroutine(ExitConversation());
            
    }


    //public void Option01()
    //{
    //    subText.GetComponent<Text>().text = "Great job! I knew you could-";
    //    optButton01.SetActive(false);
    //    optButton02.SetActive(false);
    //    StartCoroutine(Conversation1());
    //}

    //public void Option02()
    //{
    //    subText.GetComponent<Text>().text = "Not quite right so lets try it again";
    //    optButton01.SetActive(false);
    //    optButton02.SetActive(false);
    //    StartCoroutine(ConversationWrong());
    //}

    //IEnumerator ConversationWrong()
    //{
    //    yield return new WaitForSeconds(2.5f);
    //    subText.GetComponent<Text>().text = "What are the three main parts of the fire triangle?";
    //    characterName.GetComponent<Text>().text = "Ranger";
    //    optButton01.GetComponentInChildren<Text>().text = "oxygen, heat, fuel";
    //    optButton02.GetComponentInChildren<Text>().text = "solid, liquid, gas";
    //    optButton01.SetActive(true);
    //    optButton02.SetActive(true);
    //}

    IEnumerator Conversation0()
    {
        yield return new WaitForSeconds(4.5f);
        subText.GetComponent<Text>().text = "Hello fellow alien, how are you feeling today?";
        characterName.GetComponent<Text>().text = "Alien 7890";
        optButton01.GetComponentInChildren<Text>().text = "Good, but I can't move around for some reason";
       // optButton02.GetComponentInChildren<Text>().text = "Fire resistant and almost inflammable";
        optButton01.SetActive(true);
      //  optButton02.SetActive(true);
       // StartCoroutine(ExitConversation());
    }

    public void Answer0()
    {
        subText.GetComponent<Text>().text = "Oh, you can't move? Use your mouse and W A S D keys to move around the world. Why don't you show me and run over there";
        optButton01.SetActive(false);
        //optButton02.SetActive(false);
        StartCoroutine(ExitConversation());
    }

    //IEnumerator Question0()
    //{
    //    yield return new WaitForSeconds(5.5f);
    //    subText.GetComponent<Text>().text = "Many of Australia's native plants are ________";
    //    characterName.GetComponent<Text>().text = "Reporter";
    //    correctQuestion = 0;
    //    optButton01.GetComponentInChildren<Text>().text = "Fire prone and very combustible";
    //    optButton02.GetComponentInChildren<Text>().text = "Fire resistant and almost inflammable";
    //    optButton01.SetActive(true);
    //    optButton02.SetActive(true);
    //}
    //IEnumerator Conversation1()
    //{
    //    yield return new WaitForSeconds(1.5f);
    //    subText.GetComponent<Text>().text = "Sam! Smouldering embers from the previous fire have been detected in the bush area. It may not be a problem now, but with a bit of wind and some heat, the whole thing could go up in flames!";
    //    characterName.GetComponent<Text>().text = "Fireman";
    //    StartCoroutine(Conversation2());
    //}

    //IEnumerator Conversation2()
    //{
    //    yield return new WaitForSeconds(1.5f);
    //    subText.GetComponent<Text>().text = "Ok little dude, it’s our time to shine! Want to help us protect the town? Excellent let’s go! ";
    //    characterName.GetComponent<Text>().text = "Ranger";
    //    StartCoroutine(ExitConversation());
    //}

    IEnumerator ExitConversation()
    {
        yield return new WaitForSeconds(3.5f);
        subBox.SetActive(false);
        subText.GetComponent<Text>().text = "";
        characterName.GetComponent<Text>().text = "";
        // this.GetComponent<BoxCollider>().enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        GameObject.Find("StartDialogue").SetActive(false);

    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    Debug.Log("hit detected");
    //    if (other.CompareTag("Player")) insideRange = true;
    //    ActionText.GetComponent<Text>().text = "Press [E] to Interact";
    //    ActionText.SetActive(true);
    //}


    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.CompareTag("Player")) insideRange = false;
    //    ActionText.SetActive(false);
    //}
}
