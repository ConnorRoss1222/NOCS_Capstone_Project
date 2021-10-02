using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishLine : MonoBehaviour
{

    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject subText;
    public GameObject subBox;
    private bool insideRange = false;
    private bool firstTimeMeeting = true;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (insideRange && firstTimeMeeting == true)
        {
            this.GetComponent<BoxCollider>().enabled = false;

            insideRange = false;
            firstTimeMeeting = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
            subBox.SetActive(true);
            subText.GetComponent<Text>().text = "Looks like you can move after all. Lets get more advanced";
            // ActionDisplay.SetActive(false);
            // ActionText.SetActive(false);
            StartCoroutine(ExitConversation());
        }

    }

    IEnumerator ExitConversation()
    {
        yield return new WaitForSeconds(2.5f);
        subBox.SetActive(false);
        subText.GetComponent<Text>().text = "";
        this.GetComponent<BoxCollider>().enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hit detected");
        if (other.CompareTag("Player")) insideRange = true;
       // ActionText.GetComponent<Text>().text = "Press [E] to Interact";
        //ActionText.SetActive(true);
    }
}
