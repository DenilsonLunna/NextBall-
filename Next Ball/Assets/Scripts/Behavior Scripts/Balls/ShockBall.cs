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
			Game_Model gm = GameObject.Find ("Game Model").GetComponent<Game_Model> ();

			int interation = enemys.Length-1,p = 0;
			while (interation >= 0) {
				p += enemys[interation].GetComponent<EnemyBall>().getDamage();
				EnemyBall eb = enemys [interation].GetComponent<EnemyBall> ();

				eb.setDamage (eb.getDamage() - 1); // tira 1 de hp de cada bola em campo

				if(eb.getDamage() <= 0){
					Destroy (col.gameObject);
				}
				eb.damageTxt.text = eb.getDamage().ToString();


				interation--;
			}
			gm.attAmountBalls (gm.amountBalls + p);


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
