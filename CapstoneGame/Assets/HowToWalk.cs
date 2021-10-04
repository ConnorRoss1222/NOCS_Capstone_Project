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
    public GameObject mainCamera;
    public GameObject flurm;
    public GameObject flurm1;
    private bool firstTimeMeeting = false;
    public string FullText;

    private void Start()
    {
        subText.GetComponent<Text>().text = "";

    }
    void Update()
    {
        mainCamera.transform.rotation = Quaternion.Euler(0, 0, 0);
     
        if (firstTimeMeeting == false)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
            subBox.SetActive(true);
            FullText = "Hello recruit, are you ready for your Earth preparedness training?";
            StartCoroutine(ShowText());
            characterName.GetComponent<Text>().text = "Flurm";
            ActionDisplay.SetActive(false);
            ActionText.SetActive(false);
            firstTimeMeeting = true;
            StartCoroutine(Conversation0());
        }
    }
    IEnumerator Conversation0()
    {
        yield return new WaitForSeconds(4.5f);
       // subText.GetComponent<Text>().text = "Hello fellow alien, how are you feeling today?";

        characterName.GetComponent<Text>().text = "Flurm";
        FullText = "Yes sir, what's first?";
        StartCoroutine(ShowButton());
        optButton01.SetActive(true);
    }

    public void Answer0()
    {
        FullText = "First thing you'll need on earth is movement. Use your mouse and W A S D keys to move around the world. Why don't you show me and run over to the white line over there.";
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
        flurm.SetActive(false);
        flurm1.SetActive(true);

        //Cursor.lockState = CursorLockMode.Locked;
        GameObject.Find("StartDialogue").SetActive(false);

    }

    IEnumerator ShowText()
    {
        for (int i = 0; i < FullText.Length + 1; i++)
        {
            subText.GetComponent<Text>().text = FullText.Substring(0, i);
            yield return new WaitForSeconds(0.05f);
        }
    } IEnumerator ShowTextLast()
    {
        for (int i = 0; i < FullText.Length + 1; i++)
        {
            subText.GetComponent<Text>().text = FullText.Substring(0, i);
            yield return new WaitForSeconds(0.05f);
        }
        StartCoroutine(ExitConversation());
    }

    IEnumerator ShowButton()
    {
        for (int i = 0; i < FullText.Length + 1; i++)
        {
            optButton01.GetComponentInChildren<Text>().text = FullText.Substring(0, i);
            yield return new WaitForSeconds(0.05f);
        }
    }

}
