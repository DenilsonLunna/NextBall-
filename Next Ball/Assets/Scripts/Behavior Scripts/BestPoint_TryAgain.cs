using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BestPoint_TryAgain : MonoBehaviour {
	public Text bestPointText;
	// Use this for initialization
	void Start () {
		this.GetComponent<Text> ().text = PlayerPrefs.GetInt ("pointsInGame").ToString ();
		if (PlayerPrefs.GetInt ("pointsInGame") > PlayerPrefs.GetInt ("bestPoint")) {
			PlayerPrefs.SetInt ("bestPoint", PlayerPrefs.GetInt ("pointsInGame"));
			bestPointText.text = "New Record";
		
		} else {
			bestPointText.text = "Your Points";
		}
	}

}
