using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSelect : MonoBehaviour {
	public GameObject newBall;
	public bool isOn;
	// Use this for initialization
	public void pickNewBall(){
		
		if (newBall != null) {
			BallThrower bt = GameObject.Find ("ReferencePoint").GetComponent<BallThrower> ();
			bt.ball = newBall;
		} else {
			Debug.Log ("Vazio");
		}

	}

	void OnMouseEnter(){
		isOn = true;

	}
	void OnMouseExit(){
		isOn = false;

	}
}
