using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class startDialogueHub : MonoBehaviour
{
    public GameObject subText;
    public GameObject characterName;
    public GameObject subBox;
    public GameObject optButton01;
    public GameObject mainCamera;

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
            FullText = "Head into the portal on your left to get prepared for your mission to Earth.";
            StartCoroutine(ShowText());
            characterName.GetComponent<Text>().text = "Flurm";
            firstTimeMeeting = true;
            StartCoroutine(ExitConversation());
        }
    }
   

    IEnumerator ExitConversation()
    {
        yield return new WaitForSeconds(7f);
        subBox.SetActive(false);
        subText.GetComponent<Text>().text = "";
        characterName.GetComponent<Text>().text = "";
        Cursor.visible = false;

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
