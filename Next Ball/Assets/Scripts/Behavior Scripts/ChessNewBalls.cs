using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ChessNewBalls : MonoBehaviour {
	private GameObject newBall;
	public List<GameObject> balls;
	private Button ballSelect1;
	private Button ballSelect2;
	public Text lifeTxt;

	public int life;
	// Use this for initialization
	void Start () {
		life = 5; // adicionando vida do bau
		lifeTxt.text = life.ToString ();
		int tam = balls.Count;
		newBall = balls[Random.Range(0,tam)];
		this.GetComponent<Rigidbody2D> ().drag = (life * 0.1f)+(life*0.05f); // definindo  velocidade que o obstaculo vai cair
		ballSelect1 = GameObject.Find ("Ball Select").GetComponent<Button>();
		ballSelect2 = GameObject.Find ("Ball Select 2").GetComponent<Button>();


	}
		
	void OnTriggerEnter2D(Collider2D col){
		if (!GameObject.Find ("ReferencePoint").GetComponent<BallThrower> ().instanciou) { // resolvendo bug 1
			if (col.tag == "Ball") {
				this.life -= 1;
				if (life == 0) {
					BallSelect bs1 = GameObject.Find ("Ball Select").GetComponent<BallSelect>();
					BallSelect bs2 = GameObject.Find ("Ball Select 2").GetComponent<BallSelect>();

					if (bs1.newBall == null) {
						bs1.newBall = newBall;
						bs1.GetComponent<Image> ().sprite = newBall.GetComponent<SpriteRenderer> ().sprite;
					} else if (bs2.newBall == null) {
						bs2.newBall = newBall;
						bs2.GetComponent<Image> ().sprite = newBall.GetComponent<SpriteRenderer> ().sprite;
					} else {
						Debug.Log ("Cheio");
					}
					Destroy (this.gameObject);
				}
				lifeTxt.text = life.ToString ();
			}
		}

	}

}
