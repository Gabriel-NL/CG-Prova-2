using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruits_tester : MonoBehaviour {

	public GameObject[] fruits;
	
	public void Sample() 
	{
        fruits[0].transform.Rotate(Vector3.up, Time.deltaTime);
		fruits[1].transform.Rotate(Vector3.up, -Time.deltaTime);
		fruits[2].transform.Rotate(Vector3.up, Time.deltaTime);
		fruits[3].transform.Rotate(Vector3.up, -Time.deltaTime);
		fruits[4].transform.Rotate(Vector3.up, Time.deltaTime);
		fruits[5].transform.Rotate(Vector3.up, -Time.deltaTime);
        fruits[6].transform.Rotate(Vector3.up, Time.deltaTime);
		fruits[7].transform.Rotate(Vector3.up, -Time.deltaTime);
		fruits[8].transform.Rotate(Vector3.up, Time.deltaTime);
		fruits[9].transform.Rotate(Vector3.up, -Time.deltaTime);
	
	}
}
