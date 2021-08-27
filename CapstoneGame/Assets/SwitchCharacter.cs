using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCharacter : MonoBehaviour
{

    public GameObject mainCharacter, Drone;

    int currentCharacter =  0;
    // Start is called before the first frame update
    void Start()
    {
        mainCharacter.gameObject.SetActive(true);
        Drone.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("p"))
        {
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
    
    }
}
