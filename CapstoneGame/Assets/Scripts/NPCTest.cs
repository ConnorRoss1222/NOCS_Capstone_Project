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
    public GameObject subBox;
    public GameObject optButton01;
    public GameObject optButton02;

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
                subBox.SetActive(true);
                subText.GetComponent<Text>().text = "Whoa! What are you doing out here little dude, the fire may have passed but this smoke still isn’t good for you. Lucky I decided to stay around for civilians or you’d be in serious trouble.";
                this.GetComponent<BoxCollider>().enabled = false;
                ActionDisplay.SetActive(false);
                ActionText.SetActive(false);
                StartCoroutine(StartSelectConvo());
            }
        }
    }

    void OnMouseExit()
    {
        ActionDisplay.SetActive(false);
        ActionText.SetActive(false);
    }

    IEnumerator StartSelectConvo()
    {
        yield return new WaitForSeconds(2.5f);
        subText.GetComponent<Text>().text = "Why don’t you head into town, the mayor is currently learning about bushfires himself in the hopes of preventing another and helping him research could do you both a favour.";
        optButton01.GetComponentInChildren<Text>().text = "Yes";
        optButton02.GetComponentInChildren<Text>().text = "No";
        optButton01.SetActive(true);
        optButton02.SetActive(true);
    }

    public void Option01()
    {
        StartCoroutine(StartYes());
    }

    IEnumerator StartYes()
    {
        optButton01.SetActive(false);
        optButton02.SetActive(false);
        subText.GetComponent<Text>().text = "Great! Here if you pass me that map you got there, I’ll mark down his location.";
        yield return new WaitForSeconds(2.5f);
        subBox.SetActive(false);
        subText.GetComponent<Text>().text = "";
        this.GetComponent<BoxCollider>().enabled = true;
    }

    public void Option02()
    {
        optButton01.SetActive(false);
        optButton02.SetActive(false);
        subBox.SetActive(false);
        subText.GetComponent<Text>().text = "";
        this.GetComponent<BoxCollider>().enabled = true;
    }
}
