using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewMainFirstDialogue : MonoBehaviour
{
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject subText;
    public GameObject characterName;
    public GameObject subBox;
    public GameObject optButton01;
    public GameObject optButton02;
    public GameObject mainCamera;
    public GameObject typeWriterSound;
    public GameObject playerCamera;

    private bool firstTimeMeeting = false;
    public string FullText;

    private void Start()
    {
        playerCamera.transform.rotation = Quaternion.Euler(0, 0, 0);
        subText.GetComponent<Text>().text = "";
    }
    void Update()
    {
        playerCamera.transform.rotation = Quaternion.Euler(0, 0, 0);
        if (firstTimeMeeting == false)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
            subBox.SetActive(true);
            FullText = "Welcome to Earth. You're in a rural country town in Australia. This town recently survived a bushfire, and we need you " +
                "to learn more about it. Are you ready?";
            StartCoroutine(ShowText());
            characterName.GetComponent<Text>().text = "Flurm";
            ActionDisplay.SetActive(false);
            ActionText.SetActive(false);
            firstTimeMeeting = true;
           // StartCoroutine(Conversation0());
        }
    }
    IEnumerator Conversation0()
    {
        yield return new WaitForSeconds(3f);
       // subText.GetComponent<Text>().text = "Hello fellow alien, how are you feeling today?";

        characterName.GetComponent<Text>().text = "Flurm";
        FullText = "Of course! What do I need to do?";
        StartCoroutine(ShowButton());
        optButton01.SetActive(true);
    }

    public void Answer0()
    {
        FullText = "Firstly, you'll need to learn what bushfires are and where they happen. I think the best place for you to go might be the ________";
        StartCoroutine(ShowTextLast());
        optButton01.SetActive(false);
      //  StartCoroutine(ExitConversation());
    }

    IEnumerator ExitConversation()
    {
        yield return new WaitForSeconds(2.3f);
        subBox.SetActive(false);
        subText.GetComponent<Text>().text = "";
        characterName.GetComponent<Text>().text = "";
        Cursor.visible = false;

        //Cursor.lockState = CursorLockMode.Locked;
        GameObject.Find("StartDialogue").SetActive(false);

    }

    IEnumerator ShowText()
    {
        typeWriterSound.SetActive(true);
        for (int i = 0; i < FullText.Length + 1; i++)
        {
            subText.GetComponent<Text>().text = FullText.Substring(0, i);
            yield return new WaitForSeconds(0.05f);
        }
        typeWriterSound.SetActive(false);
        // yield return new WaitForSeconds(2f);
        StartCoroutine(Conversation0());
    } 
    
    IEnumerator ShowTextLast()
    {
        typeWriterSound.SetActive(true);
        for (int i = 0; i < FullText.Length + 1; i++)
        {
            subText.GetComponent<Text>().text = FullText.Substring(0, i);
            yield return new WaitForSeconds(0.05f);
        }
        typeWriterSound.SetActive(false);
        StartCoroutine(ExitConversation());
    }

    IEnumerator ShowButton()
    {
        typeWriterSound.SetActive(true);
        for (int i = 0; i < FullText.Length + 1; i++)
        {
            optButton01.GetComponentInChildren<Text>().text = FullText.Substring(0, i);
            yield return new WaitForSeconds(0.05f);
        }
        typeWriterSound.SetActive(false);
    }

}
