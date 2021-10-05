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
    public GameObject characterName;
    public GameObject flurm1;
    public GameObject flurm2;
    private bool insideRange = false;
    private bool firstTimeMeeting = true;
    private string FullText;

    // Start is called before the first frame update
    void Start()
    {
        //flurm.SetActive(true);
        //flurm.transform.position = new Vector3(0, 0, 0);
      //  flurm1.SetActive(true);

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
            characterName.GetComponent<Text>().text = "Flurm";
            subBox.SetActive(true);
            StartCoroutine(Conversation1()); 
        }

    }

   IEnumerator Conversation1()
    {
        FullText = "Looks like you've got the hang of that. Let's get more advanced!";
        StartCoroutine(ShowText(Conversation0()));
        yield return new WaitForSeconds(0.05f);
    }  

   IEnumerator Conversation0()
    {
        yield return new WaitForSeconds(1.5f);
        FullText = "You can also sprint and jump on Earth using LShift and Space. Why don't you jump up these obstacles and sprint to the end of the next hallway. See you there!";
        StartCoroutine(ShowText(ExitConversation()));
        yield return new WaitForSeconds(0.5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hit detected");
        if (other.CompareTag("Player")) insideRange = true;

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

    IEnumerator ExitConversation()
    {
        yield return new WaitForSeconds(2.5f);
        subBox.SetActive(false);
        subText.GetComponent<Text>().text = "";
        characterName.GetComponent<Text>().text = "";
        flurm1.SetActive(false);
        flurm2.SetActive(true);
        //this.GetComponent<BoxCollider>().enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
