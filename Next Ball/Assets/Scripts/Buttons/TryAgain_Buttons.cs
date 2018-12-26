using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TryAgain_Buttons : MonoBehaviour {

	public void LoadGame(){
		SceneManager.LoadScene ("Game");
	}
	public void LoadMenu(){
		SceneManager.LoadScene ("Menu");
	}
}
