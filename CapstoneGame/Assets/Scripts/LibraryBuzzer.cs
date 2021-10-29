using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LibraryBuzzer : MonoBehaviour
{
    //Creates needed variables
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
        //Checks if inside range and hasnt already activated the buzzer
        if ((insideRange && buzzedIn == false) && finishedLibrary == false)
        {
            //Turns off waypoint object
            Waypoint.SetActive(false);
            //Chages required bool to prevent loop
            insideRange = false;
            finishedLibrary = true;
            buzzedIn = true;
            //Turns on dialogue ui
            subBox.SetActive(true);
            subText.GetComponent<Text>().text = "I'll be with you in just a moment!  I’m just trying to shoo this bird away! AGHGHH! Oooh deary me!";
            characterName.GetComponent<Text>().text = "Liam";
            //Changes action ui
            ActionText.GetComponent<Text>().text = "Help Liam capture the bird!";
            ActionText.SetActive(true);
            //Turns on question mark object
            qMark.SetActive(true);
            this.GetComponent<BoxCollider>().enabled = false;
            //Calls exit method
            StartCoroutine(ExitConversation());
        }

    }
    //Brings up ui and changes insideRange bool to true when entity is detected in range
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) insideRange = true;
    }

    //Removes ui and changes bool to false on exit of range
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) insideRange = false;
    }

    IEnumerator ExitConversation()
    {
        //Waits 5.5 Seconds
        yield return new WaitForSeconds(3.5f);
        //Turns off dialogue ui
        subBox.SetActive(false);
        subText.GetComponent<Text>().text = "";
        characterName.GetComponent<Text>().text = "";
        this.GetComponent<BoxCollider>().enabled = true;
    }

}
