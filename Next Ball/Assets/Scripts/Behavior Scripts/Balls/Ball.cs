using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
	public Sprite sprite;
	public int damage;

	public NormalBall nb = new NormalBall ();

	public class NormalBall : ClassBall{

		public override void SpecialPower (Collider2D col)
		{
			
		}

	}

	void Start(){
		
		nb.sprite = sprite;
		this.GetComponent<SpriteRenderer> ().sprite = nb.sprite;
		nb.setDamage (damage);
	}
	void OnTriggerEnter2D(Collider2D col){
		if (!GameObject.Find ("ReferencePoint").GetComponent<BallThrower> ().instanciou) { // resolvendo bug 1
			if (col.tag == "EnemyBall" || col.tag == "Ball") { // se colidir com um inimigo
				if(col.tag == "EnemyBall"){
					col.GetComponent<EnemyBall> ().reduceHeath (this.damage);
				}
				nb.SpecialPower (col);
				Destroy (this.gameObject);
			}
		}

	}






	





}
