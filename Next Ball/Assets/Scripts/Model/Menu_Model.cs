using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Menu_Model : MonoBehaviour{
	public Text bestPointTxt;

	// Use this for initialization
	void Start () {
		bestPointTxt.text = PlayerPrefs.GetInt("bestPoint").ToString();
	}

}
