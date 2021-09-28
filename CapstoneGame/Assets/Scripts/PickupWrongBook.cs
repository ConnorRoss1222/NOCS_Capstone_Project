using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupWrongBook : MonoBehaviour
{
    public float TheDistance;
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject subText;
    public GameObject subBox;
    public GameObject Book;

    void Update()
    {
        TheDistance = PlayerCasting.DistanceFromTarget;
    }

    void OnMouseOver()
    {
        if (TheDistance <= 3)
        {
            ActionDisplay.SetActive(true);
            ActionText.GetComponent<Text>().text = "Talk";
            ActionText.SetActive(true);
        }
        else
        {
            ActionDisplay.SetActive(false);
            ActionText.SetActive(false);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            if (TheDistance <= 3)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Confined;
                subBox.SetActive(true);
                subText.GetComponent<Text>().text = "This doesn't seem to be the right book. Lets keep looking";
                this.GetComponent<BoxCollider>().enabled = false;
                ActionDisplay.SetActive(false);
                ActionText.SetActive(false);
                StartCoroutine(ExitConversation());
            }
        }
    }

    IEnumerator ExitConversation()
    {
        yield return new WaitForSeconds(2.5f);
        subBox.SetActive(false);
        Book.SetActive(false);
        subText.GetComponent<Text>().text = "";
        this.GetComponent<BoxCollider>().enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
