using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReporterInLibrary : MonoBehaviour
{
    //Creates needed variables
    public GameObject Reporter2;
    public GameObject Fireman;
    public GameObject FiremanWaypoint;
    public GameObject Reporter;
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject subText;
    public GameObject characterName;
    public GameObject subBox;
    public GameObject optButton01;
    public GameObject optButton02;
    public GameObject qMark2;
    public GameObject qMark3;

    private bool insideRange = false;
    private bool firstTimeMeeting = false;
    private int correctQuestion = 0;
    private string FullText = "";
    public static int finishedbook = 0;

    void Update()
    {
        //Checks if inside range and interaction key is pressed or if book has been finished
        if ((insideRange && Input.GetKeyDown(KeyCode.E)) || finishedbook == 1)
        {
            //checks stage of game
            if (firstTimeMeeting == false)
            {
                //Turns onn object
                Reporter.SetActive(true);
                this.GetComponent<BoxCollider>().enabled = false;
                //Prevents loop
                insideRange = false;
                finishedbook = 0;
                //Locks camera
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Confined;
                //Turns on story objects
                subBox.SetActive(true);
                qMark2.SetActive(true);
                //Turns on dialogue ui
                subText.GetComponent<Text>().text = "Hey Lilly! Sorry to rush in on such short notice. The mayor has asked me to write a news report on the recent bushfire.";
                characterName.GetComponent<Text>().text = "Rikki";
                //Turns off action ui
                ActionDisplay.SetActive(false);
                ActionText.SetActive(false);
                //Changes story bool
                firstTimeMeeting = true;
                //Continues converstation
                StartCoroutine(Conversation0());
            }
            else
            {
                this.GetComponent<BoxCollider>().enabled = false;
                //Prevents loop
                insideRange = false;
                //Locks camera
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Confined;
                //Turns on dialogue ui
                subBox.SetActive(true);
                subText.GetComponent<Text>().text = "Welcome back, are you ready to give it another go?";
                characterName.GetComponent<Text>().text = "Rikki";
                //Turns off action ui
                ActionDisplay.SetActive(false);
                ActionText.SetActive(false);
                //Continues converstation
                StartCoroutine(ConversationQuestion1());
            }
        }
    }
    
    IEnumerator Conversation0()
    {
        //waits 5.5 seconds
        yield return new WaitForSeconds(5.5f);
        //Changes dialogue ui
        subText.GetComponent<Text>().text = "I’m so stressed out I have no clue where to start. Have you got any information relating to bushfires in your library?";
        characterName.GetComponent<Text>().text = "Rikki";
        //Continues converstation
        StartCoroutine(Conversation1());
    }

    IEnumerator Conversation1()
    {
        //waits 5.5 seconds
        yield return new WaitForSeconds(5.5f);
        //Changes dialogue ui
        subText.GetComponent<Text>().text = "Perfect timing! The mayors new assistant and I were just reading through this book on bushfires, maybe we could offer some assistance?";
        characterName.GetComponent<Text>().text = "Lilly";
        //Continues converstation
        StartCoroutine(Conversation2());
    }

    IEnumerator Conversation2()
    {
        //waits 5.5 seconds
        yield return new WaitForSeconds(5.5f);
        //Changes dialogue ui
        subText.GetComponent<Text>().text = "That would be fantastic if you could just help me fill in these blanks the next issue should be done in no time.";
        characterName.GetComponent<Text>().text = "Rikki";
        //Continues converstation
        StartCoroutine(ConversationQuestion1());
    }

    IEnumerator ConversationQuestion1()
    {
        //waits 5.5 seconds
        yield return new WaitForSeconds(5.5f);
        //Locks camera
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        //Changes dialogue ui
        subText.GetComponent<Text>().text = "Many of Australia's native plants are ________";
        characterName.GetComponent<Text>().text = "Rikki";
        //Sets question counter to zero
        correctQuestion = 0;
        //Activates button ui
        optButton01.GetComponentInChildren<Text>().text = "Fire prone and very combustible";
        optButton02.GetComponentInChildren<Text>().text = "Fire resistant and almost inflammable";
        optButton01.SetActive(true);
        optButton02.SetActive(true);
    }

    IEnumerator ConversationQuestion2()
    {
        //waits 1 seconds
        yield return new WaitForSeconds(1f);
        //Locks camera
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        //Changes dialogue ui
        subText.GetComponent<Text>().text = "Due to Australia's hot and dry climate, _______";
        characterName.GetComponent<Text>().text = "Rikki";
        //Sets question counter to one
        correctQuestion = 1;
        //Changes button ui
        optButton01.GetComponentInChildren<Text>().text = "At any time of the year, some parts are too dry for fires to start";
        optButton02.GetComponentInChildren<Text>().text = "At any time of the year, some parts are prone to bushfires";
        optButton01.SetActive(true);
        optButton02.SetActive(true);
    }

    IEnumerator ConversationQuestion3()
    {
        //waits 1 seconds
        yield return new WaitForSeconds(1f);
        //Locks camera
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        //Changes dialogue ui
        subText.GetComponent<Text>().text = "The potential for extreme fire weather ________";
        characterName.GetComponent<Text>().text = "Rikki";
        //Sets question counter to two
        correctQuestion = 2;
        //Changes button ui
        optButton01.GetComponentInChildren<Text>().text = "Is the same across all parts of Australia";
        optButton02.GetComponentInChildren<Text>().text = "Varies greatly throughout Australia";
        optButton01.SetActive(true);
        optButton02.SetActive(true);
    }

    public void Option01()
    {
        //Checks what question user is at
        if (correctQuestion == 0)
        {
            //Changes dialogue ui
            subText.GetComponent<Text>().text = "Correct, next is question 2.";
            //Turns off button ui
            optButton01.SetActive(false);
            optButton02.SetActive(false);
            //Continues conversation
            StartCoroutine(ConversationQuestion2());
        }
        else if (correctQuestion == 1)
        {
            //Turns off button ui
            optButton01.SetActive(false);
            optButton02.SetActive(false);
            //Changes dialogue ui
            subText.GetComponent<Text>().text = "Sorry to be picky but that doesn't sound quite right to me, maybe give that book you and Liam had another read and then try again";
            characterName.GetComponent<Text>().text = "Rikki";
            //Begins exit conversation
            StartCoroutine(ExitConversation());
        }
        else if (correctQuestion == 2)
        {
            //Turns off button ui
            optButton01.SetActive(false);
            optButton02.SetActive(false);
            //Changes dialogue ui
            subText.GetComponent<Text>().text = "Sorry to be picky but that doesn't sound quite right to me, maybe give that book you and Liam had another read and then try again";
            characterName.GetComponent<Text>().text = "Rikki";
            //Begins exit conversation
            StartCoroutine(ExitConversation());
        }
    }

    public void Option02()
    {
        //Checks what question user is at
        if (correctQuestion == 0)
        {
            //Turns off button ui
            optButton01.SetActive(false);
            optButton02.SetActive(false);
            //Changes dialogue ui
            subText.GetComponent<Text>().text = "Sorry to be picky but that doesn't sound quite right to me, maybe give that book you and Liam had another read and then try again";
            characterName.GetComponent<Text>().text = "Rikki";
            //Begins exit conversation
            StartCoroutine(ExitConversation());
        }
        else if (correctQuestion == 1)
        {
            //Changes dialogue ui
            subText.GetComponent<Text>().text = "Correct, next is the final question.";
            //Turns off button ui
            optButton01.SetActive(false);
            optButton02.SetActive(false);
            //Continues conversation
            StartCoroutine(ConversationQuestion3());
        }
        else if (correctQuestion == 2)
        {
            //Changes dialogue ui
            subText.GetComponent<Text>().text = "Awesome, that all seems correct.";
            //Turns off button ui
            optButton01.SetActive(false);
            optButton02.SetActive(false);
            //Continues conversation
            StartCoroutine(QuizComplete1());
        }
    }

    IEnumerator QuizComplete1()
    {
        //Waits 2 seconds
        yield return new WaitForSeconds(2f);
        //Changes dialogue ui
        subText.GetComponent<Text>().text = "Thank you so much for helping, I just need one more thing. The mayor has requested a photo of the area to bring awareness to the town. I need a good one as this story is going to the front page!";
        characterName.GetComponent<Text>().text = "Rikki";
        //Continues conversation
        StartCoroutine(QuizComplete2());
    }

    IEnumerator QuizComplete2()
    {
        //Waits 6 seconds
        yield return new WaitForSeconds(6f);
        //Changes dialogue ui
        subText.GetComponent<Text>().text = "You look like you know how to fly a drone. Follow me!";
        characterName.GetComponent<Text>().text = "Rikki";
        //begins exit conversation
        StartCoroutine(ExitConversationQuizPass());
    }

    IEnumerator ExitConversationQuizPass()
    {
        //Waits 3.5 seconds
        yield return new WaitForSeconds(3.5f);
        //Turns off dialogue ui
        subBox.SetActive(false);
        subText.GetComponent<Text>().text = "";
        characterName.GetComponent<Text>().text = "";
        this.GetComponent<BoxCollider>().enabled = true;
        //unlocks camera
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        //Edits ingame objects for story purposes
        qMark2.SetActive(false);
        qMark3.SetActive(true);
        Reporter.SetActive(false);
        Reporter2.SetActive(true);
        Fireman.SetActive(true);
        FiremanWaypoint.SetActive(true);
    }

    IEnumerator ExitConversation()
    {
        //Waits 3.5 seconds
        yield return new WaitForSeconds(3.5f);
        //Turns off dialogue ui
        subBox.SetActive(false);
        subText.GetComponent<Text>().text = "";
        characterName.GetComponent<Text>().text = "";
        this.GetComponent<BoxCollider>().enabled = true;
        //unlocks camera
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    //Brings up ui and changes insideRange bool to true when entity is detected in range
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hit detected");
        if (other.CompareTag("Player")) insideRange = true;
        ActionText.GetComponent<Text>().text = "Press [E] to Interact";
        ActionText.SetActive(true);
    }

    //Removes ui and changes bool to false on exit of range
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) insideRange = false;
        ActionText.SetActive(false);
    }

    //Sets text out in typewriter fashion
    IEnumerator ShowText(IEnumerator nextPart)
    {
        for (int i = 0; i < FullText.Length + 1; i++)
        {
            subText.GetComponent<Text>().text = FullText.Substring(0, i);
            yield return new WaitForSeconds(0.05f);
        }

        yield return new WaitForSeconds(2.5f);
        StartCoroutine(nextPart);
    }
}
