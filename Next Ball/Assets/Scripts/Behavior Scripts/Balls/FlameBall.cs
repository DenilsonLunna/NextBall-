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
			col.GetComponent<EnemyBall> ().setDamage (0); // destroi instantaneamente
	
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
