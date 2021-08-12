using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCTest : MonoBehaviour
{
    public float TheDistance;
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject subText;

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
                subText.GetComponent<Text>().text = "Hello this is a test";
                this.GetComponent<BoxCollider>().enabled = false;
                ActionDisplay.SetActive(false);
                ActionText.SetActive(false);
                StartCoroutine(ResetChat());
            }
        }
    }

    void OnMouseExit()
    {
        ActionDisplay.SetActive(false);
        ActionText.SetActive(false);
    }

    IEnumerator ResetChat()
    {
        yield return new WaitForSeconds(2.5f);
        subText.GetComponent<Text>().text = "";
        this.GetComponent<BoxCollider>().enabled = false;
    }
}
