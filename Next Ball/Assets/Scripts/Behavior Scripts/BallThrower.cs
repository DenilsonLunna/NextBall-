using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class BallThrower : MonoBehaviour {

	public GameObject ball;
	public float force, maxDistance = 3;
	Vector3 mousePosition;
	GameObject instanceTemp;
	public bool instanciou = false; 

	//RESOLVENDO BUG 2 VARIAVEIS
	public bool button1;
	public bool button2;

	void Start(){

	}

	void Update () {
		
			button1 = GameObject.Find ("Ball Select").GetComponent<BallSelect> ().isOn;
			button2 = GameObject.Find ("Ball Select 2").GetComponent<BallSelect> ().isOn;
			if (!button1 && !button2) {
				thrower ();
			}

		

			

			


	}

	void newAmountBalls(){
		int p = GameObject.Find ("Game Model").GetComponent<Game_Model> ().amountBalls; // capturando os pontos atuais
		if(p == 0){
			SceneManager.LoadScene ("TryAgain");
		}
		GameObject.Find ("Game Model").GetComponent<Game_Model> ().attAmountBalls(p-1); // adicionando mais um ponto


	}

	void thrower(){
		if (Input.GetMouseButton (0)) { 
			mousePosition = Camera.main.ScreenPointToRay (Input.mousePosition).GetPoint (0);
			mousePosition.z = transform.position.z;
			if (instanciou == false) {
				instanciou = true;
				instanceTemp = Instantiate (ball, mousePosition, transform.rotation) as GameObject;
				instanceTemp.GetComponent<Rigidbody2D> ().isKinematic = true;
			}
			if (Vector3.Distance (transform.position, mousePosition) < maxDistance) { 
				instanceTemp.transform.position = mousePosition;
			} else {
				Vector3 lugarCorreto = transform.position + (mousePosition - transform.position).normalized * maxDistance;
				instanceTemp.transform.position = lugarCorreto;
			}
		}

		if (Input.GetMouseButtonUp (0) && instanciou == true) {
			instanciou = false;
			newAmountBalls ();
			Vector3 direcao = transform.position - instanceTemp.transform.position;
			instanceTemp.GetComponent<Rigidbody2D> ().isKinematic = false;
			instanceTemp.GetComponent<Rigidbody2D> ().AddForce (direcao * force, ForceMode2D.Impulse);
			instanceTemp = null;
		}
	}
}

