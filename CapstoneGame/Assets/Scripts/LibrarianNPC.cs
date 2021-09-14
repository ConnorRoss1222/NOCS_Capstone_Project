using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LibrarianNPC : MonoBehaviour
{
    public float TheDistance;
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject subText;
    public GameObject subBox;
    public static bool statePickupBook = false;

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
                if (LibrarianNPC.statePickupBook == false)
                {
                    subBox.SetActive(true);
                    subText.GetComponent<Text>().text = "It appears you haven't gotten the book yet.";
                    this.GetComponent<BoxCollider>().enabled = false;
                    ActionDisplay.SetActive(false);
                    ActionText.SetActive(false);
                    StartCoroutine(ExitConversation());
                }
                else
                {
                    subBox.SetActive(true);
                    subText.GetComponent<Text>().text = "Oh great! You got the book.";
                    this.GetComponent<BoxCollider>().enabled = false;
                    ActionDisplay.SetActive(false);
                    ActionText.SetActive(false);
                    StartCoroutine(ExitConversation());
                }
            }
        }
    }

    IEnumerator ExitConversation()
    {
        yield return new WaitForSeconds(2.5f);
        subBox.SetActive(false);
        subText.GetComponent<Text>().text = "";
        this.GetComponent<BoxCollider>().enabled = true;
    }
}