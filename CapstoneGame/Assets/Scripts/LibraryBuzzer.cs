using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LibraryBuzzer : MonoBehaviour
{
    public float BuzzerDistance;
    public GameObject subText;
    public GameObject subBox;
    private static bool buzzedIn = false;
    private static bool startup = false;



    void Update()
    {
        BuzzerDistance = PlayerCasting.DistanceFromTarget;

        if (buzzedIn == false)
        {
            if (startup == true)
            {
                if (BuzzerDistance <= 3)
                {
                    subBox.SetActive(true);
                    subText.GetComponent<Text>().text = "I'll be with you in just a moment!  I’m just trying to shoo this possum away! AGHGHH! Oooh deary me!";
                    buzzedIn = true;
                    this.GetComponent<BoxCollider>().enabled = false;
                    StartCoroutine(ExitConversation());
                }
            }
            else if (startup == false)
            {
                if (BuzzerDistance >= 30)
                {
                    startup = true;
                }
            }
        }
    }

    IEnumerator ExitConversation()
    {
        yield return new WaitForSeconds(2.5f);
        subBox.SetActive(false);;
        subText.GetComponent<Text>().text = "";
        this.GetComponent<BoxCollider>().enabled = true;
    }
}
