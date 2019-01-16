using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowerClouds : MonoBehaviour {
	public GameObject clouds;
	public float timeThrower;
	public float time = 0;
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;

		if (time >= timeThrower) {
			Instantiate (clouds, this.transform.position, Quaternion.identity);
			time = 0;
		}


	}


}
