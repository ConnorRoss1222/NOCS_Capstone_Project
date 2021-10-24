using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FiretruckHW : MonoBehaviour
{
    public static bool HW_half_complete = false;
    public bool atFiretruck = false;
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject subText;
    public GameObject characterName;
    public GameObject subBox;
    public GameObject firetruck;
    public GameObject firetruck_new_location;
    public GameObject Ranger;
    public Transform teleportTarget;
    public GameObject Player;


    // Update is called once per frame
    void Update()
    {
        if (atFiretruck && Input.GetKeyDown(KeyCode.E))
        {
            this.GetComponent<BoxCollider>().enabled = false;
            atFiretruck = false;
            ActionDisplay.SetActive(false);
            ActionText.SetActive(false);
            firetruck_new_location.SetActive(true);
            FireTimeTrial.story_ready = true;
            firetruck.SetActive(false);
            Ranger.SetActive(false);

            Player.transform.position = teleportTarget.transform.position;

            StartCoroutine(Conversation1());
        }


    }


    IEnumerator Conversation1()
    {
        yield return new WaitForSeconds(1f);
        subText.GetComponent<Text>().text = "Alright we need to act fast! See if you can put out all nine embers by stomping on them before this place becomes a blaze! Try to find them all!";
        characterName.GetComponent<Text>().text = "Fireman Fred";
        subBox.SetActive(true);
        characterName.SetActive(true);
        StartCoroutine(ExitConversation());
    }

    IEnumerator ExitConversation()
    {
        yield return new WaitForSeconds(4.5f);
        subBox.SetActive(false);
        subText.GetComponent<Text>().text = "";
        characterName.GetComponent<Text>().text = "";
        Cursor.visible = false;
        FireTimeTrial.internal_start = true;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            atFiretruck = true;
            ActionText.GetComponent<Text>().text = "Press [E] to hop in!";
            ActionText.SetActive(true);
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            atFiretruck = false;
            ActionText.SetActive(false);
        }
    }

   

}
