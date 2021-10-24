using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUpAndDown : MonoBehaviour
{
    private bool up = false;
    private bool down = true;
    private float startingPoint;
    private Vector3 position;
    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
        startingPoint = position.y;

    }

    // Update is called once per frame
    void Update()
    {
        position = transform.position;

        if (down == true)
        {
            position.y -= 0.3f;
            if (position.y < (startingPoint - 12))
            {
                up = true;
                down = false;
            }
        }
        if (up == true)
        {
            position.y += 0.3f;
            if (position.y > (startingPoint + 12))
            {
                up = false;
                down = true;
            }
        }

        transform.Rotate(0, 0, 1);
        transform.position = position;
    }
}
