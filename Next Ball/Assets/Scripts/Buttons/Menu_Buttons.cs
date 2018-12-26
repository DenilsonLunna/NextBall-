using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Menu_Buttons : MonoBehaviour {

	public void LoadGame(){
		SceneManager.LoadScene ("Game");
	}
	public void Reset(){
		Debug.Log ("Reset");
		PlayerPrefs.SetInt ("bestPoint", 0);
	}
}
