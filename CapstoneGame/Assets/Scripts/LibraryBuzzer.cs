using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LibraryBuzzer : MonoBehaviour
{
    public GameObject Waypoint;
    public GameObject qMark;
    public GameObject subText;
    public GameObject subBox;
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject optButton01;
    public GameObject optButton02;
    public GameObject characterName;
    private bool buzzedIn = false;
    private bool insideRange = false;



    public bool finishedLibrary = false;
    public static bool finishedWW = false;


    void Update()
    {
        if ((insideRange && buzzedIn == false) && finishedLibrary == false)
        {
            Waypoint.SetActive(false);
            insideRange = false;
            finishedLibrary = true;
            subBox.SetActive(true);
            subText.GetComponent<Text>().text = "I'll be with you in just a moment!  I�m just trying to shoo this bird away! AGHGHH! Oooh deary me!";
            buzzedIn = true;
            characterName.GetComponent<Text>().text = "Liam";
            ActionText.GetComponent<Text>().text = "Help Liam capture the bird!";
            ActionText.SetActive(true);
            qMark.SetActive(true);
            this.GetComponent<BoxCollider>().enabled = false;
            StartCoroutine(ExitConversation());
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) insideRange = true;
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) insideRange = false;
    }

    IEnumerator ExitConversation()
    {
        yield return new WaitForSeconds(3.5f);
        subBox.SetActive(false);
        subText.GetComponent<Text>().text = "";
        characterName.GetComponent<Text>().text = "";
        this.GetComponent<BoxCollider>().enabled = true;
    }

}
