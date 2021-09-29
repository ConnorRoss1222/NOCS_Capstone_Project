using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;
using System.Collections;

public class livingBirdsScript : MonoBehaviour
{
	public lb_BirdController birdControl;
	
	Ray ray;
	RaycastHit[] hits;

	void Start()
	{
		birdControl = GameObject.Find("_livingBirdsController").GetComponent<lb_BirdController>();
		SpawnSomeBirds();
	}

	// Update is called once per frame
	/*void Update()
	{

		if (Input.GetMouseButtonDown(0))
		{
			ray = currentCamera.ScreenPointToRay(Input.mousePosition);
			hits = Physics.RaycastAll(ray);
			foreach (RaycastHit hit in hits)
			{
				if (hit.collider.tag == "lb_bird")
				{
					hit.transform.SendMessage("KillBirdWithForce", ray.direction * 500);
					break;
				}
			}
		}
	}*/

	void OnGUI()
	{

		if (GUI.Button(new Rect(10, 70, 150, 30), "Scare All"))
			birdControl.SendMessage("AllFlee");

	}

	IEnumerator SpawnSomeBirds()
	{
		yield return 2;
		birdControl.SendMessage("SpawnAmount", 10);
	}

}
