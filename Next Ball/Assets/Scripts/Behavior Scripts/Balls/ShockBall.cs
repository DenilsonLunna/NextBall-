using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockBall : MonoBehaviour{
	public Sprite sprite;
	public int damage;
	SBall fb = new SBall();
	public class SBall : ClassBall{

		public override void SpecialPower (Collider2D col)
		{
			GameObject[] enemys = GameObject.FindGameObjectsWithTag ("EnemyBall");
			int interation = enemys.Length-1;
			while (interation >= 0) {
				Debug.Log (interation);
				Destroy (enemys[interation]);
				interation--;
			}


		}

	}

	// Use this for initialization
	void Start () {
		fb.sprite = sprite;
		this.GetComponent<SpriteRenderer> ().sprite = fb.sprite;
		fb.setDamage (damage);
	}
	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "EnemyBall" || col.tag == "Ball") { // se colidir com um inimigo
			Destroy (this.gameObject);
			fb.SpecialPower(col);

		}
	}
}
