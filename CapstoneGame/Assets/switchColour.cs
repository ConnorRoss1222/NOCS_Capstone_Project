using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class switchColour : MonoBehaviour
{
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject subText;
    public GameObject subBox;
    public Material red;
    public Material green;

    private string FullText;
    private bool insideRange = false;
    public int current;

    private void Start()
    {
        current = 1;
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

            if (current == 1)
            {
                this.GetComponent<MeshRenderer>().material = green;
                current = 2;

            }
            else
            {
                this.GetComponent<MeshRenderer>().material = red;
                current = 1;
            }

            FullText = "Look the colour changed!";
            StartCoroutine(ShowText(ExitConversation()));
            ActionDisplay.SetActive(false);
            ActionText.SetActive(false);
            StartCoroutine(ExitConversation());
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

    IEnumerator ShowText(IEnumerator nextPart)
    {
        for (int i = 0; i < FullText.Length + 1; i++)
        {
            subText.GetComponent<Text>().text = FullText.Substring(0, i);
            yield return new WaitForSeconds(0.05f);
        }

      //  yield return new WaitForSeconds(2.5f);
        StartCoroutine(nextPart);
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
}
