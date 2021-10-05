using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class comealive : MonoBehaviour
{

    public GameObject first;
    public GameObject second;
    public GameObject finalFlurm;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (first.activeSelf && second.activeSelf)
        {
            finalFlurm.SetActive(true);
        }
    }
}
