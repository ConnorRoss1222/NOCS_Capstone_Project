using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ifFall : MonoBehaviour
{
    private Vector3 currentPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentPos = transform.position;
        if (currentPos.y < -10)
        {
            currentPos.x = -320;
            currentPos.y = 3;
            currentPos.z = -1281;
        }

        transform.position = currentPos;
    }
}
