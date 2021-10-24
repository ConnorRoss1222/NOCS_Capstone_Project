using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCharacter : MonoBehaviour
{

    public GameObject mainCharacter, Drone;
    public GameObject mapCamera;
    public GameObject subBox;
    public static bool switchcommand = false;
    bool currentlyTalking;
    int currentCharacter =  0;

    int mapNoMap = 0;
    // Start is called before the first frame update
    void Start()
    {
        mainCharacter.gameObject.SetActive(true);
        Drone.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (subBox.activeSelf)
        {
            currentlyTalking = true;
        }
        else
        {
            currentlyTalking = false;
        }
        if ((Input.GetKeyDown("p") && !currentlyTalking) || (switchcommand == true && !currentlyTalking))
        {
            switchcommand = false;
            switch (currentCharacter)
            {
                case 0:
                    mainCharacter.gameObject.SetActive(false);
                    Drone.gameObject.SetActive(true);
                    currentCharacter = 1;
                    break;
                case 1:
                    mainCharacter.gameObject.SetActive(true);
                    Drone.gameObject.SetActive(false);
                    currentCharacter = 0;
                    break;

            }
        }

        if (Input.GetKeyDown("m") && !currentlyTalking)
        {
            switch (mapNoMap)
            {
                case 0:
                    mainCharacter.gameObject.SetActive(false);
                    mapCamera.gameObject.SetActive(true);
                    mapNoMap = 1;
                    break;
                case 1:
                    mainCharacter.gameObject.SetActive(true);
                    mapCamera.gameObject.SetActive(false);
                    mapNoMap = 0;
                    break;

            }
        }
    
    }
}
