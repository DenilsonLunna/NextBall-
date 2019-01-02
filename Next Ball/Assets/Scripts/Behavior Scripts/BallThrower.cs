using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class BallThrower : MonoBehaviour {

	public GameObject ball;
	public float force, maxDistance = 3;
	Vector3 mousePosition;
	GameObject instanceTemp;
	public bool instanciou = false; 
	private GameObject simpleBall;
	void Start(){
		simpleBall = ball;

	}

	void Update () {
		if (Input.GetMouseButton (0)) { 
			//pegando e ajustando posicao do mouse
			mousePosition = Camera.main.ScreenPointToRay (Input.mousePosition).GetPoint (0);
			mousePosition.z = transform.position.z;


			if (instanciou == false) {
				instanciou = true;
				instanceTemp = Instantiate (ball, mousePosition, transform.rotation) as GameObject;// instanciando bola
				instanceTemp.GetComponent<Rigidbody2D> ().isKinematic = true;
			}
			if (Vector3.Distance (transform.position, mousePosition) < maxDistance) { // limitação da posicao da bola
				instanceTemp.transform.position = mousePosition;
			} else {
				Vector3 lugarCorreto = transform.position + (mousePosition - transform.position).normalized * maxDistance; // colocando a bola na posicao correta
				instanceTemp.transform.position = lugarCorreto;
			}
		}

		if (Input.GetMouseButtonUp (0) && instanciou == true) { // lancar bola
			instanciou = false;
			newAmountBalls ();
			Vector3 direcao = transform.position - instanceTemp.transform.position;
			instanceTemp.GetComponent<Rigidbody2D> ().isKinematic = false;
			instanceTemp.GetComponent<Rigidbody2D> ().AddForce (direcao * force, ForceMode2D.Impulse);


			//isso esta fazendo com que quando eu troque por uma bola com efeito especial, depois de utiliza ela eu volte para a bola normal, no caso a Simple ball
			if (instanceTemp.name != "Ball") {
				ball = simpleBall;
			}

			instanceTemp = null;

		}

	}

	void newAmountBalls(){
		int p = GameObject.Find ("Game Model").GetComponent<Game_Model> ().amountBalls; // capturando os pontos atuais
		if(p == 0){
			SceneManager.LoadScene ("TryAgain");
		}
		GameObject.Find ("Game Model").GetComponent<Game_Model> ().attAmountBalls(p-1); // adicionando mais um ponto


	}
}
