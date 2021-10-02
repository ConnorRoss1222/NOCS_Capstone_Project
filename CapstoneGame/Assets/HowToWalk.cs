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
    private bool firstTimeMeeting = false;

    void Update()
    {
        monkey.transform.rotation = Quaternion.Euler(0, 0, 0);
     
        if (firstTimeMeeting == false)
        {
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
    }
    IEnumerator Conversation0()
    {
        yield return new WaitForSeconds(4.5f);
        subText.GetComponent<Text>().text = "Hello fellow alien, how are you feeling today?";
        characterName.GetComponent<Text>().text = "Alien 7890";
        optButton01.GetComponentInChildren<Text>().text = "Good, but I can't move around for some reason";
        optButton01.SetActive(true);
    }

    public void Answer0()
    {
        subText.GetComponent<Text>().text = "Oh, you can't move? Use your mouse and W A S D keys to move around the world. Why don't you show me and run over to the white line";
        optButton01.SetActive(false);
        StartCoroutine(ExitConversation());
    }

    IEnumerator ExitConversation()
    {
        yield return new WaitForSeconds(3.5f);
        subBox.SetActive(false);
        subText.GetComponent<Text>().text = "";
        characterName.GetComponent<Text>().text = "";
        Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Locked;
        GameObject.Find("StartDialogue").SetActive(false);

    }
}
