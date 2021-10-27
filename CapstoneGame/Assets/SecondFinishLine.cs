using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SecondFinishLine : MonoBehaviour
{

    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject subText;
    public GameObject subBox;
    public GameObject characterName;
    public GameObject flurm;
    public GameObject typeWriterSound;
    private bool insideRange = false;
    private bool firstTimeMeeting = true;
    private string FullText;

    // Start is called before the first frame update
    void Start()
    {
        //flurm.SetActive(true);
        //flurm.transform.position = new Vector3(0, 0, 0);
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
        FullText = "Wow, you picked that up quickly too! Next you'll need to know how to interact with people and objects on Earth.";
        StartCoroutine(ShowText(Conversation0()));
        yield return new WaitForSeconds(0.05f);
    }

    IEnumerator Conversation0()
    {
        FullText = "You can do this using E when prompted. Go ahead and try it out on that robot human, and the box over there. Then come meet me back here";
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
        typeWriterSound.SetActive(true);
        for (int i = 0; i < FullText.Length + 1; i++)
        {
            subText.GetComponent<Text>().text = FullText.Substring(0, i);
            yield return new WaitForSeconds(0.05f);
        }
        typeWriterSound.SetActive(false);
        yield return new WaitForSeconds(2.5f);
        StartCoroutine(nextPart);
    }

    IEnumerator ExitConversation()
    {
        yield return new WaitForSeconds(2.5f);
        subBox.SetActive(false);
        subText.GetComponent<Text>().text = "";
        characterName.GetComponent<Text>().text = "";
        flurm.SetActive(false);
        //this.GetComponent<BoxCollider>().enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
