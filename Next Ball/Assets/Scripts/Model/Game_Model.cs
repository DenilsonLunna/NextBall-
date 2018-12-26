using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Game_Model : MonoBehaviour {
	public int bestPoint;
	public int lifeGame;
	public int amountBalls;
	public Text bestPointTxt;
	public Text lifeGameTxt;
	public Text amountBallsTxt;

	void Start(){
		PlayerPrefs.SetInt ("pointsInGame",0); //resetando pontos
		this.bestPointTxt.text = bestPoint.ToString();
		this.lifeGameTxt.text = lifeGame.ToString();
		this.amountBallsTxt.text = amountBalls.ToString();

	}

	public void attBestPoint(int newPoint){
		bestPoint = newPoint;
		this.bestPointTxt.text = newPoint.ToString();


	}
	public void attLifeGame(int newLifeGame){
		lifeGame = newLifeGame;
		this.lifeGameTxt.text = newLifeGame.ToString ();

	}
	public void attAmountBalls(int newABalls){
		amountBalls = newABalls;
		this.amountBallsTxt.text = newABalls.ToString ();

	}
		

}
