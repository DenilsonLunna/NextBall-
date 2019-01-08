using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameBall : MonoBehaviour{
	public Sprite sprite;
	public int damage;
	FBall fb = new FBall();
	public class FBall : ClassBall{

		public override void SpecialPower (Collider2D col)
		{


			Game_Model gm = GameObject.Find ("Game Model").GetComponent<Game_Model> ();
			int p = gm.amountBalls + col.GetComponent<EnemyBall> ().getDamage();
			gm.attAmountBalls(p); // adicionando mais bolas para o jogador
			Destroy (col.gameObject);

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
					fb.SpecialPower(col);
					
					Destroy (this.gameObject);
			}
	}
}
