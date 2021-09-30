using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LibraryBuzzer : MonoBehaviour
{
    public GameObject subText;
    public GameObject subBox;
    private bool buzzedIn = false;
    private bool insideRange = false;



    void Update()
    {
        if (insideRange && buzzedIn == false)
        {
            insideRange = false;

            subBox.SetActive(true);
            subText.GetComponent<Text>().text = "I'll be with you in just a moment!  I’m just trying to shoo this bird away! AGHGHH! Oooh deary me!";
            buzzedIn = true;
            this.GetComponent<BoxCollider>().enabled = false;
            StartCoroutine(ExitConversation());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hit detected");
        if (other.CompareTag("Player")) insideRange = true;
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) insideRange = false;
    }

    IEnumerator ExitConversation()
    {
        yield return new WaitForSeconds(2.5f);
        subBox.SetActive(false);;
        subText.GetComponent<Text>().text = "";
        this.GetComponent<BoxCollider>().enabled = true;
    }
}
