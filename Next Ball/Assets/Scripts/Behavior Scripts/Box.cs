using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Box : MonoBehaviour {
	public GameObject[] balls;
	public Text lifeTxt;
	private int tamList;

	newBox box = new newBox();

	void Start(){
		box.setLife(Random.Range(3,7));
		lifeTxt.text = box.getLife ().ToString ();

	}
	public class newBox : ClassBox{
		public override void Effect (GameObject[] balls)
		{
			BallThrower bt = GameObject.Find ("ReferencePoint").GetComponent<BallThrower> ();
			GameObject newBall = balls [Random.Range (0, balls.Length)];
			bt.ball = newBall;
			GameObject.Find ("ReferencePoint").GetComponent<SpriteRenderer> ().sprite = newBall.GetComponent<SpriteRenderer> ().sprite; 
		}

	}

	void OnTriggerEnter2D(Collider2D col){
		if (!GameObject.Find ("ReferencePoint").GetComponent<BallThrower> ().instanciou) { // resolvendo bug 1
			if (col.name == "Ball(Clone)") {
				box.setLife (box.getLife () - col.GetComponent<Ball> ().damage);
				lifeTxt.text = box.getLife ().ToString ();
				if (box.getLife () == 0) {
					box.Effect (balls);
					Destroy (this.gameObject);
				}

			}
		}


	}
}
