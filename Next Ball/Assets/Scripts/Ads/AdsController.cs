using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsController : MonoBehaviour {

	public static AdsController instancia;
	// Use this for initialization
	void Awake () {
		if (instancia == null) {
			instancia = this;
		} else {
			Destroy (instancia);
		}
		DontDestroyOnLoad(instancia);
	}

	void Start(){
		Advertisement.debugMode = true;
		//id do projeto Next-Ball
		Advertisement.Initialize ("2995858", false);
	}


	public bool estaPronto(){
		if (Advertisement.IsReady ()) {
			return true;
		} else {
			return false;
		}
	}


	public void Mostrevideo(){
		if (Advertisement.IsReady ()) {
			Advertisement.Show ("video");
		} else {

		}				
	}


	public void MostrevideoPremiado (){
		if (Advertisement.IsReady ()) {
			ShowOptions options = new ShowOptions { resultCallback = HandleShowResult };
			Advertisement.Show ("rewardedVideo", options);
		} else {
			//GameObject.FindWithTag ("butao").SetActive(false);
			//GameObject.FindWithTag ("butao").GetComponentInChildren<UnityEngine.UI.Text>().text = "Carregando" ;
		}
	}

	private void HandleShowResult(ShowResult result)
	{
		switch (result)
		{
		case ShowResult.Finished:
			Debug.Log ("The ad was successfully shown.");
			// YOUR CODE TO REWARD THE GAMER
			// Give coins etc.
			break;
		case ShowResult.Skipped:
			Debug.Log("The ad was skipped before reaching the end.");
			break;
		case ShowResult.Failed:
			Debug.Log ("The ad failed to be shown.");
			break;
		}
	}


}
