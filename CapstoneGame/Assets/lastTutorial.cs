using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class lastTutorial : MonoBehaviour
{
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject subText;
    public GameObject subBox;
    public GameObject characterName;
    public GameObject minimap;
    public GameObject button1;

    private string FullText;
    private bool insideRange = false;

    private void Start()
    {
    }
    void Update()
    {

        if (insideRange && Input.GetKeyDown(KeyCode.E))
        {
            this.GetComponent<BoxCollider>().enabled = false;
            insideRange = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
            subBox.SetActive(true);
            characterName.GetComponent<Text>().text = "Flurm";
            FullText = "Congratulations, you're almost ready to go to Earth!! I've just got two more things to tell you.";
            StartCoroutine(ShowText(Conversation0()));
            ActionDisplay.SetActive(false);
            ActionText.SetActive(false);
        }
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

    IEnumerator Conversation0()
    {
        FullText = "Firstly, the minimap in the top right corner of your screen shows you where you are and can provide show you where to go.";
        minimap.SetActive(true);
        StartCoroutine(ShowText(Conversation1()));
        yield return new WaitForSeconds(0.05f);
    }
    IEnumerator Conversation1()
    {
        FullText = "Secondly, you can pause the game at any time by pressing the escape key.";
        StartCoroutine(ShowText(Conversation2()));
        yield return new WaitForSeconds(2.5f);
    }
    IEnumerator Conversation2()
    {
        FullText = "You've now completed your training and are qualified to go to Earth! Are you ready to begin your adventure?";
        StartCoroutine(ShowText(Button()));
        yield return new WaitForSeconds(0.05f);
    }

    IEnumerator Button()
    {
        FullText = "Yes, take me to Earth I am ready!!!";
        StartCoroutine(ShowButton());
        yield return new WaitForSeconds(0.05f);
    }

    public void LoadEarthScene()
    {
        SceneManager.LoadScene(5);
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
 

    IEnumerator ShowButton()
    {
        button1.SetActive(true);
        for (int i = 0; i < FullText.Length + 1; i++)
        {
            button1.GetComponentInChildren<Text>().text = FullText.Substring(0, i);
            yield return new WaitForSeconds(0.05f);
        }
    }
}
