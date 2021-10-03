using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReporterInLibrary : MonoBehaviour
{
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject subText;
    public GameObject characterName;
    public GameObject subBox;
    public GameObject optButton01;
    public GameObject optButton02;
    private bool insideRange = false;
    private bool firstTimeMeeting = false;
    private int correctQuestion = 0;
    private string FullText = "";

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
                subText.GetComponent<Text>().text = "Hey Liam! Sorry to rush in on such short notice – the mayor has asked me to write a news report on the recent bushfire.";
                characterName.GetComponent<Text>().text = "Reporter";
                ActionDisplay.SetActive(false);
                ActionText.SetActive(false);
                firstTimeMeeting = true;
                StartCoroutine(Conversation0());
            }
            else
            {
                this.GetComponent<BoxCollider>().enabled = false;
                insideRange = false;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Confined;
                subBox.SetActive(true);
                subText.GetComponent<Text>().text = "Welcome back, are you ready to give it another go";
                characterName.GetComponent<Text>().text = "Reporter";
                ActionDisplay.SetActive(false);
                ActionText.SetActive(false);
                StartCoroutine(ConversationQuestion1());
            }
        }
    }
    
    IEnumerator Conversation0()
    {
        yield return new WaitForSeconds(5.5f);
        subText.GetComponent<Text>().text = "I’m so stressed out I have no clue where to start. Have you got any information relating to bushfires in your library?";
        characterName.GetComponent<Text>().text = "Reporter";
        StartCoroutine(Conversation1());
    }

    IEnumerator Conversation1()
    {
        yield return new WaitForSeconds(5.5f);
        subText.GetComponent<Text>().text = "Perfect Timing! The mayors new assistant and I were just reading through this book on bushfires, maybe we could offer some assistance?";
        characterName.GetComponent<Text>().text = "Librarian";
        StartCoroutine(Conversation2());
    }

    IEnumerator Conversation2()
    {
        yield return new WaitForSeconds(5.5f);
        subText.GetComponent<Text>().text = "That would be fantastic if you could just help me fill in these blanks the next issue should be done in no time";
        characterName.GetComponent<Text>().text = "Reporter";
        StartCoroutine(ConversationQuestion1());
    }

    IEnumerator ConversationQuestion1()
    {
        yield return new WaitForSeconds(5.5f);
        subText.GetComponent<Text>().text = "Many of Australia's native plants are ________";
        characterName.GetComponent<Text>().text = "Reporter";
        correctQuestion = 0;
        optButton01.GetComponentInChildren<Text>().text = "Fire prone and very combustible";
        optButton02.GetComponentInChildren<Text>().text = "Fire resistant and almost inflammable";
        optButton01.SetActive(true);
        optButton02.SetActive(true);
    }

    IEnumerator ConversationQuestion2()
    {
        yield return new WaitForSeconds(1f);
        subText.GetComponent<Text>().text = "Due to Australias hot and dry climate, _______";
        characterName.GetComponent<Text>().text = "Reporter";
        correctQuestion = 1;
        optButton01.GetComponentInChildren<Text>().text = "At any time of the year, some parts are to dry for fires to start";
        optButton02.GetComponentInChildren<Text>().text = "At any time of the year, some parts are prone to bushfires";
        optButton01.SetActive(true);
        optButton02.SetActive(true);
    }

    IEnumerator ConversationQuestion3()
    {
        yield return new WaitForSeconds(1f);
        subText.GetComponent<Text>().text = "The potential for extreme fire weather ________";
        characterName.GetComponent<Text>().text = "Reporter";
        correctQuestion = 2;
        optButton01.GetComponentInChildren<Text>().text = "Is the same across all parts of Australia";
        optButton02.GetComponentInChildren<Text>().text = "Varies greatly throughout Australia";
        optButton01.SetActive(true);
        optButton02.SetActive(true);
    }

    public void Option01()
    {
        if (correctQuestion == 0)
        {
            subText.GetComponent<Text>().text = "Correct, next is question 2.";
            optButton01.SetActive(false);
            optButton02.SetActive(false);
            StartCoroutine(ConversationQuestion2());
        }
        else if (correctQuestion == 1)
        {
            optButton01.SetActive(false);
            optButton02.SetActive(false);
            subText.GetComponent<Text>().text = "Sorry to be picky but that doesn't sound quite right to me, maybe give that book you and Liam had another read and then try again";
            characterName.GetComponent<Text>().text = "Reporter";
            StartCoroutine(ExitConversation());
        }
        else if (correctQuestion == 2)
        {
            optButton01.SetActive(false);
            optButton02.SetActive(false);
            subText.GetComponent<Text>().text = "Sorry to be picky but that doesn't sound quite right to me, maybe give that book you and Liam had another read and then try again";
            characterName.GetComponent<Text>().text = "Reporter";
            StartCoroutine(ExitConversation());
        }
    }

    public void Option02()
    {
        if (correctQuestion == 0)
        {
            optButton01.SetActive(false);
            optButton02.SetActive(false);
            subText.GetComponent<Text>().text = "Sorry to be picky but that doesn't sound quite right to me, maybe give that book you and Liam had another read and then try again";
            characterName.GetComponent<Text>().text = "Reporter";
            StartCoroutine(ExitConversation());
        }
        else if (correctQuestion == 1)
        {
            subText.GetComponent<Text>().text = "Correct, next is the final question";
            optButton01.SetActive(false);
            optButton02.SetActive(false);
            StartCoroutine(ConversationQuestion3());
        }
        else if (correctQuestion == 2)
        {
            subText.GetComponent<Text>().text = "Awesome, That all seems correct.";
            optButton01.SetActive(false);
            optButton02.SetActive(false);
            StartCoroutine(QuizComplete1());
        }
    }

    IEnumerator QuizComplete1()
    {
        yield return new WaitForSeconds(2f);
        subText.GetComponent<Text>().text = "Thank you so much for helping, I just need one more thing. The mayor has requested a photo of the area to bring awareness to the people. I need a good one as this story is going to the front page!";
        characterName.GetComponent<Text>().text = "Reporter";
        StartCoroutine(QuizComplete2());
    }

    IEnumerator QuizComplete2()
    {
        yield return new WaitForSeconds(4f);
        subText.GetComponent<Text>().text = "You look like you know how to fly a drone. Follow me!";
        characterName.GetComponent<Text>().text = "Reporter";
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
